using AdventureGame.Items;
using AdventureGame.Rooms;
using AdventureGame.Globals;

namespace AdventureGame.Actions
{
    public class ItemActions
    {
        /* Method used to describe an item in your inventory */
        public static void DescribeItem(Player.Player player)
        {
            List<string> itemsToDescribe = new();
            List<Item>? inventory = AllObjects.allItems.GetItems(player.Inventory);

            Item? itemInRoom = AllObjects.allItems.GetItem(AllObjects.allRooms.GetRoom(player.RoomIsIn).ItemInRoom);

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
                Item item = AllObjects.allItems.GetItem(PlayerActions.TakeItemFromInventory(itemsToDescribe));

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
        public static void PickupItem(Player.Player player)
        {
            Room room = AllObjects.allRooms.GetRoom(player.RoomIsIn);

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
                    Item item = AllObjects.allItems.GetItem(room.ItemInRoom);

                    if (item != null)
                    {
                        // The item can be picked up, so remove it from the room and remove the room tag for the item
                        // then add the item to the players inventory
                        if (item.CanPickup)
                        {
                            if ((player.CurrentCarryWeight + item.ItemWeight) > player.MaximumCarryWeight)
                            {
                                Console.WriteLine("\nYour inventory is too full to pickup\nthe " + item.Name);
                            }
                            else
                            {
                                Console.WriteLine("\nYou pickup the " + item.Name);
                                room.HasItem = false;
                                room.ItemInRoom = "";
                                player.AddToInventory(item);
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
        public static void DropItem(Player.Player player)
        {
            Room room = AllObjects.allRooms.GetRoom(player.RoomIsIn);

            if (room != null && !room.HasItem)
            {
                Item item = AllObjects.allItems.GetItem(PlayerActions.TakeItemFromInventory(player.Inventory));

                if (item != null)
                {
                    Console.WriteLine("\nYou drop your " + item.Name);

                    room.HasItem = true;
                    room.ItemInRoom = item.Name;
                    player.RemoveFromInventory(item);
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

                string? dropChoice = Console.ReadLine();

                if (dropChoice != null && dropChoice == "1")
                {
                    PickupItem(player);
                    DropItem(player);
                }
                else
                {
                    Console.WriteLine("\nYou don't pick up the item in the room.\nYou don't drop the item.");
                }
            }
        }

        /* Method used to use an item in either your inventory or in the world */
        public static void UseInventoryItem(Player.Player player)
        {
            Item item = AllObjects.allItems.GetItem(PlayerActions.TakeItemFromInventory(player.Inventory));

            // If the item has the can use flag, use it and remove
            // it from the player's inventory
            if (item != null && item.CanUse)
            {
                Console.WriteLine(item.UseMessage);
                UsedItemOnPlayer.UseItem(player, item);
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

        public static void EquipItem(Player.Player player)
        {
            List<Item> playerInventory = AllObjects.allItems.GetItems(player.Inventory);
            List<string> weaponArmorInventory = new();
            Item item;

            foreach (Item i in playerInventory)
            {
                if (i.IsArmor || i.IsWeapon)
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

                string? equipChoice = Console.ReadLine();

                item = AllObjects.allItems.GetItem(PlayerActions.TakeItemFromInventory(weaponArmorInventory));

                if (item != null)
                {
                    if (equipChoice == "1")
                    {
                        if (item.IsArmor)
                        {
                            if (player.HasEquippedArmor)
                            {
                                Console.WriteLine("\nYou already have equipped armor.");
                            }
                            else
                            {
                                EquipItemToPlayer.EquipArmor(player, (Armor)item);
                            }
                        }
                        else
                        {
                            Console.WriteLine("\nCannot equip item, it is not an armor.");
                        }
                    }
                    else if (equipChoice == "2")
                    {
                        if (item.IsWeapon)
                        {
                            if (player.HasEquippedWeapon)
                            {
                                Console.WriteLine("\nYou already have an equipped weapon.");
                            }
                            else
                            {
                                EquipItemToPlayer.EquipWeapon(player, (Weapon)item);
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

        public static void UnEquipItem(Player.Player player)
        {
            if (!player.HasEquippedArmor && !player.HasEquippedWeapon)
            {
                Console.WriteLine("\nYou don't have anything equipped.");
            }
            else
            {
                Console.WriteLine("\nWhat would you like to un equip?");
                Console.WriteLine("\n1 - Armor\n2 - Weapon\n0 - Nothing");
                Actions.CommandChoice();

                string? unequipChoice = Console.ReadLine();

                if (unequipChoice == "1")
                {
                    if (player.HasEquippedArmor)
                    {
                        Armor armor = (Armor)AllObjects.allItems.GetItem(player.EquippedArmor);
                        UnEquipItemFromPlayer.UnEquipArmor(player, armor);
                    }
                    else
                    {
                        Console.WriteLine("\nYou don't have equipped armor.");
                    }
                }
                else if (unequipChoice == "2")
                {
                    if (player.HasEquippedWeapon)
                    {
                        Weapon weapon = (Weapon)AllObjects.allItems.GetItem(player.EquippedWeapon);
                        UnEquipItemFromPlayer.UnEquipWeapon(player, weapon);
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
