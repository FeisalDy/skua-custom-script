/*
name: Hollowborn Saga
description: This script will complete Hollowborn Saga.
tags: hollowborn, saga, trygve, neofortress, lae, treasure hunt, lae birthday, shadowrealm, whispering helmet, neotower,dawnsanctum,neo tower,dawn sanctum,quest
*/
//cs_include Scripts/CoreBots.cs
//cs_include Scripts/CoreStory.cs
//cs_include Scripts/Story/Hollowborn/CoreHollowbornStory.cs
using Skua.Core.Interfaces;

public class DoAllHB
{
    public IScriptInterface Bot => IScriptInterface.Instance;
    public CoreBots Core => CoreBots.Instance;
    public CoreHollowbornStory HB = new();

    public void ScriptMain(IScriptInterface bot)
    {
        Core.SetOptions();

        HB.DoAll();

        Core.SetOptions(false);
    }
}
