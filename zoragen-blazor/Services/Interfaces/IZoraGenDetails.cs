/* This program is free software. It comes without any warranty, to the extent
 * permitted by applicable law. You can redistribute it and/or modify it under
 * the terms of the Do What The Fuck You Want To Public License, Version 2, as
 * published by Sam Hocevar. See http://www.wtfpl.net/ for more details. */

using System.Threading.Tasks;
using Zyrenth.Zora;

public interface IZoraGenDetails
{
    GameRegion Region { get; set; }
    Game Game { get; set; }
    bool IsHeroQuest { get; set; }
    bool IsLinkedGame { get; set; }
    short GameID { get; set; }
    string Hero { get; set; }
    string Child { get; set; }
    Animal Animal { get; set; }
    byte Behaviour { get; set; }
    bool WasGivenFreeRing { get; set; }
    Rings Rings { get; set; }
    Task InitAsync(ILocalStorage localStorage);
    Task InitAsync();
    GameInfo ToGameInfo();
}
