/*
name: Crag's Gem Merge
description: This script farms all the materials needed for Crag's Gem Merge in tercessuinotlim.
tags: crag, nulgath, merge, gem, empowered voidstone
*/
//cs_include Scripts/CoreBots.cs
//cs_include Scripts/CoreFarms.cs
//cs_include Scripts/CoreAdvanced.cs
using Skua.Core.Interfaces;
using Skua.Core.Models.Items;
using Skua.Core.Options;

public class CragsGemMerge
{
    private IScriptInterface Bot => IScriptInterface.Instance;
    private CoreBots Core => CoreBots.Instance;
    private CoreFarms Farm = new();
    private CoreAdvanced Adv = new();
    private static CoreAdvanced sAdv = new();

    public bool DontPreconfigure = true;
    public List<IOption> Generic = sAdv.MergeOptions;
    public string[] MultiOptions = { "Generic", "Select" };
    public string OptionsStorage = sAdv.OptionsStorage;
    // [Can Change] This should only be changed by the author.
    //              If true, it will not stop the script if the default case triggers and the user chose to only get mats
    private bool dontStopMissingIng = false;

    public void ScriptMain(IScriptInterface Bot)
    {
        Core.BankingBlackList.AddRange(new[] { "Empowered Voidstone", "Ice Diamond", "Dark Bloodstone", "Butterfly Sapphire", "Understone", "Rainbow Moonstone" });
        Core.SetOptions();

        BuyAllMerge();
        Core.SetOptions(false);
    }

    public void BuyAllMerge(string? buyOnlyThis = null, mergeOptionsEnum? buyMode = null)
    {
        Farm.CraggleRockREP();
        //Only edit the map and shopID here
        Adv.StartBuyAllMerge("tercessuinotlim", 1819, findIngredients, buyOnlyThis, buyMode: buyMode);

        #region Dont edit this part
        void findIngredients()
        {
            ItemBase req = Adv.externalItem;
            int quant = Adv.externalQuant;
            int currentQuant = req.Temp ? Bot.TempInv.GetQuantity(req.Name) : Bot.Inventory.GetQuantity(req.Name);
            if (req == null)
            {
                Core.Logger("req is NULL");
                return;
            }

            switch (req.Name)
            {
                default:
                    bool shouldStop = !Adv.matsOnly || !dontStopMissingIng;
                    Core.Logger($"The bot hasn't been taught how to get {req.Name}." + (shouldStop ? " Please report the issue." : " Skipping"), messageBox: shouldStop, stopBot: shouldStop);
                    break;
                #endregion

                case "Empowered Voidstone":
                    Core.FarmingLogger(req.Name, quant);
                    Core.EquipClass(ClassType.Farm);
                    Core.RegisterQuests(7277);
                    while (!Bot.ShouldExit && !Core.CheckInventory(req.Name, quant))
                    {
                        Core.KillMonster("wanders", "r2", "Down", "Kalestri Worshiper", log: false);
                        Bot.Wait.ForPickup(req.Name);
                    }
                    Core.CancelRegisteredQuests();
                    break;

                case "Ice Diamond":
                Core.EquipClass(ClassType.Farm);
                    Core.RegisterQuests(7279);
                    Core.FarmingLogger(req.Name, quant);
                    Core.AddDrop("Ice Diamond");
                    while (!Bot.ShouldExit && !Core.CheckInventory(req.Name, quant))
                    {
                        Core.EnsureAccept(7279);
                        Core.KillMonster("kingcoal", "r1", "Left", "*", "Frozen Coal", 10, log: false);
                        Core.EnsureComplete(7279);
                        Bot.Wait.ForPickup("Ice Diamond");
                    }
                    Core.CancelRegisteredQuests();
                    break;

                case "Dark Bloodstone":
                    Core.FarmingLogger(req.Name, quant);
                    Core.EquipClass(ClassType.Farm);
                    Core.RegisterQuests(7281);
                    while (!Bot.ShouldExit && !Core.CheckInventory(req.Name, quant))
                    {
                        Core.HuntMonster("safiria", "Blood Maggot", log: false);
                        Bot.Wait.ForPickup(req.Name);
                    }
                    Core.CancelRegisteredQuests();
                    break;

                case "Butterfly Sapphire":
                    Core.FarmingLogger(req.Name, quant);
                    Core.EquipClass(ClassType.Farm);
                    Core.RegisterQuests(7287);
                    while (!Bot.ShouldExit && !Core.CheckInventory(req.Name, quant))
                    {
                        Core.HuntMonster("bloodtusk", "Trollola Plant", log: false);
                        Bot.Wait.ForPickup(req.Name);
                    }
                    Core.CancelRegisteredQuests();
                    break;

                case "Understone":
                    Core.FarmingLogger(req.Name, quant);
                    Core.EquipClass(ClassType.Farm);
                    Core.RegisterQuests(7289);
                    while (!Bot.ShouldExit && !Core.CheckInventory(req.Name, quant))
                    {
                        Core.HuntMonster("battleunderc", "Blue Crystalized Undead", log: false);
                        Bot.Wait.ForPickup(req.Name);
                    }
                    Core.CancelRegisteredQuests();
                    break;

                case "Rainbow Moonstone":
                    Core.FarmingLogger(req.Name, quant);
                    Core.EquipClass(ClassType.Farm);
                    Core.RegisterQuests(7291);
                    while (!Bot.ShouldExit && !Core.CheckInventory(req.Name, quant))
                    {
                        Core.HuntMonster("earthstorm", "Diamond Golem", "Chip of Diamond", log: false);
                        Core.HuntMonster("earthstorm", "Emerald Golem", "Chip of Emerald", log: false);
                        Core.HuntMonster("earthstorm", "Ruby Golem", "Chip of Ruby", log: false);
                        Core.HuntMonster("earthstorm", "Sapphire Golem", "Chip of Sapphire", log: false);
                        Bot.Wait.ForPickup(req.Name);
                    }
                    Core.CancelRegisteredQuests();
                    break;

            }
        }
    }

    public List<IOption> Select = new()
    {
        new Option<bool>("52627", "SkinWalker Warrior", "Mode: [select] only\nShould the bot buy \"SkinWalker Warrior\" ?", false),
        new Option<bool>("52628", "SkinWalker Druid", "Mode: [select] only\nShould the bot buy \"SkinWalker Druid\" ?", false),
        new Option<bool>("52629", "Void SkinWalker", "Mode: [select] only\nShould the bot buy \"Void SkinWalker\" ?", false),
        new Option<bool>("52630", "Void SkinWalker Fiend", "Mode: [select] only\nShould the bot buy \"Void SkinWalker Fiend\" ?", false),
        new Option<bool>("52631", "SkinWalker's Female Morph", "Mode: [select] only\nShould the bot buy \"SkinWalker's Female Morph\" ?", false),
        new Option<bool>("52632", "SkinWalker's Male Morph", "Mode: [select] only\nShould the bot buy \"SkinWalker's Male Morph\" ?", false),
        new Option<bool>("52633", "SkinWalker's Female Horns", "Mode: [select] only\nShould the bot buy \"SkinWalker's Female Horns\" ?", false),
        new Option<bool>("52634", "SkinWalker's Male Horns", "Mode: [select] only\nShould the bot buy \"SkinWalker's Male Horns\" ?", false),
        new Option<bool>("52635", "SkinWalker's Void Helm", "Mode: [select] only\nShould the bot buy \"SkinWalker's Void Helm\" ?", false),
        new Option<bool>("52636", "Void SkinWalker's Horns", "Mode: [select] only\nShould the bot buy \"Void SkinWalker's Horns\" ?", false),
        new Option<bool>("52637", "Void SkinWalker's Morph", "Mode: [select] only\nShould the bot buy \"Void SkinWalker's Morph\" ?", false),
        new Option<bool>("52638", "SkinWalker Fiend's Morph", "Mode: [select] only\nShould the bot buy \"SkinWalker Fiend's Morph\" ?", false),
        new Option<bool>("52639", "SkinWalker Fiend's Horns", "Mode: [select] only\nShould the bot buy \"SkinWalker Fiend's Horns\" ?", false),
        new Option<bool>("52640", "Tribal SkinWalker's Morph", "Mode: [select] only\nShould the bot buy \"Tribal SkinWalker's Morph\" ?", false),
        new Option<bool>("52641", "Tribal SkinWalker's Horns", "Mode: [select] only\nShould the bot buy \"Tribal SkinWalker's Horns\" ?", false),
        new Option<bool>("52642", "Tribal SkinWalker's Spiked Wrap", "Mode: [select] only\nShould the bot buy \"Tribal SkinWalker's Spiked Wrap\" ?", false),
        new Option<bool>("52643", "Tribal SkinWalker's Wrap", "Mode: [select] only\nShould the bot buy \"Tribal SkinWalker's Wrap\" ?", false),
        new Option<bool>("52644", "Tribal SkinWalker's Tail", "Mode: [select] only\nShould the bot buy \"Tribal SkinWalker's Tail\" ?", false),
        new Option<bool>("52645", "Tribal SkinWalker's Axe", "Mode: [select] only\nShould the bot buy \"Tribal SkinWalker's Axe\" ?", false),
        new Option<bool>("52646", "Tribal SkinWalker's Poleaxe", "Mode: [select] only\nShould the bot buy \"Tribal SkinWalker's Poleaxe\" ?", false),
        new Option<bool>("52647", "Tribal SkinWalker's Spear", "Mode: [select] only\nShould the bot buy \"Tribal SkinWalker's Spear\" ?", false),
        new Option<bool>("52648", "Tribal SkinWalker's Skull Mace", "Mode: [select] only\nShould the bot buy \"Tribal SkinWalker's Skull Mace\" ?", false),
        new Option<bool>("52649", "Tribal SkinWalker's Staff", "Mode: [select] only\nShould the bot buy \"Tribal SkinWalker's Staff\" ?", false),
    };
}
