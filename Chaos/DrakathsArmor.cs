/*
name: Drakath Armor
description: Gets the Drakath Armor / Original Drakath Armor
tags: drakath, drakath armor, original drakath armor
*/
//cs_include Scripts/CoreBots.cs
//cs_include Scripts/CoreFarms.cs
//cs_include Scripts/CoreDailies.cs
//cs_include Scripts/CoreStory.cs
//cs_include Scripts/CoreAdvanced.cs
//cs_include Scripts/Good/BLoD/CoreBLOD.cs
//cs_include Scripts/Nation/CoreNation.cs
//cs_include Scripts/Story/BattleUnder.cs
//cs_include Scripts/Story/LordsofChaos/Core13LoC.cs
using Skua.Core.Interfaces;

public class DrakathArmorBot
{
    public IScriptInterface Bot => IScriptInterface.Instance;
    private CoreBots Core => CoreBots.Instance;
    private CoreFarms Farm = new();
    private CoreDailies Daily = new();
    public CoreAdvanced Adv = new();
    private CoreBLOD BLOD = new();
    private Core13LoC LOC => new();
    private CoreNation Nation = new();

    public void ScriptMain(IScriptInterface bot)
    {
        Core.SetOptions();

        GetBoth();

        Core.SetOptions(false);
    }

    public void GetBoth()
    {
        LOC.Complete13LOC();
        DrakathArmorQuest();
        if (!Core.CheckInventory("Dage's Scroll Fragment", 13))
        {
            Core.Logger("Cannot continue with \"Drakath Armor\" not enough \"Dage's Scroll Fragment\"");
            return;
        }
        Core.BuyItem(Bot.Map.Name, 994, "Original Drakath Armor");
        Core.BuyItem(Bot.Map.Name, 994, "Drakath Armor");
    }

    public void DrakathArmor()
    {
        if (Core.CheckInventory("Drakath Armor"))
            return;

        LOC.Complete13LOC();
        DrakathArmorQuest();
        Core.BuyItem(Bot.Map.Name, 994, "Drakath Armor");
    }

    public void DrakathOriginalArmor()
    {
        if (Core.CheckInventory("Original Drakath Armor"))
            return;

        LOC.Complete13LOC();
        DrakathArmorQuest();
        Core.BuyItem(Bot.Map.Name, 994, "Original Drakath Armor");
    }

    public void DrakathArmorQuest()
    {
        if (Core.CheckInventory("Get Your Original Drakath's Armor"))
            return;

        Core.AddDrop("Dage's Scroll Fragment", "Treasure Chest", "Face of Chaos", "Get Your Original Drakath's Armor");

        Core.EnsureAccept(3882);
        Farm.ChaosREP();
        if (!Core.CheckInventory("Dage's Scroll Fragment", 13))
        {
            Daily.DagesScrollFragment();
        }
        BLOD.BlindingLightOfDestiny();
        Adv.BuyItem("hyperspace", 194, "Le Chocolat");
        Core.EquipClass(ClassType.Farm);
        Core.KillMonster("swordhavenundead", "Left", "Right", "*", "Treasure Chest", 100, false);
        Core.EquipClass(ClassType.Solo);
        Core.KillMonster("ultradrakath", "r1", "Left", "Champion of Chaos", "Face of Chaos", isTemp: false, publicRoom: true);
        Nation.FarmUni13(3);
        Farm.BladeofAweREP(6, farmBoA: true);

        if (!Core.CheckInventory("Dage's Scroll Fragment", 13))
            Core.Logger($"You own \"Dage's Scroll Fragment\" ({Bot.Inventory.GetQuantity("Dage's Scroll Fragment")}/13) [Daily Quest]. Bot can not continue.");
        else Core.EnsureComplete(3882);

        //wait and pickup drop (if not already picked up)
        Bot.Wait.ForDrop("Get Your Original Drakath's Armor");
        Bot.Wait.ForPickup("Get Your Original Drakath's Armor");
    }
}
