/*
name: Mysterious Dungeon REP
description: This script will farm Mysterious Dungeon reputation to rank 10.
tags: mysterious, dungeon, mysterious dungeon, mysteriousdungeon, rep, rank, reputation
*/
//cs_include Scripts/CoreBots.cs
//cs_include Scripts/CoreFarms.cs
//cs_include Scripts/CoreAdvanced.cs
using Skua.Core.Interfaces;
public class MysteriousDungeonREP
{
    public CoreBots Core => CoreBots.Instance;
    public CoreFarms Farm = new();
    public CoreAdvanced Adv = new();

    public void ScriptMain(IScriptInterface bot)
    {
        Core.SetOptions();

        //Adv.BestGear(GenericGearBoost.dmgAll);
        //Adv.BestGear(GenericGearBoost.rep);
        Farm.MysteriousDungeonREP();

        Core.SetOptions(false);
    }
}
