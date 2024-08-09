using AdventureGame.Game;
using AdventureGame.Items;
using AdventureGame.save;

namespace AdventureGame.Actions
{
    public class PlayerActions
    {
        /* Method to display your inventory */
        public static void Inventory(List<Item> inventory)
        {
            if (inventory == null || inventory.Count == 0)
                Console.WriteLine("\nYour inventory is empty.");
            else
            {
                Console.WriteLine("\nYour inventory contains:");
                foreach (var i in inventory)
                    Console.WriteLine(" - " + i.Name);
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
            Console.WriteLine(
                    "\nWhat would you like to use?\n" +
                            "\n1 - Item in inventory" +
                            "\n2 - Item in room" +
                            "\n3 - Furniture in room" +
                            "\n0 - Exit using\n");

            Actions.CommandChoice();

            string useChoice = Console.ReadLine() ?? "";

            if (useChoice != "")
            {
                if (useChoice == "1")
                {
                    ItemActions.UseInventoryItem(game);
                }
                else if (useChoice == "2")
                {
                    RoomActions.UseItemInRoom(game);
                }
                else if (useChoice == "3")
                {
                    FurnitureActions.UseFurniture(game);
                }
                else if (useChoice == "0")
                {
                    Console.WriteLine("\nYou decide to use nothing.");
                }
                else
                {
                    Console.WriteLine("\nInvalid choice.");
                }
            }
            else
            {
                Console.WriteLine("\nInvalid input.");
            }
        }

        /* Method used to use something, whether it's an item or furniture */
        public static void DescribeSomething(GameObject game)
        {
            Console.WriteLine(
                    "\nWhat would you like to describe?\n" +
                    "\n1 - Item" +
                    "\n2 - Furniture in room" +
                    "\n3 - NPC in room" +
                    "\n0 - Exit describing\n");
            Actions.CommandChoice();

            string describeChoice = Console.ReadLine() ?? "";

            if (describeChoice != "")
            {

                if (describeChoice == "1")
                {
                    ItemActions.DescribeItem(game);
                }
                else if (describeChoice == "2")
                {
                    FurnitureActions.DescribeFurniture(game);
                }
                else if (describeChoice == "3")
                {
                    NPCActions.DescribeNPC(game);
                }
                else if (describeChoice == "0")
                {
                    Console.WriteLine("\nYou decide to describe nothing.");
                }
                else
                {
                    Console.WriteLine("\nInvalid choice.");
                }
            }
            else
            {
                Console.WriteLine("\nInvalid input.");
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
                Actions.ItemChoice();

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

            Actions.SaveMessage();
        }
    }
}