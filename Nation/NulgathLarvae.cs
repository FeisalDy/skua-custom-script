/*
name: NulgathLarvae
description: will do "Nulgath (Larvae) [2566]"
tags: nulgath, larvae, nation
*/
//cs_include Scripts/CoreBots.cs
//cs_include Scripts/CoreFarms.cs
//cs_include Scripts/Nation/CoreNation.cs
using Skua.Core.Interfaces;

public class NulgathLarvae
{
    public CoreBots Core => CoreBots.Instance;
    public CoreNation Nation = new();

    public void ScriptMain(IScriptInterface bot)
    {
        Core.BankingBlackList.AddRange(Nation.bagDrops);
        Core.SetOptions();

        Nation.NulgathLarvae();

        Core.SetOptions(false);
    }
}
