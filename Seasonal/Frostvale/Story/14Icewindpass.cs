/*
name: Icewind Pass Story
description: This script completes the Icewindpass quests.
tags: saga, story, quest, seasonal, frostval,frostvale,frost,icewindpass
*/
//cs_include Scripts/CoreBots.cs
//cs_include Scripts/CoreStory.cs
//cs_include Scripts/Story/Glacera.cs
//cs_include Scripts/Seasonal/Frostvale/Story/CoreFrostvale.cs
using Skua.Core.Interfaces;

public class Icewindpass
{
    private IScriptInterface Bot => IScriptInterface.Instance;
    private CoreBots Core => CoreBots.Instance;
    private CoreFrostvale Frost = new();
    public void ScriptMain(IScriptInterface Bot)
    {
        Core.SetOptions();

        Frost.Icewindpass();
        Core.SetOptions(false);
    }
}

