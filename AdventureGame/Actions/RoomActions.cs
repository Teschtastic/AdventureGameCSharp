using AdventureGame.Game;
using AdventureGame.Items;
using AdventureGame.NPCs;
using AdventureGame.Rooms;

namespace AdventureGame.Actions
{
    public class RoomActions
    {
        /* Method to display which room you're in */
        public static void PrintLocation(GameObject game)
        {
            Room room = game.GetRoomPlayerIsIn();
            Console.WriteLine(room.InMessage);
            Console.WriteLine(room.GetMoves());
        }

        /* Method used to change rooms */
        public static void Move(GameObject game)
        {
            string move = game.GetPlayerMove();
            string moveRoom = "";

            Room currentRoom = game.GetRoomPlayerIsIn();

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

                    Console.WriteLine("\nYou went " + move + "\n");
                    Console.WriteLine(currentRoom.LeaveMessage);
                    Console.WriteLine(newRoom.EnterMessage);
                    game.SetRoomPlayerIsIn(newRoom.Name);

                    if (newRoom.HasNPC)
                    {

                        NPC npc = game.GetNPCInRoom();

                        if (newRoom.IsAliveNPCInRoom(npc) && npc.IsNPCAnEnemy())
                        {
                            NPCActions.BattleNPC(game);
                        }
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
            Item item = game.GetItemInRoom();

            if (room.HasItem)
            {
                if (item.CanUse)
                {
                    Console.WriteLine(item.UseMessage);
                    UsedItemOnPlayer.UseItem(game, item);
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
