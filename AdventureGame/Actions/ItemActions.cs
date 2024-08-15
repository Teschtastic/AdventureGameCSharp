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
            List<string> itemsToDescribe = [];
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
                Item item = game.GetItemInInventory(itemsToDescribe)!;

                Console.WriteLine(
                    "\nYou inspect the "        + item.Name         +
                    "\n\nYou describe it as:\n" + item.Description  +
                    "\n\nWith a weight of: "    + item.ItemWeight);
            }
        }

        /* Method used for attempting to pick up an item */
        public static void PickupItem(GameObject game)
        {
            Room room = game.GetRoomPlayerIsIn();

            // If there isn't an item in the room, nothing to pickup
            if (!room.HasItem)
            {
                Console.WriteLine("\nThere is no item to pickup.");
            }
            // This means there is something in the room
            else
            {
                Item item = game.GetItemInRoom()!;

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

        /* Method used to drop and item in your inventory */
        public static void DropItem(GameObject game)
        {
            Room room = game.GetRoomPlayerIsIn();

            if (!room.HasItem)
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
            if (item != null)
            {
                item.UseItem(game);
            }
            else
            {
                Console.WriteLine("\nNo item to use.");
            }
        }
    }
}
