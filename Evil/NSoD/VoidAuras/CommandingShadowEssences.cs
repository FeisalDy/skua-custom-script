/*
name: Commanding Shadow Essences
description: farms void auras via the "commanding shadow essences" quest.
tags: commanding, shadow, essences, void aura
*/
//cs_include Scripts/CoreBots.cs
//cs_include Scripts/CoreFarms.cs
//cs_include Scripts/CoreAdvanced.cs
//cs_include Scripts/CoreDailies.cs
//cs_include Scripts/Good/BLOD/CoreBLOD.cs
//cs_include Scripts/Evil/SDKA/CoreSDKA.cs
//cs_include Scripts/Other/Classes/Necromancer.cs
//cs_include Scripts/Story/BattleUnder.cs
//cs_include Scripts/CoreStory.cs
//cs_include Scripts/Evil/NSoD/CoreNSOD.cs
using Skua.Core.Interfaces;
using Skua.Core.Options;

public class CommandingShadowEssences
{
    public IScriptInterface Bot => IScriptInterface.Instance;
    public CoreBots Core => CoreBots.Instance;
    public static CoreBots sCore => CoreBots.Instance;
    public CoreNSOD NSoD = new();
    public static CoreNSOD sNSoD = new();


    public bool DontPreconfigure = true;
    public string OptionsStorage = sNSoD.OptionsStorage;
    public List<IOption> Options = new()
    {
        sNSoD.GetSDKA,
        CoreBots.Instance.SkipOptions,
    };

    public void ScriptMain(IScriptInterface bot)
    {
        Core.SetOptions();

        NSoD.CommandingShadowEssences();

        Core.SetOptions(false);
    }
}
