using AdventureGame.Game;
using AdventureGame.NPCs;
using AdventureGame.Rooms;

namespace AdventureGame.Actions
{
    public class ActionsParser
    {
        public static void GameLoop(GameObject game)
        {
            Actions.WelcomeMessage();                       // Welcome message
            Console.WriteLine(game.GetRoomPlayerIsIn().Name);             // Tells you which room you're in

            while (game.IsRunning)                           // Main game loop
            {
                int choiceIndex = -1;
                game.GetUserChoice(ref choiceIndex);

                // If there was no action for the choice given, set to error choice
                // else use the choice given index above
                switch (choiceIndex)
                {
                    // Switch case to parse the user's choice
                    case 1:
                        PlayerActions.Inventory(game.GetItemsInInventory());            // Accesses the inventory
                        break;

                    case 2:
                        PlayerActions.Help(game.UserActions);            // Accesses the help menu
                        break;

                    case 3:
                        RoomActions.PrintLocation(game);          // Prints your location
                        break;

                    case 4:
                        RoomActions.Move(game);             // Moves into a new room

                        //Room room = game.GetRoomPlayerIsIn();
                        //NPC npc = game.GetNPCInRoom();

                        //if (room.IsAliveNPCInRoom(npc) && npc.IsNPCAnEnemy())
                        //{
                        //    NPCActions.BattleNPC(game);
                        //}
                        break;

                    case 5:
                        RoomActions.LookAround(game);             // Looks around the room
                        break;

                    case 6:
                        ItemActions.PickupItem(game);             // Attempts to pickup an item
                        break;

                    case 7:
                        ItemActions.DropItem(game);               // Drops an item into the current room
                        break;

                    case 8:
                        PlayerActions.DescribeSomething(game);    // Describes something
                        break;

                    case 9:
                        PlayerActions.UseSomething(game);         // Uses something that can be used
                        break;

                    case 10:
                        NPCActions.TalkToNPC(game);               // Talks to the NPC in the room
                        break;

                    case 11:
                        NPCActions.GiveItem(game);                // Gives item to the NPC in the room
                        break;

                    case 12:
                        NPCActions.TakeItem(game);                // Gives item to the NPC in the room
                        break;

                    case 13:
                        PlayerActions.DescribePlayer(game.GetPlayer());       // Describes the player character
                        break;

                    case 14:
                        ItemActions.EquipItem(game);              // Equips an item to player
                        break;

                    case 15:
                        ItemActions.UnEquipItem(game);            // Unequips an item from player
                        break;

                    case 16:
                        PlayerActions.SaveGame(game);             // Saves the game
                        break;

                    case 0:
                        Actions.ExitMessage();                      // Quits the game
                        game.IsRunning = false;
                        break;

                    case -1:
                        Actions.InputError();                       // Input error
                        break;

                    default:
                        Actions.GenericError();                     // Outputs a generic error to the user
                        break;
                }

                if (game.GetPlayer().CurrentHealth <= 0)                      // Checks if player is dead, and ends game
                {
                    Actions.DeathMessage();
                    game.IsRunning = false;
                }
            }
        }
    }
}