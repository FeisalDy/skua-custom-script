/*
name: My Custom Script
description: This is a custom script that I made
tags: custom, script, example
*/

//cs_include Scripts/Story/EtherstormWastes.cs
//cs_include Scripts/Story/Fireisland/00DoAllFireisland.cs
//cs_include Scripts/Other/Classes/ArchMage/0ArchMage.cs
//cs_include Scripts/CoreBots.cs
//cs_include Scripts/CoreStory.cs
//cs_include Scripts/Story/FireIsland/CoreFireIsland.cs
//cs_include Scripts/CoreFarms.cs
//cs_include Scripts/CoreDailies.cs
//cs_include Scripts/CoreAdvanced.cs
//cs_include Scripts/Farm/BuyScrolls.cs
//cs_include Scripts/Good/BLoD/CoreBLOD.cs
//cs_include Scripts/Story/BattleUnder.cs
//cs_include Scripts/Story/ShadowsOfWar/CoreSoW.cs
//cs_include Scripts/Story/QueenofMonsters/CoreQOM.cs
//cs_include Scripts/ShadowsOfWar/CoreSoWMats.cs
//cs_include Scripts/Other/Classes/ArchMage/CoreArchMage.cs
using Skua.Core.Interfaces;

public class Generated_custom
{
    private IScriptInterface Bot => IScriptInterface.Instance;
    private CoreBots Core => CoreBots.Instance;
    private EtherStormWastes EtherStormWastes = new();
    private DoAllFireisland DoAllFireisland = new();
    public CoreFireIsland FI = new();
    // private ArchMage ArchMage = new();
    private CoreArchMage AM = new();


    public void ScriptMain(IScriptInterface Bot)
    {
        Core.SetOptions();

        EtherStormWastes.DoAll();
        FI.CompleteFireIsland();
        AM.GetAM();

        Core.SetOptions(false);
    }
}
