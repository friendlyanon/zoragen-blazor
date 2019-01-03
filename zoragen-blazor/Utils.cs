/* This program is free software. It comes without any warranty, to the extent
 * permitted by applicable law. You can redistribute it and/or modify it under
 * the terms of the Do What The Fuck You Want To Public License, Version 2, as
 * published by Sam Hocevar. See http://www.wtfpl.net/ for more details. */

// Due to an issue in the Mono runtime, we can't reflect on flag enums that are
// wider than 32 bits: https://github.com/aspnet/AspNetCore/issues/6205
#define BLAZOR_BUGGY_REFLECTION

#if !(BLAZOR_BUGGY_REFLECTION)
using System.Reflection;
#endif

using System;
using System.Collections.Generic;
using Zyrenth.Zora;

namespace zoragen_blazor
{
    public static class Utils
    {
        public static readonly List<(Rings, string, string, string)> RingsList;

        static Utils()
        {
            var list = new List<(Rings, string, string, string)>(64)

#if (BLAZOR_BUGGY_REFLECTION)

            {
                (Rings.FriendshipRing, "FriendshipRing", "Friendship Ring", "Symbol of a meeting"),
                (Rings.PowerRingL1, "PowerRingL1", "Power Ring L-1", "Sword damage ▲\nDamage taken ▲"),
                (Rings.PowerRingL2, "PowerRingL2", "Power Ring L-2", "Sword damage ▲▲\nDamage taken ▲▲"),
                (Rings.PowerRingL3, "PowerRingL3", "Power Ring L-3", "Sword damage ▲▲▲\nDamage taken ▲▲▲"),
                (Rings.ArmorRingL1, "ArmorRingL1", "Armor Ring L-1", "Sword Damage ▼\nDamage taken ▼"),
                (Rings.ArmorRingL2, "ArmorRingL2", "Armor Ring L-2", "Sword Damage ▼▼\nDamage taken ▼▼"),
                (Rings.ArmorRingL3, "ArmorRingL3", "Armor Ring L-3", "Sword Damage ▼▼▼\nDamage taken ▼▼▼"),
                (Rings.RedRing, "RedRing", "Red Ring", "Sword Damage x2"),
                (Rings.BlueRing, "BlueRing", "Blue Ring", "Damage taken reduced by 1/2"),
                (Rings.GreenRing, "GreenRing", "Green Ring", "Damage taken down by 25%\nSword damage up by 50%"),
                (Rings.CursedRing, "CursedRing", "Cursed Ring", "1/2 sword damage\nx2 damage taken"),
                (Rings.ExpertsRing, "ExpertsRing", "Expert's Ring", "Punch when unequipped"),
                (Rings.BlastRing, "BlastRing", "Blast Ring", "Bomb damage ▲"),
                (Rings.RangRingL1, "RangRingL1", "Rang Ring L-1", "Boomerang damage ▲"),
                (Rings.GBATimeRing, "GBATimeRing", "GBA Time Ring", "Life Advanced!"),
                (Rings.MaplesRing, "MaplesRing", "Maple's Ring", "Maple meetings ▲"),
                (Rings.SteadfastRing, "SteadfastRing", "Steadfast Ring", "Get knocked back less"),
                (Rings.PegasusRing, "PegasusRing", "Pegasus Ring", "Lengthen Pegasus Seed effect"),
                (Rings.TossRing, "TossRing", "Toss Ring", "Throwing distance ▲"),
                (Rings.HeartRingL1, "HeartRingL1", "Heart Ring L-1", "Slowly recover lost Hearts"),
                (Rings.HeartRingL2, "HeartRingL2", "Heart Ring L-2", "Recover lost Hearts"),
                (Rings.SwimmersRing, "SwimmersRing", "Swimmer's Ring", "Swimming speed ▲"),
                (Rings.ChargeRing, "ChargeRing", "Charge Ring", "Spin Attack charges quickly"),
                (Rings.LightRingL1, "LightRingL1", "Light Ring L-1", "Sword beams at -2 Hearts"),
                (Rings.LightRingL2, "LightRingL2", "Light Ring L-2", "Sword beams at -3 Hearts"),
                (Rings.BombersRing, "BombersRing", "Bomber's Ring", "Set two Bombs at once"),
                (Rings.GreenLuckRing, "GreenLuckRing", "Green Luck Ring", "1/2 damage from traps"),
                (Rings.BlueLuckRing, "BlueLuckRing", "Blue Luck Ring", "1/2 damage from beams"),
                (Rings.GoldLuckRing, "GoldLuckRing", "Gold Luck Ring", "1/2 damage from falls"),
                (Rings.RedLuckRing, "RedLuckRing", "Red Luck Ring", "1/2 damage from spiked floors"),
                (Rings.GreenHolyRing, "GreenHolyRing", "Green Holy Ring", "No damage from electricity"),
                (Rings.BlueHolyRing, "BlueHolyRing", "Blue Holy Ring", "No damage from Zora's fire"),
                (Rings.RedHolyRing, "RedHolyRing", "Red Holy Ring", "No damage from small rocks"),
                (Rings.SnowshoeRing, "SnowshoeRing", "Snowshoe Ring", "No sliding on ice"),
                (Rings.RocsRing, "RocsRing", "Roc's Ring", "Cracked floors don't crumble"),
                (Rings.QuicksandRing, "QuicksandRing", "Quicksand Ring", "No sinking in quicksand"),
                (Rings.RedJoyRing, "RedJoyRing", "Red Joy Ring", "Beasts drop double Rupees"),
                (Rings.BlueJoyRing, "BlueJoyRing", "Blue Joy Ring", "Beasts drop double Hearts"),
                (Rings.GoldJoyRing, "GoldJoyRing", "Gold Joy Ring", "Find double items"),
                (Rings.GreenJoyRing, "GreenJoyRing", "Green Joy Ring", "Find double Ore Chunks"),
                (Rings.DiscoveryRing, "DiscoveryRing", "Discovery Ring", "Sense soft earth nearby"),
                (Rings.RangRingL2, "RangRingL2", "Rang Ring L-2", "Boomerang damage ▲▲"),
                (Rings.OctoRing, "OctoRing", "Octo Ring", "Become an Octorok"),
                (Rings.MoblinRing, "MoblinRing", "Moblin Ring", "Become a Moblin"),
                (Rings.LikeLikeRing, "LikeLikeRing", "Like Like Ring", "Become a Like-Like"),
                (Rings.SubrosianRing, "SubrosianRing", "Subrosian Ring", "Become a Subrosian"),
                (Rings.FirstGenRing, "FirstGenRing", "First Gen Ring", "Become something"),
                (Rings.SpinRing, "SpinRing", "Spin Ring", "Double Spin Attack"),
                (Rings.BombproofRing, "BombproofRing", "Bombproof Ring", "No damage from your own Bombs"),
                (Rings.EnergyRing, "EnergyRing", "Energy Ring", "Beam replaces Spin Attack"),
                (Rings.DoubleEdgeRing, "DoubleEdgeRing", "Dbl. Edge Ring", "Sword damage ▲ but you get hurt"),
                (Rings.GBANatureRing, "GBANatureRing", "GBA Nature Ring", "Life Advanced!"),
                (Rings.SlayersRing, "SlayersRing", "Slayer's Ring", "1000 beasts slain"),
                (Rings.RupeeRing, "RupeeRing", "Rupee Ring", "10,000 Rupees collected"),
                (Rings.VictoryRing, "VictoryRing", "Victory Ring", "The Evil King Ganon defeated"),
                (Rings.SignRing, "SignRing", "Sign Ring", "100 signs broken"),
                (Rings.HundredthRing, "HundredthRing", "100th Ring", "100 rings appraised"),
                (Rings.WhispRing, "WhispRing", "Whisp Ring", "No effect from jinxes"),
                (Rings.GashaRing, "GashaRing", "Gasha Ring", "Grow great Gasha Trees"),
                (Rings.PeaceRing, "PeaceRing", "Peace Ring", "No explosion if holding Bomb"),
                (Rings.ZoraRing, "ZoraRing", "Zora Ring", "Dive without breathing"),
                (Rings.FistRing, "FistRing", "Fist Ring", "Punch when not equipped"),
                (Rings.WhimsicalRing, "WhimsicalRing", "Whimsical Ring", "Sword damage ▼ Sometimes deadly"),
                (Rings.ProtectionRing, "ProtectionRing", "Protection Ring", "Damage taken is always one Heart")
            };

#else

            ;
            var enumType = typeof(Rings);
            var values = enumType.GetEnumValues();
            foreach (Rings enumValue in values)
            {
                switch (enumValue)
                {
                    case Rings.None: case Rings.All: continue;
                }

                var enumName = enumValue.ToString();
                var attribute = enumType
                    .GetMember(enumName)[0]
                    ?.GetCustomAttribute<RingInfoAttribute>();
                if (attribute == null) continue;
                list.Add((enumValue, enumName, attribute.Name, attribute.Description));
            }

#endif

            RingsList = list;

        }

        private const int Length = 5;

        public static byte[][] GenerateSecretChunks(byte[] bytes)
        {
            if (bytes.Length % Length != 0)
            {
                throw new ArgumentOutOfRangeException(nameof(bytes), bytes.Length, $"Length of secrets can only be a multiple of {Length}.");
            }
            var result = new byte[bytes.Length / Length][];

            for (int i = 0, k = -1; i < bytes.Length; i += Length)
            {
                var sub = new byte[Length];
                Array.Copy(bytes, i, sub, 0, Length);
                result[++k] = sub;
            }

            return result;
        }
    }
}
