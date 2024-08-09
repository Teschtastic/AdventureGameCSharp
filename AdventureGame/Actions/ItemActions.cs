using AdventureGame.Items;
using AdventureGame.Rooms;
using AdventureGame.Game;

namespace AdventureGame.Actions
{
    public class ItemActions
    {
        /* Method used to describe an item in your inventory */
        public static void DescribeItem(GameObject game)
        {
            List<string> itemsToDescribe = new();
            List<Item> inventory = game.GetItemsInInventory();

            Item? itemInRoom = game.GetItemInRoom();

            if (inventory != null && inventory.Count > 0)
            {
                foreach (Item item in inventory)
                {
                    itemsToDescribe.Add(item.Name);
                }
            }
            if (itemInRoom != null)
            {
                itemsToDescribe.Add(itemInRoom.Name);
            }

            if (itemsToDescribe.Count == 0)
            {
                Console.WriteLine("\nThere are no items to describe.");
            }
            else
            {
                Item? item = game.GetItemInInventory(itemsToDescribe);

                if (item != null)
                {
                    Console.WriteLine(
                        "\nYou inspect the "        + item.Name         +
                        "\n\nYou describe it as:\n" + item.Description  +
                        "\n\nWith a weight of: "    + item.ItemWeight);
                }
            }
        }

        /* Method used for attempting to pick up an item */
        public static void PickupItem(GameObject game)
        {
            Room room = game.GetRoomPlayerIsIn();

            if (room != null)
            {
                // If there isn't an item in the room, nothing to pickup
                if (!room.HasItem)
                {
                    Console.WriteLine("\nThere is no item to pickup.");
                }
                // This means there is something in the room
                else if (room.HasItem)
                {
                    Item? item = game.GetItemInRoom();

                    if (item != null)
                    {
                        // The item can be picked up, so remove it from the room and remove the room tag for the item
                        // then add the item to the players inventory
                        if (item.CanPickup)
                        {
                            if ((game.Player.CurrentCarryWeight + item.ItemWeight) > game.Player.MaximumCarryWeight)
                            {
                                Console.WriteLine("\nYour inventory is too full to pickup\nthe " + item.Name);
                            }
                            else
                            {
                                Console.WriteLine("\nYou pickup the " + item.Name);
                                room.HasItem = false;
                                room.ItemInRoom = "";
                                game.Player.AddToInventory(item);
                            }

                        }
                        // Otherwise, the item isn't able to be picked up
                        else
                        {
                            Console.WriteLine("\nYou can't pickup the " + item.Name);
                        }
                    }
                }
            }
        }

        /* Method used to drop and item in your inventory */
        public static void DropItem(GameObject game)
        {
            Room room = game.GetRoomPlayerIsIn();

            if (room != null && !room.HasItem)
            {
                Item? item = game.GetItemInInventory(game.Player.Inventory);

                if (item != null)
                {
                    Console.WriteLine("\nYou drop your " + item.Name);

                    room.HasItem = true;
                    room.ItemInRoom = item.Name;
                    game.Player.RemoveFromInventory(item);
                }
                else
                {
                    Console.WriteLine("\nYou drop nothing.");
                }
            }
            else
            {
                Console.WriteLine("\nThere is already an item in the room.\nWould you like to pick that item up?");
                Console.WriteLine("\n1 - Yes\n0 - No");
                Actions.CommandChoice();

                string dropChoice = Console.ReadLine() ?? "";

                if (dropChoice == "1")
                {
                    PickupItem(game);
                    DropItem(game);
                }
                else
                {
                    Console.WriteLine("\nYou don't pick up the item in the room.\nYou don't drop the item.");
                }
            }
        }

        /* Method used to use an item in either your inventory or in the world */
        public static void UseInventoryItem(GameObject game)
        {
            Item? item = game.GetItemInInventory(game.GetItemsInInventory());

            // If the item has the can use flag, use it and remove
            // it from the player's inventory
            if (item != null && item.CanUse)
            {
                Console.WriteLine(item.UseMessage);
                UsedItemOnPlayer.UseItem(game, item);
            }
            else if (item != null && !item.CanUse)
            {
                Console.WriteLine("\nYou can't use " + item.Name);
            }
            else
            {
                Console.WriteLine("\nNo item to use.");
            }
        }

        public static void EquipItem(GameObject game)
        {
            List<Item> playerInventory = game.GetItemsInInventory();
            List<string> weaponArmorInventory = new();
            Item? item;

            foreach (Item i in playerInventory)
            {
                if (i.KindOfItem == Item.ItemType.Armor || i.KindOfItem == Item.ItemType.Weapon)
                {
                    weaponArmorInventory.Add(i.Name);
                }
            }

            if (playerInventory.Count == 0)
            {
                Console.WriteLine("\nYour inventory is empty.");
            }
            else if (weaponArmorInventory.Count == 0)
            {
                Console.WriteLine("\nYou have no weapons or armor.");
            }
            else
            {
                Console.WriteLine("\nWhat would you like to equip?");
                Console.WriteLine("\n1 - Armor\n2 - Weapon\n0 - Nothing");
                Actions.CommandChoice();

                string equipChoice = Console.ReadLine() ?? "";

                item = game.GetItemInInventory(weaponArmorInventory);

                if (item != null)
                {
                    if (equipChoice == "1")
                    {
                        if (item.KindOfItem == Item.ItemType.Armor)
                        {
                            if (game.Player.HasEquippedArmor)
                            {
                                Console.WriteLine("\nYou already have equipped armor.");
                            }
                            else
                            {
                                game.Player.EquipArmor((Armor)item);
                                //EquipItemToPlayer.EquipArmor(game.GetPlayer(), (Armor)item);
                            }
                        }
                        else
                        {
                            Console.WriteLine("\nCannot equip item, it is not an armor.");
                        }
                    }
                    else if (equipChoice == "2")
                    {
                        if (item.KindOfItem == Item.ItemType.Weapon)
                        {
                            if (game.Player.HasEquippedWeapon)
                            {
                                Console.WriteLine("\nYou already have an equipped weapon.");
                            }
                            else
                            {
                                game.Player.EquipWeapon((Weapon)item);
                                //EquipItemToPlayer.EquipWeapon(game.GetPlayer(), (Weapon)item);
                            }
                        }
                        else
                        {
                            Console.WriteLine("\nCannot equip item, it is not a weapon.");
                        }
                    }
                    else if (equipChoice == "0")
                    {
                        Console.WriteLine("\nYou equip nothing.");
                    }
                    else
                    {
                        Console.WriteLine("\nInvalid choice.");
                    }
                }
            }
        }

        public static void UnEquipItem(GameObject game)
        {
            if (!game.Player.HasEquippedArmor && !game.Player.HasEquippedWeapon)
            {
                Console.WriteLine("\nYou don't have anything equipped.");
            }
            else
            {
                Console.WriteLine("\nWhat would you like to un equip?");
                Console.WriteLine("\n1 - Armor\n2 - Weapon\n0 - Nothing");
                Actions.CommandChoice();

                string unequipChoice = Console.ReadLine() ?? "";

                if (unequipChoice == "1")
                {
                    if (game.Player.HasEquippedArmor)
                    {
                        Armor armor = (Armor)game.GetItem(game.Player.EquippedArmor)!;
                        game.Player.UnEquipArmor(armor);
                        //UnEquipItemFromPlayer.UnEquipArmor(game.GetPlayer(), armor);
                    }
                    else
                    {
                        Console.WriteLine("\nYou don't have equipped armor.");
                    }
                }
                else if (unequipChoice == "2")
                {
                    if (game.Player.HasEquippedWeapon)
                    {
                        Weapon weapon = (Weapon)game.GetItem(game.Player.EquippedWeapon)!;
                        game.Player.UnEquipWeapon(weapon);
                        //UnEquipItemFromPlayer.UnEquipWeapon(game.GetPlayer(), weapon);
                    }
                    else
                    {
                        Console.WriteLine("\nYou don't have an equipped weapon.");
                    }
                }
                else if (unequipChoice == "0")
                {
                    Console.WriteLine("\nYou un-equip nothing.");
                }
                else
                {
                    Console.WriteLine("\nInvalid choice.");
                }
            }
        }
    }
}
