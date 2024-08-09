using AdventureGame.Dialogue;
using AdventureGame.Game;
using AdventureGame.Items;
using AdventureGame.NPCs;
using AdventureGame.Rooms;

namespace AdventureGame.Actions
{
    public class NPCActions
    {
        /* Method used to talk to the NPC in the room */
        public static void TalkToNPC(GameObject game)
        {
            Room room = game.GetRoomPlayerIsIn();
            NPC npc = game.GetNPCInRoom();

            if (npc == null || !room.HasNPC)
            {
                Console.WriteLine("\nThere is nobody to talk to.");
            }
            else if (!npc.IsAlive)
            {
                Console.WriteLine("\n" + npc.Name + " is not alive.");
            }
            else
            {
                //Console.WriteLine("\n" + npc.Name + " says \"" + npc.Message + "\"");
                DialogueList list = game.GetNPCDialogue(npc.Name);

                npc.ProcessDialogue(game.Player, list);
            }
        }

        public static void DescribeNPC(GameObject game)
        {
            Room room = game.GetRoomPlayerIsIn();
            NPC npc = game.GetNPCInRoom();

            if (npc != null && room.HasNPC)
            {
                Console.WriteLine("\nYou inspect " + npc.Name +
                                    npc.ToString());
                if (!npc.IsAlive)
                {
                    Console.WriteLine("They aren\'t alive.");
                }
            }
            else
            {
                Console.WriteLine("\nThere isn't an NPC in this room.");
            }
        }

        /* Method used to give an item in your inventory to an NPC */
        public static void GiveItem(GameObject game)
        {
            Player.Player player  = game.Player;
            List<string> inventory = player.Inventory;
            NPC npc = game.GetNPCInRoom();
            Item? item = null;

            // Nothing in inventory to give
            if (inventory.Count == 0)
            {
                Console.WriteLine("\nThere is nothing in your inventory to give.");
            }
            // Only one item in your inventory to give
            else if (inventory.Count == 1)
            {
                item = game.GetItem(inventory[0]);
            }
            else
            {
                item = game.GetItem(PlayerActions.TakeItemFromInventory(inventory));
            }

            if (item != null)
            {
                // Removes item from your inventory and adds to the NPCs
                player.RemoveFromInventory(item);
                npc.Inventory.Add(item.Name);
                Console.WriteLine("\nYou gave " + npc.Name + " your " + item.Name);
            }
        }

        /* Method used to take an item from an NPC */
        public static void TakeItem(GameObject game)
        {
            NPC npc = game.GetNPCInRoom();
            Item? item;

            // If there isn't an item in the NPCs inventory, nothing to take
            if (npc.Inventory.Count == 0)
            {
                Console.WriteLine("\n" + npc.Name + " doesn't have an item.");
            }
            else
            {
                item = game.GetItem(PlayerActions.TakeItemFromInventory(npc.Inventory));

                // The item is able to be taken, so remove it from the NPCs inventory and add it to yours
                if (item != null)
                {
                    npc.Inventory.Remove(item.Name);
                    game.Player.AddToInventory(item);
                    Console.WriteLine("\nYou take the " + item.Name +
                            "\nfrom " + npc.Name);
                }
            }
        }

        /* Method used to trade items with an NPC */
        // TODO: Implement
        public static void TradeItem(GameObject game)
        {
            NPC npc = game.GetNPCInRoom();
            //Item item;

            Console.WriteLine("\nCan't trade with " + npc.Name);
            Console.WriteLine("\nNot implemented.");
        }

        public static void NPCBattleDecision(Player.Player player, NPC npc)
        {
            int damageDoneToYou = Math.Clamp(npc.AttackDamage - player.ArmorClass, 0, npc.AttackDamage);

            player.CurrentHealth -= damageDoneToYou;

            Console.WriteLine("\n " + npc.Name + " attacks you\n for " + damageDoneToYou + " points of damage.");

        }

        public static void BattleNPC(GameObject game)
        {
            Player.Player player = game.Player;
            Room room = game.GetRoomPlayerIsIn();
            NPC npc = game.GetNPCInRoom();

            bool battling = true;
            Actions.BattleMessage();
            Console.WriteLine("\nyou are battling with: " + npc.Name);

            do
            {
                // Prints an options menu
                Console.WriteLine("\n >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>");
                Console.WriteLine("\n Your health: " + player.CurrentHealth);
                Console.WriteLine(" " + npc.Name + "\'s health: " + npc.CurrentHealth);
                Console.WriteLine("\n What would you like to do?");
                Console.WriteLine(
                                "\n 1 - Attack " + npc.Name +
                                "\n 2 - Use item" +
                                "\n 0 - Exit battle");
                Console.WriteLine("\n >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>");
                Actions.BattleChoice();

                string battleChoice = Console.ReadLine() ?? "";

                // This either shows the container's inventory or that it is empty
                if (battleChoice != "")
                {
                    int damageYouDealt = Math.Clamp(player.AttackDamage - npc.ArmorClass, 0, player.AttackDamage);

                    if (battleChoice == "1")
                    {
                        Console.WriteLine("\n You attack " + npc.Name + "\n for " + damageYouDealt + " points of damage.");

                        npc.CurrentHealth -= damageYouDealt;

                        if (npc.CurrentHealth <= 0)
                        {
                            Console.WriteLine("\n You have slain " + npc.Name);
                            npc.IsAlive = false;
                            battling = false;
                            break;
                        }

                        NPCBattleDecision(player, npc);

                        if (player.CurrentHealth <= 0)
                        {
                            Console.WriteLine("\n You have been slain by " + npc.Name);
                            battling = false;
                        }

                    }
                    else if (battleChoice == "2")
                    {
                        ItemActions.UseInventoryItem(game);

                        NPCBattleDecision(player, npc);
                    }
                    else if (battleChoice == "0")
                    {
                        Console.WriteLine("\n You left the battle.");
                        battling = false;
                    }
                }
                else
                {
                    Console.WriteLine("\n Invalid choice.");
                }
            } while (battling);
            Console.WriteLine("\n The battle is now over.");
        }
    }
}