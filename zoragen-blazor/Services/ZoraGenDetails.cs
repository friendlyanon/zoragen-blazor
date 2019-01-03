/* This program is free software. It comes without any warranty, to the extent
 * permitted by applicable law. You can redistribute it and/or modify it under
 * the terms of the Do What The Fuck You Want To Public License, Version 2, as
 * published by Sam Hocevar. See http://www.wtfpl.net/ for more details. */

using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Zyrenth.Zora;

public class ZoraGenDetails : IZoraGenDetails
{
    private LocalStorage localStorage = null;

    private GameRegion region = GameRegion.US;
    private string hero = string.Empty;
    private string child = string.Empty;
    private short gameId = 1;
    private byte behaviour = 0;
    private byte animal = 0;
    private byte agesSeasons = 0;
    private bool isHeroQuest = false;
    private bool isLinkedGame = false;
    private long rings = 0L;
    private bool wasGivenFreeRing = false;

    public GameRegion Region
    {
        get => region;
        set => localStorage.SetItem("Region", (region = value) == GameRegion.JP ? "0" : "1");
    }
    public Game Game {
        get => (Game) agesSeasons;
        set => localStorage.SetItem("Game", (agesSeasons = (byte) value) == 0 ? "0" : "1");
    }
    public bool IsHeroQuest {
        get => isHeroQuest;
        set => localStorage.SetItem("IsHeroQuest", (isHeroQuest = value) ? "1" : "0");
    }
    public bool IsLinkedGame {
        get => isLinkedGame;
        set => localStorage.SetItem("IsLinkedGame", (isLinkedGame = value) ? "1" : "0");
    }
    public short GameID {
        get => gameId;
        set => localStorage.SetItem("GameID", (gameId = value).ToString());
    }
    public string Hero {
        get => hero.Trim(' ', '\0');
        set => localStorage.SetItem("Hero", hero = value.TrimEnd());
    }
    public string Child
    {
        get => child.Trim(' ', '\0');
        set => localStorage.SetItem("Child", child = value.TrimEnd());
    }

    public Animal Animal {
        get => (Animal) animal;
        set => localStorage.SetItem("Animal", (animal = (byte) value).ToString());
    }
    public byte Behaviour {
        get => behaviour;
        set => localStorage.SetItem("Behaviour", (behaviour = value).ToString());
    }
    public bool WasGivenFreeRing {
        get => wasGivenFreeRing;
        set => localStorage.SetItem("WasGivenFreeRing", (wasGivenFreeRing = value) ? "1" : "0");
    }
    public Rings Rings {
        get => (Rings) rings;
        set => localStorage.SetItem("Rings", (rings = (long) value).ToString());
    }

    private Task initer;

    private async Task DoInitAsync(ILocalStorage localStorage)
    {
        {
            var regionStr = await localStorage.GetItem("Region");
            if (!string.IsNullOrEmpty(regionStr)) region = (GameRegion) (regionStr[0] & 1);
        }
        {
            var gameStr = await localStorage.GetItem("Game");
            if (!string.IsNullOrEmpty(gameStr)) agesSeasons = (byte) (gameStr[0] & 1);
        }
        {
            var heroStr = await localStorage.GetItem("IsHeroQuest");
            if (!string.IsNullOrEmpty(heroStr)) isHeroQuest = (heroStr[0] & 1) == 1;
        }
        {
            var linkStr = await localStorage.GetItem("IsLinkedGame");
            if (!string.IsNullOrEmpty(linkStr)) isLinkedGame = (linkStr[0] & 1) == 1;
        }
        short.TryParse(await localStorage.GetItem("GameID"), out gameId);
        {
            var nameStr = await localStorage.GetItem("Hero");
            if (!string.IsNullOrEmpty(nameStr)) hero = nameStr;
        }
        {
            var childStr = await localStorage.GetItem("Child");
            if (!string.IsNullOrEmpty(childStr)) child = childStr;
        }
        byte.TryParse(await localStorage.GetItem("Animal"), out animal);
        byte.TryParse(await localStorage.GetItem("Behaviour"), out behaviour);
        {
            var freeStr = await localStorage.GetItem("WasGivenFreeRing");
            if (!string.IsNullOrEmpty(freeStr)) wasGivenFreeRing = (freeStr[0] & 1) == 1;
        }
        long.TryParse(await localStorage.GetItem("Rings"), out rings);
        this.localStorage = (LocalStorage) localStorage;
        initer = null;
    }

    public Task InitAsync(ILocalStorage localStorage)
    {
        if (this.localStorage == null)
        {
            return initer ?? (initer = DoInitAsync(localStorage));
        }
        return Task.Delay(0);
    }

    public Task InitAsync()
    {
        return initer ?? Task.Delay(0);
    }

    private static readonly Regex nameRegex = new Regex(
        "[^a-zA-Z ]",
        RegexOptions.Compiled | RegexOptions.ECMAScript
    );

    private static string SanitizeName(in string name)
    {
        return nameRegex.Replace(name, string.Empty).PadRight(5, '\0');
    }

    public GameInfo ToGameInfo()
    {
        return new GameInfo()
        {
            Region = Region,
            Game = Game,
            IsHeroQuest = IsHeroQuest,
            IsLinkedGame = IsLinkedGame,
            GameID = System.Math.Max(GameID, (short) 1),
            Hero = SanitizeName(Hero),
            Child = SanitizeName(Child),
            Animal = Animal,
            Behavior = Behaviour,
            WasGivenFreeRing = WasGivenFreeRing,
            Rings = Rings
        };
    }
}
