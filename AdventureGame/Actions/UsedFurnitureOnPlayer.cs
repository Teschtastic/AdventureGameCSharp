﻿using AdventureGame.Crafting;
using AdventureGame.Furnitures;
using AdventureGame.Globals;
using AdventureGame.Items;
using AdventureGame.NPCs;
using AdventureGame.Rooms;

namespace AdventureGame.Actions
{
    internal class UsedFurnitureOnPlayer
    {
        // Use furniture method with a switch case for the different furnitures with uses
        public static void UseFurniture(Player.Player player)
        {
            Room room = AllObjects.allRooms.GetRoom(player.RoomIsIn);
            string furniture = room.FurnitureInRoom;

            switch (furniture)
            {
                case "Camping chair":
                    UsedCampingChair(player);
                    break;

                case "Bed":
                    UsedBed(player);
                    break;

                case "Crafting Table":
                    UseCraftingTable(player);
                    break;

                case "Sink":
                    UseSink(player);
                    break;

                case "Chest":

                case "Trash":

                case "Closet":

                case "Refrigerator":
                    UseContainer(player, furniture + " in " + room.Name);
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
        private static void UsedBed(Player.Player player)
        {
            NPC npc;
            Room room = AllObjects.allRooms.GetRoom(player.RoomIsIn);

            if (room.HasNPC)
            {
                npc = AllObjects.allNPCs.GetNPC(room.NPCInRoom);

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
        private static void UseCraftingTable(Player.Player player)
        {
            string craftedItem;
            List<string> inventory = player.Inventory;
            List<Recipe> recipes = AllObjects.allRecipes.GetRecipes(player.KnownRecipes);

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

                string? craftChoice = Console.ReadLine();

                if (craftChoice != null)
                {
                    if (craftChoice == "0")
                    {
                        Console.WriteLine("\nYou exit crafting");
                    }
                    else
                    {
                        // Checks if the players inventory contains the necessary items
                        // to craft the chosen recipe, then crafts
                        Recipe? recipe = AllObjects.allRecipes.GetRecipe(recipes[int.Parse(craftChoice) - 1].OutputItem);

                        if (recipe != null)
                        {
                            if (recipe.CanCraft(inventory))
                            {

                                List<string> craftingItems = recipe.InputItems;
                                craftedItem = recipe.OutputItem;

                                foreach (Item it in AllObjects.allItems.GetItems(craftingItems))
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

        private static void UseSink(Player.Player player)
        {
            var inv = player.Inventory;

            if (inv.Contains("Empty Bottle"))
            {
                Console.WriteLine("\nYou fill up a bottle with water.");
                player.RemoveFromInventory("Empty Bottle");
                player.AddToInventory("Water Bottle");
            }
            else
            {
                Console.WriteLine("\nYou watch the water flow.\nThen turn off the sink.");
            }
        }

        // Method for using a container
        private static void UseContainer(Player.Player player, string furniture)
        {
            Container container = (Container)AllObjects.allFurnitures.GetFurniture(furniture);

            if (container.FirstOpen == false && container.Lut != "")
            {
                LUTActions.ProcessLUT(container);
            }

            // Prints an options menu
            Console.WriteLine("\n *************************************");
            Console.WriteLine("\n How will you use the " + container.Name + "?");
            Console.WriteLine(
                            "\n 1 - View " + container.Name + "'s inventory" +
                            "\n 2 - Take item from" +
                            "\n 3 - Put item into" +
                            "\n 0 - Exit furniture");
            Console.WriteLine("\n *************************************");
            Actions.ContainerChoice();

            List<string> containerInventory = container.InventoryNames;
            string? containerChoice = Console.ReadLine();

            // This either shows the container's inventory or that it is empty
            if (containerChoice != null)
            {
                if (containerChoice == "1")
                {
                    if (containerInventory.Count == 0)
                        Console.WriteLine("\nThe " + container.Name + " is empty.");
                    else
                    {
                        Console.WriteLine("\n *************************************");
                        Console.WriteLine("\n Inside the " + container.Name + " you see:\n");
                        foreach (string it in containerInventory)
                        {
                            Console.WriteLine(" - " + it);
                        }
                        Console.WriteLine("\n *************************************");
                    }
                }
                // Used for taking item(s) from inventory
                else if (containerChoice == "2")
                {
                    Console.WriteLine("\n *************************************");
                    Console.WriteLine("\n What would you like to take: \n");
                    int i = 1;
                    int totalWeight = 0;
                    Item item;

                    // Choice for which item to take: one, all, or none
                    foreach (string it in containerInventory)
                    {
                        Console.WriteLine(" " + i++ + " - " + it);
                    }
                    Console.WriteLine(" 0 - Take all\n -1 - Take nothing");
                    Console.WriteLine("\n *************************************");
                    Actions.ContainerChoice();

                    string? itemIndex = Console.ReadLine();

                    if (itemIndex != null)
                    {
                        // Takes all the items from the container
                        if (itemIndex == "0")
                        {
                            foreach (string it in containerInventory)
                            {
                                totalWeight += AllObjects.allItems.GetItem(it).ItemWeight;
                            }
                            if ((player.CurrentCarryWeight + totalWeight) < player.MaximumCarryWeight)
                            {
                                Console.WriteLine("\n You take all of the items");
                                player.AddToInventory(containerInventory);
                                container.RemoveFromInventory(containerInventory);
                            }
                            else
                            {
                                Console.WriteLine(" \nYour inventory is too full to take \nthe items from the " + container.Name);
                            }
                        }
                        // Take nothing
                        else if (itemIndex == "-1")
                        {
                            Console.WriteLine("\n You decided to take nothing");
                        }
                        // Takes the item the player chose from the inventory
                        else
                        {
                            item = AllObjects.allItems.GetItem(containerInventory[int.Parse(itemIndex) - 1]);
                            if ((player.CurrentCarryWeight + item.ItemWeight) < player.MaximumCarryWeight)
                            {
                                Console.WriteLine("\n You take the " + item.Name);
                                player.AddToInventory(item);
                                container.RemoveFromInventory(item);
                            }
                            else
                            {
                                Console.WriteLine("\n Your inventory is too full to take\n the " + item.Name);
                            }
                        }
                    }
                }
                // Puts an item from the inventory into the container
                else if (containerChoice == "3")
                {
                    Item item;
                    List<string> playerInventory = player.Inventory;

                    Console.WriteLine("\n *************************************");
                    Console.WriteLine("\n What would you like to place: \n");
                    Console.WriteLine(
                                "\n 1 - Single inventory item" +
                                "\n 2 - All inventory items" +
                                "\n 0 - Exit putting item");

                    Console.WriteLine("\n *************************************");
                    Actions.ContainerChoice();

                    string? itemIndex = Console.ReadLine();

                    if (itemIndex != null)
                    {
                        if (itemIndex == "1")
                        {
                            item = AllObjects.allItems.GetItem(PlayerActions.TakeItemFromInventory(player.Inventory));

                            if (item != null)
                            {
                                Console.WriteLine(
                                        "\n You remove the " + item.Name + " from " +
                                        "\n your inventory and place it into the\n" + container.Name);

                                container.AddToInventory(item);
                                player.RemoveFromInventory(item);
                            }
                        }
                        else if (itemIndex == "2")
                        {
                            Console.WriteLine(
                                            "\n You place all your items" +
                                            "\n into the " + container.Name);

                            container.AddToInventory(playerInventory);
                            player.RemoveFromInventory(playerInventory);
                        }
                    }
                }
                else if (containerChoice == "0")
                {
                    Console.WriteLine("\n You left the " + container.Name);
                }
            }
            else
            {
                Console.WriteLine("\n Invalid choice.");
            }
        }
    }
}
