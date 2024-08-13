using AdventureGame.Crafting;
using AdventureGame.Furnitures;
using AdventureGame.Game;
using AdventureGame.Items;
using AdventureGame.NPCs;
using AdventureGame.Rooms;

namespace AdventureGame.Actions
{
    internal class UsedFurnitureOnPlayer
    {
        // Use furniture method with a switch case for the different furnitures with uses
        public static void UseFurniture(GameObject game)
        {
            Room room = game.GetRoom(game.Player.RoomIsIn);
            Furniture furniture = game.GetFurnitureInRoom();

            switch (furniture.Name)
            {
                case "Camping chair":
                    UsedCampingChair(game.Player);
                    break;

                case "Bed":
                    UsedBed(game, room);
                    break;

                case "Crafting Table":
                    UseCraftingTable(game);
                    break;

                case "Sink":
                    UseSink(game);
                    break;

                case "Chest":

                case "Trash":

                case "Closet":

                case "Refrigerator":
                    ((Container)furniture).UseContainer(game);
                    break;

                default:
                    Console.WriteLine("\nThis doesn't seem to help you");
                    break;
            }
        }

        // Method for using the camping chair
        private static void UsedCampingChair(Player.Player player)
        {
            // Heals the player
            Console.WriteLine("\nYour health has been restored.");
            player.CurrentHealth = player.MaximumHealth;
        }

        // Method for using Sean's bed
        private static void UsedBed(GameObject game, Room room)
        {
            Player.Player player = game.Player;
            NPC npc;

            if (room.HasNPC)
            {
                npc = game.GetNPC(room.NPCInRoom)!;

                if (npc.IsFriendly == true)
                {
                    // If Claudia is in the room, heals and increases health
                    if (npc.Name.Equals("Claudia"))
                    {
                        Console.WriteLine(
                                        "\nYou and Claudia snuggle <3" +
                                        "\nYour max health increases by 50" +
                                        "\nand your health has been restored.");

                        player.MaximumHealth += 50;
                        player.CurrentHealth = player.MaximumHealth;
                    }
                    // Or else only increases health
                    else
                    {
                        Console.WriteLine("\nYour max health increases by 25");
                        player.MaximumHealth += 25;
                    }
                }
                else
                {
                    Console.WriteLine(
                            "\n" + npc.Name + " bites your face in your sleep." +
                                        "\nYou lose 25 health.");
                    player.CurrentHealth -= 25;
                }
            }
        }

        // Method for using the crafting table
        private static void UseCraftingTable(GameObject game)
        {
            Item craftedItem;
            Player.Player player = game.Player;
            List<string> inventory = player.Inventory;
            List<Recipe> recipes = game.GetRecipes(player.KnownRecipes);

            // Checks if the player has an empty inventory and has recipes to craft
            if (inventory.Count > 0 && recipes.Count > 0)
            {
                int i = 1;

                // Prints available recipes to craft or to exit
                Console.WriteLine("\nWhat would you like to craft?\n");
                foreach (Recipe r in recipes)
                {
                    Console.WriteLine(i++ + " - " + r.OutputItem);
                }
                Console.WriteLine("0 - Exit crafting");
                Actions.CommandChoice();

                string craftChoice = Console.ReadLine() ?? "";

                if (craftChoice != "")
                {
                    if (craftChoice == "0")
                    {
                        Console.WriteLine("\nYou exit crafting");
                    }
                    else
                    {
                        // Checks if the players inventory contains the necessary items
                        // to craft the chosen recipe, then crafts
                        Recipe? recipe = game.GetRecipe(recipes[int.Parse(craftChoice) - 1].OutputItem);

                        if (recipe != null)
                        {
                            if (recipe.CanCraft(inventory))
                            {

                                List<Item> craftingItems = game.GetItems(recipe.InputItems);
                                craftedItem = game.GetItem(recipe.OutputItem)!;

                                foreach (Item it in craftingItems)
                                {
                                    Console.WriteLine(it.UseMessage);
                                }

                                player.RemoveFromInventory(craftingItems);
                                player.AddToInventory(craftedItem);
                            }
                            else
                            {
                                Console.WriteLine("\nYou don't have the required materials.");
                            } 
                        }
                    }
                }
            }
            else
            {
                Console.WriteLine("\nYou have nothing to craft with.");
            }
        }

        private static void UseSink(GameObject game)
        {
            Player.Player player = game.Player;
            var inv = player.Inventory;
            Item item = game.GetItem("Empty Bottle")!;

            if (inv.Contains(item.Name))
            {
                Item bottle = game.GetItem("Water Bottle")!;
                Console.WriteLine("\nYou fill up a bottle with water.");
                player.RemoveFromInventory(item);
                player.AddToInventory(bottle);
            }
            else
            {
                Console.WriteLine("\nYou watch the water flow.\nThen turn off the sink.");
            }
        }
    }
}
