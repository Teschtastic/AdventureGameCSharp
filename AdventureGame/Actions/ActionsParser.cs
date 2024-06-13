using AdventureGame.Globals;
using AdventureGame.NPCs;
using AdventureGame.Rooms;

namespace AdventureGame.Actions
{
    public class ActionsParser
    {
        public static void GameLoop(Player.Player player, Dictionary<int, List<string>> userActions)
        {
            Actions.WelcomeMessage();                       // Welcome message
            Console.WriteLine(player.RoomIsIn);             // Tells you which room you're in
            bool isGameRunning = true;

            while (isGameRunning)                           // Main game loop
            {
                int choiceIndex = -1;
                Actions.CommandChoice();

                string? playerAction = Console.ReadLine();  // Reads the next line into the player's action

                // Checks to see if the user choice is defined in the actions scope,
                // then assigns it to an int
                foreach (var entry in userActions)
                {
                    if (playerAction != null && entry.Value.Contains(playerAction.ToLower()))
                    {
                        choiceIndex = entry.Key;
                    }
                }

                // If there was no action for the choice given, set to error choice
                // else use the choice given index above
                switch (choiceIndex)
                {
                    // Switch case to parse the user's choice
                    case 1:
                        PlayerActions.Inventory(player);            // Accesses the inventory
                        break;

                    case 2:
                        PlayerActions.Help(userActions);            // Accesses the help menu
                        break;

                    case 3:
                        RoomActions.PrintLocation(player);          // Prints your location
                        break;

                    case 4:
                        string move = playerAction != null ? playerAction.ToUpper() : "";
                        RoomActions.Move(player, move);             // Moves into a new room

                        Room room = AllObjects.allRooms.GetRoom(player.RoomIsIn);
                        NPC npc = AllObjects.allNPCs.GetNPC(room.NPCInRoom);

                        if (NPCActions.IsAliveNPCInRoom(room, npc) && NPCActions.IsNPCAnEnemy(npc))
                        {
                            NPCActions.BattleNPC(player, room, npc);
                        }
                        break;

                    case 5:
                        RoomActions.LookAround(player);             // Looks around the room
                        break;

                    case 6:
                        ItemActions.PickupItem(player);             // Attempts to pickup an item
                        break;

                    case 7:
                        ItemActions.DropItem(player);               // Drops an item into the current room
                        break;

                    case 8:
                        PlayerActions.DescribeSomething(player);    // Describes something
                        break;

                    case 9:
                        PlayerActions.UseSomething(player);         // Uses something that can be used
                        break;

                    case 10:
                        NPCActions.TalkToNPC(player);               // Talks to the NPC in the room
                        break;

                    case 11:
                        NPCActions.GiveItem(player);                // Gives item to the NPC in the room
                        break;

                    case 12:
                        NPCActions.TakeItem(player);                // Gives item to the NPC in the room
                        break;

                    case 13:
                        PlayerActions.DescribePlayer(player);       // Describes the player character
                        break;

                    case 14:
                        ItemActions.EquipItem(player);              // Equips an item to player
                        break;

                    case 15:
                        ItemActions.UnEquipItem(player);            // Unequips an item from player
                        break;

                    case 16:
                        PlayerActions.SaveGame(player);             // Saves the game
                        break;

                    case 0:
                        Actions.ExitMessage();                      // Quits the game
                        isGameRunning = false;
                        break;

                    case -1:
                        Actions.InputError();                       // Input error
                        break;

                    default:
                        Actions.GenericError();                     // Outputs a generic error to the user
                        break;
                }

                if (player.CurrentHealth <= 0)                      // Checks if player is dead, and ends game
                {
                    Actions.DeathMessage();
                    isGameRunning = false;
                }
            }
        }
    }
}