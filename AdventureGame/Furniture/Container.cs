using AdventureGame.Actions;
using AdventureGame.Game;
using AdventureGame.Items;

namespace AdventureGame.Furnitures
{
    public class Container(string n, string d, string uMessage, bool cUse, bool firstOpen, string lut) : Furniture(n, d, uMessage, cUse)
    {
        public List<string> InventoryNames { get; set; } = [];
        public bool FirstOpen { get; set; } = firstOpen;
        public string Lut { get; set; } = lut;

        public void AddToInventory(Item item)
        {
            InventoryNames.Add(item.Name);
        }

        public void AddToInventory(string itemName)
        {
            InventoryNames.Add(itemName);
        }

        public void AddToInventory(List<Item> items)
        {
            foreach (Item item in items)
            {
                AddToInventory(item);
            }
        }

        public void AddToInventory(List<string> itemNames)
        {
            foreach (string itemName in itemNames)
            {
                AddToInventory(itemName);
            }
        }

        public void RemoveFromInventory(Item item)
        {
            InventoryNames.Remove(item.Name);
        }

        public void RemoveFromInventory(string itemName)
        {
            InventoryNames.Remove(itemName);
        }


        public void RemoveFromInventory(List<Item> items)
        {
            foreach (Item item in items)
            {
                RemoveFromInventory(item);
            }
        }

        public void RemoveFromInventory(List<string> itemNames)
        {
            foreach (string itemName in itemNames.ToList())
            {
                RemoveFromInventory(itemName);
            }
        }

        public void UseContainer(GameObject game)
        {
            Player.Player player = game.Player;
            Container container = this;

            if (container.FirstOpen == false && container.Lut != "")
            {
                LUTActions.ProcessLUT(game, container);
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
            Actions.Actions.ContainerChoice();

            List<Item> containerInventory = game.GetItems(container.InventoryNames);
            string containerChoice = Console.ReadLine() ?? "";

            // This either shows the container's inventory or that it is empty
            if (containerChoice != "")
            {
                if (containerChoice == "1")
                {
                    if (containerInventory.Count == 0)
                        Console.WriteLine("\nThe " + container.Name + " is empty.");
                    else
                    {
                        Console.WriteLine("\n *************************************");
                        Console.WriteLine("\n Inside the " + container.Name + " you see:\n");
                        foreach (Item it in containerInventory)
                        {
                            Console.WriteLine(" - " + it.Name);
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
                    foreach (Item it in containerInventory)
                    {
                        Console.WriteLine(" " + i++ + " - " + it.Name);
                    }
                    Console.WriteLine(" 0 - Take all\n -1 - Take nothing");
                    Console.WriteLine("\n *************************************");
                    Actions.Actions.ContainerChoice();

                    string itemIndex = Console.ReadLine() ?? "";

                    if (itemIndex != "")
                    {
                        // Takes all the items from the container
                        if (itemIndex == "0")
                        {
                            foreach (Item it in containerInventory)
                            {
                                totalWeight += it.ItemWeight;
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
                            item = game.GetItem(containerInventory[int.Parse(itemIndex) - 1].Name)!;
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
                    Item? item;
                    List<Item> playerInventory = game.GetItems(player.Inventory);

                    Console.WriteLine("\n *************************************");
                    Console.WriteLine("\n What would you like to place: \n");
                    Console.WriteLine(
                                "\n 1 - Single inventory item" +
                                "\n 2 - All inventory items" +
                                "\n 0 - Exit putting item");

                    Console.WriteLine("\n *************************************");
                    Actions.Actions.ContainerChoice();

                    string itemIndex = Console.ReadLine() ?? "";

                    if (itemIndex != "")
                    {
                        if (itemIndex == "1")
                        {
                            item = game.GetItem(PlayerActions.TakeItemFromInventory(player.Inventory));

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