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

            Room currentRoom = game.GetRoomPlayerIsIn();
            Room newRoom;

            var room = currentRoom.ConnRooms.Single(x => x.Value != "" && x.Key.Equals(move));
            newRoom = game.GetRoom(room.Value);
            Console.WriteLine("\nYou went " + room.Key + "\n");
            Console.WriteLine(currentRoom.LeaveMessage);
            Console.WriteLine(newRoom.EnterMessage);
            game.SetRoomPlayerIsIn(newRoom.Name);

            //Room room = AllObjects.allRooms.GetRoom(game.GamePlayer.RoomIsIn);
            NPC npc = game.GetNPCInRoom();

            if (newRoom.IsAliveNPCInRoom(npc) && npc.IsNPCAnEnemy())
            {
                NPCActions.BattleNPC(game);
            }
            return;

            //foreach (var room in currentRoom.ConnRooms)
            //{
            //    if (room.Value != "" && room.Key.Equals(move))
            //    {
            //        newRoom = AllObjects.allRooms.GetRoom(room.Value);
            //        Console.WriteLine("\nYou went " + room.Key + "\n");
            //        Console.WriteLine(currentRoom.LeaveMessage);
            //        Console.WriteLine(newRoom.EnterMessage);
            //        game.GamePlayer.RoomIsIn = newRoom.Name;

            //        //Room room = AllObjects.allRooms.GetRoom(game.GamePlayer.RoomIsIn);
            //        NPC npc = AllObjects.allNPCs.GetNPC(newRoom.NPCInRoom);

            //        if (newRoom.IsAliveNPCInRoom(npc) && npc.IsNPCAnEnemy())
            //        {
            //            NPCActions.BattleNPC(game.GamePlayer, newRoom, npc);
            //        }
            //        return;
            //    }
            //}

            // If you can't move, tells you so
            Console.WriteLine("\nCouldn't move that way.");
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
