using AdventureGame.Globals;
using AdventureGame.Items;
using AdventureGame.Rooms;

namespace AdventureGame.Actions
{
    public class RoomActions
    {
        /* Method to display which room you're in */
        public static void PrintLocation(Player.Player player)
        {
            Room room = AllObjects.allRooms.GetRoom(player.RoomIsIn);
            Console.WriteLine(room.InMessage);
            Console.WriteLine(room.GetMoves());
        }

        /* Method used to change rooms */
        public static void Move(Player.Player player, string move)
        {
            Room currentRoom = AllObjects.allRooms.GetRoom(player.RoomIsIn);
            Room newRoom;

            foreach (var room in currentRoom.ConnRooms)
            {
                if (room.Value != "" && room.Key.Equals(move))
                {
                    newRoom = AllObjects.allRooms.GetRoom(room.Value);
                    Console.WriteLine("\nYou went " + room.Key + "\n");
                    Console.WriteLine(currentRoom.LeaveMessage);
                    Console.WriteLine(newRoom.EnterMessage);
                    player.RoomIsIn = newRoom.Name;
                    return;
                }
            }

            // If you can't move, tells you so
            Console.WriteLine("\nCouldn't move that way.");
        }

        /* Method used to look in the room you're in */
        public static void LookAround(Player.Player player)
        {
            Room room = AllObjects.allRooms.GetRoom(player.RoomIsIn);
            Console.WriteLine(room.InMessage);

            if (!room.HasItem)
            {
                Console.WriteLine("\nYou don't see any items.");
            }
            else
            {
                Console.WriteLine("\nYou see the " + room.ItemInRoom);
            }

            if (!room.HasNPC)
            {
                Console.WriteLine("You don't see any people.");
            }
            else
            {
                Console.WriteLine("You see " + room.NPCInRoom);
            }

            if (!room.HasFurniture)
            {
                Console.WriteLine("You don't see any furniture.");
            }
            else
            {
                Console.WriteLine("You see the " + room.FurnitureInRoom);
            }
        }

        public static void UseItemInRoom(Player.Player player)
        {
            Room room = AllObjects.allRooms.GetRoom(player.RoomIsIn);
            Item item = AllObjects.allItems.GetItem(room.ItemInRoom);

            if (room.HasItem)
            {
                if (item.CanUse)
                {
                    Console.WriteLine(item.UseMessage);
                    UsedItemOnPlayer.UseItem(player, item);
                }
                else
                {
                    Console.WriteLine("\nYou can't use the " + item.Name);
                }
            }
            else
            {
                Console.WriteLine("\nThere is no item in the room to use.");
            }
        }
    }
}
