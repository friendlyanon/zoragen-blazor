registerServiceWorker.register("serviceworker.js", {
    ready() {
        console.log("Page is being served from cache by a service worker.");
    },
    cached() {
        console.log("Content has been cached for offline use.");
    },
    offline() {
        console.log(
            "No internet connection found. App is running in offline mode."
        );
    },
    error(error) {
        console.error("Error during service worker registration:\n", error);
    }
});
