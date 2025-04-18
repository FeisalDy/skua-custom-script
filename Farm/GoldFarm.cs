/*
name: Gold Farm
description: honor hall for members, BGE for f2p
tags: gold, battle ground e, honor hall, berserker bunny
*/
//cs_include Scripts/CoreBots.cs
//cs_include Scripts/CoreFarms.cs
//cs_include Scripts/CoreAdvanced.cs
using Skua.Core.Interfaces;

public class GoldFarm
{
    public IScriptInterface Bot => IScriptInterface.Instance;
    public CoreBots Core => CoreBots.Instance;
    public CoreFarms Farm = new();
    public CoreAdvanced Adv = new();

    public void ScriptMain(IScriptInterface bot)
    {
        Core.SetOptions(disableClassSwap: true);

        DoFarmGold();

        Core.SetOptions(false);
    }

    public void DoFarmGold()
    {
        Core.EquipClass(ClassType.Farm);
        //Adv.BestGear(GenericGearBoost.gold);
        Bot.Drops.Start();

        Farm.Gold();
    }
}
