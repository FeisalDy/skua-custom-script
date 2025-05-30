/*
name: Banished
description: This will finish the Banished quest.
tags: story, quest, banished
*/
//cs_include Scripts/CoreBots.cs
//cs_include Scripts/CoreFarms.cs
//cs_include Scripts/CoreDailies.cs
//cs_include Scripts/CoreStory.cs
//cs_include Scripts/CoreAdvanced.cs
//cs_include Scripts/Story/QueenofMonsters/CoreQOM.cs
using Skua.Core.Interfaces;

public class Banished
{
    public IScriptInterface Bot => IScriptInterface.Instance;
    public CoreBots Core => CoreBots.Instance;
    public CoreFarms Farm = new();
    public CoreAdvanced Adv = new();
    public CoreStory Story = new();
    public CoreDailies Daily = new();
    private CoreQOM CoreQOM = new();

    public string[] QuestDrops = { "Diabolical Tome Pet", "Diabolical Tome Cape" };

    public void ScriptMain(IScriptInterface bot)
    {
        Core.SetOptions();

        doall();

        Core.SetOptions(false);
    }

    public void doall()
    {
        Story.PreLoad(this);
        HikarisQuests();
        Knave1sQuests();
        HimisQuests();
    }

    public void HikarisQuests()
    {
        if (Core.isCompletedBefore(8464))
            return;

        Core.EquipClass(ClassType.Solo);
        //Adv.BestGear(GenericGearBoost.dmgAll);

        // The First Task
        Story.KillQuest(7875, "timevoid", "Unending Avatar");

        // The Second Task
        Story.KillQuest(7876, "twilightedge", "ChaosWeaver Warrior");

        // The Third Task
        Story.KillQuest(7877, "mudluk", "Tiger Leech");

        // The Fourth Task
        Story.KillQuest(7878, "deathsrealm", "Death Alive");

        // The Fifth Task
        Story.KillQuest(7879, "thevoid", "Void Dragon");

        // The Sixth Task
        if (!Story.QuestProgression(7880))
        {
            Core.EnsureAccept(7880);
            Core.KillMonster("banished", "r14", "Left", "Desterrat Moya", "Infected Tentacle");
            Core.EnsureComplete(7880);
        }

        // Short of Reach
        Story.KillQuest(8458, "transformation", "Eldritch Abomination");

        // Stringing Along
        Story.KillQuest(8459, "blackhorn", "Bonefeeder Spider");

        // Review the Reanimated
        Story.KillQuest(8460, "noxustower", "Lightguard Caster");

        // Resting Place
        Story.KillQuest(8461, "aozorahills", "Ghostly Hasu");

        // Health is Wealth
        // Vial of Antitoxins x1  
        if (!Story.QuestProgression(8462))
        {
            Core.EnsureAccept(8462);
            Adv.BuyItem("alchemyacademy", 2114, "Vial of Antitoxins");
            Core.EnsureComplete(8462);
        }

        // A Guilty Conscience
        Story.KillQuest(8463, "ghostnexus", "Manifestation of Grief");

        // Insomniacs
        Story.KillQuest(8464, "somnia", "Dream Larva");
    }

    public void Knave1sQuests()
    {
        if (Core.isCompletedBefore(2027))
            return;

        //Adv.BestGear(GenericGearBoost.dmgAll);

        // Knave1's Route to the Void
        Story.MapItemQuest(2022, "northlands", 979);

        // Void Spell
        if (!Story.QuestProgression(2023))
        {
            Core.EnsureAccept(2023);
            Core.HuntMonster("northlands", "Chaos Gemrald", "Chaos Gemrald Cluster");
            Core.HuntMonster("northlands", "Chaos Gemrald", "Chaos Gemrald Shard", 5);
            Core.EnsureComplete(2023);
        }

        // Know Thy Enemy
        Story.MapItemQuest(2024, "banished", 980);

        // An Enemy Unblooded
        if (!Story.QuestProgression(2025))
        {
            Core.EnsureAccept(2025);
            Core.HuntMonster("banished", "Desterrat Cruor", "Drop of Life", 10);
            Core.HuntMonster("banished", "Desterrat Crux", "Breath of Life", 4);
            Core.EnsureComplete(2025);
        }

        // Re - Open the Seal
        Story.MapItemQuest(2026, "banished", 981, 7);

        // Weaken the Moya
        Story.KillQuest(2027, "doomwood", "Doomwood Ectomancer");

        // Banish the Banished One
        Story.KillQuest(2028, "banished", "Desterrat Moya");
    }

    public void HimisQuests()
    {
        if (Core.isCompletedBefore(9044))
            return;

        HikarisQuests();
        CoreQOM.TheBook();

        Story.PreLoad(this);

        //Recover and Recycle (9040)
        Story.KillQuest(9040, "brokenwoods", "Extrikiti");

        //Tormented Fang Uncleansed Grove (9041)
        Core.EquipClass(ClassType.Solo);
        Story.KillQuest(9041, "deepforest", "Aberrant Horror");

        //Slice of Life (9042)
        if (!Story.QuestProgression(9042))
        {
            Core.EquipClass(ClassType.Farm);
            Core.EnsureAcceptmultiple( new[] { 9042, 739 });
            Core.AddDrop("Racing Trophy");
            while (!Bot.ShouldExit && !Core.CheckInventory("Racing Trophy", 20))
                Core.ChainComplete(746);
            Core.HuntMonster("table", "Roach", "Gold Roach Antenna", 10);
            Core.EnsureComplete(739, 5420);
            Core.EnsureComplete(9042);
        }

        //Null and Void (9043)
        Story.KillQuest(9043, "thevoid", "Dark Djinn");

        //Summoning and Sealing (9044)
        Core.EquipClass(ClassType.Solo);
        Story.KillQuest(9044, "brokenwoods", "Eldritch Amalgamation");
    }
}
