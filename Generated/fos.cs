//cs_include Scripts/Chaos/EternalDrakathSet.cs
//cs_include Scripts/Evil/SepulchuresOriginalHelm.cs
//cs_include Scripts/Evil/ADK.cs
//cs_include Scripts/CoreBots.cs
//cs_include Scripts/CoreFarms.cs
//cs_include Scripts/CoreDailies.cs
//cs_include Scripts/CoreStory.cs
//cs_include Scripts/CoreAdvanced.cs
//cs_include Scripts/Good/BLoD/CoreBLOD.cs
//cs_include Scripts/Chaos/DrakathsArmor.cs
//cs_include Scripts/Story/BattleUnder.cs
//cs_include Scripts/Story/StarSinc.cs
//cs_include Scripts/Story/LordsofChaos/Core13LoC.cs
//cs_include Scripts/Nation/CoreNation.cs
//cs_include Scripts/Other/Classes/DragonslayerGeneral.cs
//cs_include Scripts/Other/WarFuryEmblem.cs
//cs_include Scripts/Story/ShadowsOfWar/CoreSoW.cs
//cs_include Scripts/Story/Lair.cs
//cs_include Scripts/Story/Doomwood/CoreDoomwood.cs
//cs_include Scripts/Story/ThroneofDarkness/CoreToD.cs
using Skua.Core.Interfaces;

public class Generated_fos
{
    private IScriptInterface Bot => IScriptInterface.Instance;
    private CoreBots Core => CoreBots.Instance;
    private EternalDrakath EternalDrakath = new();
    private SepulchuresOriginalHelm SepulchuresOriginalHelm = new();
    private ArchDoomKnight ArchDoomKnight = new();

    public void ScriptMain(IScriptInterface Bot)
    {
        Core.SetOptions();

        EternalDrakath.getSet();
        SepulchuresOriginalHelm.DoAll();
        ArchDoomKnight.DoAll();

        Core.SetOptions(false);
    }
}
