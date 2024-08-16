using AdventureGame.Game;
using AdventureGame.Items;
using AdventureGame.Rooms;

namespace AdventureGame.Actions
{
    public class RoomActions
    {
        /* Method to display which room you're in */
        public static void PrintLocation(GameObject game)
        {
            Room room = game.GetRoomPlayerIsIn();
            Console.WriteLine($"{room.InMessage}\n{room.GetMoves()}");
        }

        /* Method used to change rooms */
        public static void Move(GameObject game)
        {
            string move = game.GetPlayerMove();
            Room currentRoom = game.GetRoomPlayerIsIn();

            string moveRoom;
            if (!currentRoom.ConnRooms.TryGetValue(move, out moveRoom!))
            {
                Console.WriteLine("\nInvalid direction.");
            }
            else
            {
                if (moveRoom == "")
                {
                    Console.WriteLine("\nCouldn't move that way.");
                }
                else
                {
                    Room newRoom = game.GetRoom(moveRoom);

                    Console.WriteLine($"\nYou went {move}\n{currentRoom.LeaveMessage}\n{newRoom.EnterMessage}");
                    game.SetRoomPlayerIsIn(newRoom.Name);

                    if(newRoom.HasAliveEnemy(game))
                    {
                        NPCActions.BattleNPC(game);
                    }
                }
            }
        }

        /* Method used to look in the room you're in */
        public static void LookAround(GameObject game)
        {
            Room room = game.GetRoomPlayerIsIn();
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

        public static void UseItemInRoom(GameObject game)
        {
            Room room = game.GetRoomPlayerIsIn();

            if (room.HasItem)
            {
                Item item = game.GetItemInRoom()!;
                item.UseItem(game);
            }
            else
            {
                Console.WriteLine("\nThere is no item in the room to use.");
            }
        }
    }
}
