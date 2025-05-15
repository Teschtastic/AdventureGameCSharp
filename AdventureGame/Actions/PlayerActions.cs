using AdventureGame.Game;
using AdventureGame.Items;
using AdventureGame.NPCs;
using AdventureGame.Rooms;
using AdventureGame.save;
using Foundation;

namespace AdventureGame.Actions
{
    public class PlayerActions
    {
        /* Method to display your inventory */
        public static void Inventory(GameObject game)
        {
            var inventory = game.GetItemsInInventory();
            var player = game.Player;

            if (inventory == null || inventory.Count == 0)
                Console.WriteLine("\nYour inventory is empty.");
            else
            {
                Console.WriteLine("\nYour inventory contains:");
                foreach (var i in inventory)
                {
                    string equipped = i.Name == player.EquippedWeapon || i.Name == player.EquippedArmor ? "*" : "";
                    Console.WriteLine($" - {equipped}\t{i.Name}");
                }
            }
        }

        /* Method to print the help menu */
        public static void Help(Dictionary<int, List<string>> userActions)
        {
            Console.WriteLine("\n/* ~ This is the help screen ~ */\nActions that you have access to:");
            foreach (var entry in userActions)
            {
                Console.WriteLine(" -> " + string.Join(',', entry.Value));
            }
        }

        /* Method used to describe the player character */
        public static void DescribePlayer(Player.Player player)
        {
            Console.WriteLine(player.ToString());
        }

        /* Method used to use something, whether it's an item or furniture */
        public static void UseSomething(GameObject game)
        {
            string question = "\nWhat would you like to use?\n";
            List<string> optionNums = ["1", "2", "3", "0"];
            List<string> optionChoices = ["Item in inventory", "Item in room", "Furniture in room", "Exit using"];

            GameGlobals.PresentMenu(question, Globals.EChoiceType.Command, optionNums, optionChoices);
            /*message.AppendMessageData(*/GameGlobals.ReadInput(optionNums, out int userChoice);

            if (userChoice > int.MinValue)
            {
                switch (userChoice)
                {
                    case 1:
                        ItemActions.UseInventoryItem(game);
                        break;
                    case 2:
                        RoomActions.UseItemInRoom(game);
                        break;
                    case 3:
                        FurnitureActions.UseFurniture(game);
                        break;
                    case 0:
                        Console.WriteLine("\nYou decide to use nothing.");
                        break;


                }
            }
        }

        /* Method used to use something, whether it's an item or furniture */
        public static void DescribeSomething(GameObject game)
        {
            string question = "\nWhat would you like to describe?\n";
            List<string> optionNums = ["1", "2", "3", "0"];
            List<string> optionChoices = ["Item", "Furniture in room", "NPC in room", "Exit describing"];

            GameGlobals.PresentMenu(question, Globals.EChoiceType.Command, optionNums, optionChoices);
            /*message.AppendMessageData(*/GameGlobals.ReadInput(optionNums, out int userChoice);

            if (userChoice > int.MinValue)
            {
                switch (userChoice)
                {
                    case 1:
                        ItemActions.DescribeItem(game);
                        break;
                    case 2:
                        FurnitureActions.DescribeFurniture(game);
                        break;
                    case 3:
                        NPCActions.DescribeNPC(game);
                        break;
                    case 0:
                        Console.WriteLine("\nYou decide to describe nothing.");
                        break;
                }
            }
        }

        /* Method used to access inventory and return an item from it */
        public static string TakeItemFromInventory(List<string> inventoryNames)
        {

            // Nothing in inventory to drop
            if (inventoryNames == null || inventoryNames.Count == 0)
            {
                Console.WriteLine("\nThere are no items available.");
            }
            else if (inventoryNames != null && inventoryNames.Count == 1)
            {
                return inventoryNames.First();
            }
            // Multiple items in inventory, choose which one to drop
            else if (inventoryNames != null && inventoryNames.Count > 1)
            {
                int i = 1;
                int size = inventoryNames.Count;

                Console.WriteLine("\nThe items available to you are:\n");

                Console.WriteLine(" ~~~~~~~~~~~~~~~~~~~~~~~~~");

                foreach (string it in inventoryNames)
                {
                    Console.WriteLine(" | " + i++ + " - " + it);
                }

                Console.WriteLine(" | 0 - Nothing");
                Console.WriteLine(" ~~~~~~~~~~~~~~~~~~~~~~~~~");
                Globals.ItemChoice();

                try
                {
                    string itemDesc = Console.ReadLine() ?? "";
                    int itemChoice = -1;

                    if (int.TryParse(itemDesc, out itemChoice))
                    {
                        if (itemChoice > 0 && itemChoice <= size)
                        {
                            return inventoryNames[itemChoice - 1];
                        }
                        else if (itemChoice == 0)
                        {
                            Console.WriteLine("\nYou choose nothing.");
                        }
                        else
                        {
                            Console.WriteLine("\nInvalid choice.");
                        }
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("\n Invalid input.");
                }
            }
            return "";
        }

        public static void SaveGame(GameObject game)
        {
            SaveToFile.SavePlayerToFile(game.Player);
            SaveToFile.SaveRoomsToFile(game.GetRoomsDictionary());
            SaveToFile.SaveContainersToFile(game.GetContainersDictionary());
            SaveToFile.SaveNPCsToFile(game.GetNPCDictionary());
            SaveToFile.SaveGameObjectToFile(game);

            Globals.SaveMessage();
        }
    }
}