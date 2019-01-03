/* This program is free software. It comes without any warranty, to the extent
 * permitted by applicable law. You can redistribute it and/or modify it under
 * the terms of the Do What The Fuck You Want To Public License, Version 2, as
 * published by Sam Hocevar. See http://www.wtfpl.net/ for more details. */

"use strict";
const { join, basename } = require("path");
const { readdir, readFile, writeFile, lstat } = (() => {
  const orig = process.emitWarning;
  process.emitWarning = global.noop || (() => {});
  try { return require("fs").promises; }
  finally { process.emitWarning = orig; }
})();

const projectName = basename(__dirname);
const baseDir = "/";

/* Manifest details begin */

const manifest = {
  name: "ZoraGen",
  short_name: "ZoraGen",
  description: "ZoraSharp GUI on the web for generating secrets for the Oracle Zelda games.",
  icons: [
    {
      src: "/img/icons/android-chrome-192x192.png",
      sizes: "192x192",
      type: "image/png"
    },
    {
      src: "/img/icons/android-chrome-512x512.png",
      sizes: "512x512",
      type: "image/png"
    }
  ],
  start_url: baseDir,
  scope: ".",
  display: "standalone",
  orientation: "portrait",
  background_color: "#2D1108",
  theme_color: "#2D1108",
};

/* Manifest details end */

const ignoreFiles = (
  new Set()
  .add("serviceworker.js")
);

async function walk(dir, path, names) {
  const directories = [];
  for (const entry of await readdir(dir)) {
    const entryPath = join(dir, entry);
    const stats = await lstat(entryPath);
    if (stats.isFile()) {
      if (ignoreFiles.has(entry) || entry.endsWith(".pdb")) continue;
      names.add(`${path.join("/")}/${entry}`);
    }
    else if (stats.isDirectory()) {
      directories.push([entry, entryPath]);
    }
  }
  for (const [entry, entryPath] of directories) {
    path.push(entry);
    await walk(entryPath, path, names);
    path.pop();
  }
}

async function generate() {
  // return await writeFile(join(__dirname, "wwwroot", "index.html"), await readFile(join(__dirname, "index.base.html"), "utf8"));
  const names = new Set().add("./");
  const dirs = [
    join(__dirname, "wwwroot"),
    join(__dirname, "bin", "Debug", "netstandard2.0", "dist"),
  ];
  for (const dir of dirs) await walk(dir, ["."], names);
  await writeFile(
    join(__dirname, "wwwroot", "serviceworker.js"),
    `"use strict";
// Automatically generated file. Do not edit!
// Generated on ${new Date().toLocaleString()}
const cacheName = "${projectName}";
const filesToCache = ${JSON.stringify([...names], null, 2)};

self.addEventListener("install", function (e) {
  console.log("[ServiceWorker] Install");
  e.waitUntil(
    caches.open(cacheName).then(function (cache) {
      console.log("[ServiceWorker] Caching app shell");
      return cache.addAll(filesToCache); 
    })
  );
});

self.addEventListener("activate", event => {
  event.waitUntil(self.clients.claim());
});

self.addEventListener("fetch", event => {
  event.respondWith(
    caches.match(event.request, { ignoreSearch: true }).then(response => {
      return response || fetch(event.request);
    })
  );
});
  `);
  await writeFile(
    join(__dirname, "wwwroot", "manifest.json"),
    JSON.stringify(manifest, null, "\t")
  );
  const register = await readFile(join(__dirname, "register-sw.js"), "utf8");
  let count = 0;
  const index = (await readFile(join(__dirname, "index.base.html"), "utf8")).replace(
    /<!--\s*pwa\s*-->/gi,
    function() {
      switch (count++) {
        case 0:
          return `<link rel="manifest" href="manifest.json" /> <link rel="script" href="serviceworker.js" /> <meta name="theme-color" content="${manifest.theme_color}" />`;
        case 1:
          return `<script src="register-sw.js"></script> <script>${register}</script>`;
        default:
          throw new Error("There have been more PWA placeholders than expected");
      }
    }
  ).replace(/<!--\s*base\s*-->/i, `<base href="${baseDir}" />`);
  await writeFile(join(__dirname, "wwwroot", "index.html"), index);
  console.log("[PWA] Successfully set index.html up");
}

console.log("[PWA] Setting index.html up");
generate().then(
  null,
  e => process.exit(console.error(e), 1)
);
