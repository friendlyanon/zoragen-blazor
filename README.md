# ZoraGen Blazor

A generator for the password system used in the Legend of Zelda Oracle of Ages
and Oracle of Seasons games.  
Built using the [ZoraSharp][4] library.

###What is Blazor?

Blazor is a single-page web app framework built on .NET that runs in the
browser with WebAssembly. It is currently an experimental technology.  
Blazor FAQ: https://blazor.net/docs/introduction/faq.html

### Features
 * Generates game, ring, and memory secrets
 * Remembers game information entered by the user for later use
 * Can be used offline and be installed to the homescreen on smartphones (PWA)
 
### Visit
You can find the installable website at the following address:
https://friendlyanon.github.io/zoragen/

### TODO
 * TBD

### Special Thanks
 * [kabili207][6] - Created the [ZoraSharp][4] library
 * Paulygon - Created the [original secret generator][1] way back in 2001
 * 39ster - Rediscovered [how to decode game secrets][2] using paulygon's
program
 * [LunarCookies][3] - Discovered the correct cipher and checksum logic used to
generate secrets

### License
ZoraGen Blazor is licensed under the Do What the Fuck You Want to Public
License version 2.

ZoraGen Blazor makes use of the following library:
 * [ZoraSharp][4], licensed under the GNU Lesser General Public License
version 3

ZoraGen Blazor makes use of resources from the following project:
 * [ZoraGen WPF][5], licensed under the GNU General Public License version 3

The Legend of Zelda is a trademark of Nintendo of America Inc.

[1]: http://home.earthlink.net/~paul3/zeldagbc.html
[2]: https://gamefaqs.gamespot.com/boards/472313-/66934363
[3]: https://github.com/LunarCookies
[4]: https://github.com/kabili207/zora-sharp
[5]: https://github.com/kabili207/zoragen-wpf
[6]: https://github.com/kabili207
