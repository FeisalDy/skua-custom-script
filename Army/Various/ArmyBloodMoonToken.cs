/*
name: Blood Moon Tokens (Army)
description: Uses an army to farm Blood Moon Tokens
tags: blood, moon, tokens, army, seasonal, pumpkin, lord
*/
//cs_include Scripts/CoreBots.cs
//cs_include Scripts/Army/CoreArmyLite.cs
//cs_include Scripts/CoreFarms.cs
using Skua.Core.Interfaces;
using Skua.Core.Options;

public class ArmyBloodMoonToken
{
    private IScriptInterface Bot => IScriptInterface.Instance;
    private CoreBots Core => CoreBots.Instance;
    private CoreArmyLite Army = new();
    private static CoreArmyLite sArmy = new();

    public string OptionsStorage = "ArmyBloodMoonToken";
    public bool DontPreconfigure = true;
    public List<IOption> Options = new()
    {
        sArmy.player1,
        sArmy.player2,
        sArmy.player3,
        sArmy.player4,
        sArmy.player5,
        sArmy.player6,
        sArmy.player7,
        sArmy.packetDelay,
        CoreBots.Instance.SkipOptions
    };

    public void ScriptMain(IScriptInterface bot)
    {
        Core.BankingBlackList.AddRange(Loot);
        Core.SetOptions(disableClassSwap: true);

        Setup();

        Core.SetOptions(false);
    }

    public void Setup()
    {
        Core.PrivateRooms = true;
        Core.PrivateRoomNumber = Army.getRoomNr();

        Core.OneTimeMessage("Only for army", "This is intended for use with an army, not for solo players.");

        Core.AddDrop(Loot);
        Core.EquipClass(ClassType.Solo);
        Core.RegisterQuests(Core.IsMember ? 6060 : 6059);

        Army.AggroMonCells("r4a", "r12a");
        Army.AggroMonStart("bloodmoon");
        Army.DivideOnCells("r4a", "r12a", "r12a", "r12a", "r12a", "r12a", "r12a");

        

        while (!Bot.ShouldExit)
            Bot.Combat.Attack("*");
        Army.AggroMonStop(true);
    }

    private string[] Loot = { "Blood Moon Token", "Moon Stone", "Black Blood Vial" };
}
