/*
name: Caladbolg
description: null
tags: null
*/
//cs_include Scripts/CoreBots.cs
//cs_include Scripts/CoreFarms.cs
//cs_include Scripts/CoreAdvanced.cs
//cs_include Scripts/CoreStory.cs
//cs_include Scripts/Legion/CoreLegion.cs
using Skua.Core.Interfaces;
using Skua.Core.Options;

public class Caladbolg
{
    public IScriptInterface Bot => IScriptInterface.Instance;
    public CoreBots Core => CoreBots.Instance;
    public CoreFarms Farm = new();
    public CoreLegion Legion = new();
    public CoreAdvanced Adv = new();

    public List<IOption> Options = new()
    {
        new Option<bool>("other", "Other Rewards", "If True, the bot will also get the Dual Caladbolgs and Caladboogly", false)
    };

    public void ScriptMain(IScriptInterface bot)
    {
        Core.SetOptions();

        GetCaladbolg(Bot.Config!.Get<bool>("other"));

        Core.SetOptions(false);
    }

    public void GetCaladbolg(bool otherRewards = false)
    {
        string[] target = otherRewards ? new[] { "Caladbolg", "Caladboogly", "Dual Caladbolgs" } : new[] { "Caladbolg" };
        if (Core.CheckInventory(target))
            return;

        if (!Core.CheckInventory("Altar Of Caladbolg"))
        {
            Core.Logger("This bot requires you to have a \"Altar Of Caladbolg\". Stopping the bot.", messageBox: true);
            return;
        }

        if (!Core.CheckInventory("Legion Titan"))
        {
            if (!Core.CheckInventory("Essence of the Undead Legend"))
            {
                Core.Logger("This bot requires you to have a \"Essence of the Undead Legend\" (Seasonal - March). Stopping the bot.", messageBox: true);
                return;
            }
            if (!Core.CheckInventory("Undead Legend"))
            {
                if (!Core.CheckInventory("Undead Legion Overlord"))
                {
                    Legion.FarmLegionToken(300);
                    Adv.BuyItem("underworld", 238, "Undead Legion Overlord");
                }

                Legion.FarmLegionToken(200);
                Adv.BuyItem("underworld", 238, "Undead Legend");
            }

            Adv.BuyItem("underworld", 238, "Legion Titan");
        }
        int QuestID = Core.CheckInventory(11953) ? 1960 : 3419;
        Core.AddDrop(Core.EnsureLoad(QuestID).Rewards.Select(x => x.Name).ToArray());

        Core.RegisterQuests(QuestID);
        while (!Bot.ShouldExit && !Core.CheckInventory(target))
        {
            Legion.FarmLegionToken(5);
            while (!Bot.ShouldExit && !Bot.TempInv.Contains(13148))
                Core.KillMonster("underworld", "r9", "Left", "Dark Makai");
            Bot.Wait.ForQuestComplete(QuestID);
        }
        Core.CancelRegisteredQuests();
    }
}
