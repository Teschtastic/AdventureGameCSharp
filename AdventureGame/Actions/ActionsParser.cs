using AdventureGame.Game;

namespace AdventureGame.Actions
{
    public class ActionsParser
    {
        public static void GameLoop(GameObject game)
        {
            // Welcome message
            Actions.WelcomeMessage();

            //bool clearScreen = false;

            // Main game loop
            while (game.IsRunning)                           
            {
                //if (clearScreen)
                //{
                //    Console.Clear();
                //}

                //clearScreen = true;

                // Tells you which room you're in
                Console.WriteLine($"\nYou are currently in: {game.GetRoomPlayerIsIn().Name}" );
                int choiceIndex = -1;
                game.GetUserChoice(ref choiceIndex);

                // If there was no action for the choice given, set to error choice
                // else use the choice given index above
                switch (choiceIndex)
                {
                    // Switch case to parse the user's choice
                    case 1:
                        // Accesses the inventory
                        PlayerActions.Inventory(game);
                        break;

                    case 2:
                        // Accesses the help menu
                        PlayerActions.Help(game.UserActions);
                        break;

                    case 3:
                        // Prints your location
                        RoomActions.PrintLocation(game);
                        break;

                    case 4:
                        // Moves into a new room
                        RoomActions.Move(game);
                        break;

                    case 5:
                        // Looks around the room
                        RoomActions.LookAround(game);
                        break;

                    case 6:
                        // Attempts to pickup an item
                        ItemActions.PickupItem(game);
                        break;

                    case 7:
                        // Drops an item into the current room
                        ItemActions.DropItem(game);
                        break;

                    case 8:
                        // Describes something
                        PlayerActions.DescribeSomething(game);
                        break;

                    case 9:
                        // Uses something that can be used
                        PlayerActions.UseSomething(game);
                        break;

                    case 10:
                        // Talks to the NPC in the room
                        NPCActions.TalkToNPC(game);
                        break;

                    case 11:
                        // Gives item to the NPC in the room
                        NPCActions.GiveItem(game);
                        break;

                    case 12:
                        // Takes item from the NPC in the room
                        NPCActions.TakeItem(game);
                        break;

                    case 13:
                        // Describes the player character
                        PlayerActions.DescribePlayer(game.Player);
                        break;

                    case 14:
                        // Saves the game
                        PlayerActions.SaveGame(game);
                        break;

                    case 15:
                        // Initiates a battle with an NPC
                        NPCActions.BattleNPC(game);
                        break;

                    case 0:
                        // Quits the game
                        Actions.ExitMessage();
                        game.IsRunning = false;
                        break;

                    case -1:
                        // Input error
                        Actions.InputError();
                        break;

                    default:
                        // Outputs a generic error to the user
                        Actions.GenericError();
                        break;
                }

                // Checks if player is dead, and ends gam
                if (game.Player.CurrentHealth <= 0)
                {
                    Actions.DeathMessage();
                    game.IsRunning = false;
                }
            }
        }
    }
}