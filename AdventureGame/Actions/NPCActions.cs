using AdventureGame.Dialogue;
using AdventureGame.Globals;
using AdventureGame.Items;
using AdventureGame.NPCs;
using AdventureGame.Rooms;

namespace AdventureGame.Actions
{
    public class NPCActions
    {
        /* Method used to talk to the NPC in the room */
        public static void TalkToNPC(Player.Player player)
        {
            Room room = AllObjects.allRooms.GetRoom(player.RoomIsIn);
            NPC npc = AllObjects.allNPCs.GetNPC(room.NPCInRoom);

            if (npc == null || !room.HasNPC)
            {
                Console.WriteLine("\nThere is nobody to talk to.");
            }
            else
            {
                //Console.WriteLine("\n" + npc.Name + " says \"" + npc.Message + "\"");
                DialogueList list = AllObjects.allDialogues.GetDialogueList(npc.Name);

                if (list != null)
                {
                    int nodeID = 0;

                    while (nodeID != -1)
                    {
                        Node node = new();
                        foreach (var n in list.Dialogues[0].Nodes)
                        {
                            if (nodeID == n.NodeId)
                            {
                                node = n;
                            }
                        }

                        Console.WriteLine(node.Text);

                        if (node.HasMethod == true)
                        {
                            if (node.Params != null)
                            {
                                if (node.Params.Contains("player"))
                                {
                                    GlobalMethods.CallByName(new NPCActions(), node.Method, new object[] { player });
                                }
                            }
                            else
                            {
                                GlobalMethods.CallByName(new NPCActions(), node.Method, Array.Empty<object>());
                            }
                        }

                        int i = 1;
                        char[] slashes = { '\\', '/' };

                        Console.WriteLine("\n >>>>>>>>>>>>>>>>>>>>>>>>>");
                        foreach (var option in node.Options)
                        {
                            Console.WriteLine(" " + slashes[i % 2 == 0 ? 0 : 1] + " " + i++ + " - " + option.Text);
                        }
                        Console.WriteLine(" >>>>>>>>>>>>>>>>>>>>>>>>>");

                        Actions.DialogueChoice();

                        string? optionString = Console.ReadLine();

                        if (int.TryParse(optionString, out int optionChoice))
                        {
                            if (optionChoice > 0 && optionChoice <= node.Options.Count)
                            {
                                Option option = node.Options[optionChoice - 1];
                                nodeID = option.DestinationNodeId;

                                foreach (var n in list.Dialogues[0].Nodes)
                                {
                                    if (nodeID == -1 && n.NodeId == -1)
                                    {
                                        Console.WriteLine(n.Text);
                                    }
                                }
                            }
                            else
                            {
                                Console.WriteLine("\nInvalid choice.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("\nInvalid option.");
                        }
                    }
                }
                else
                {
                    Console.WriteLine("\n" + npc.Name + " has nothing to say.");
                }
            }
        }

        public static void DescribeNPC(Player.Player player)
        {
            Room room = AllObjects.allRooms.GetRoom(player.RoomIsIn);
            NPC npc = AllObjects.allNPCs.GetNPC(room.NPCInRoom);

            if (npc != null && room.HasNPC)
            {
                Console.WriteLine("\nYou inspect " + npc.Name +
                                    npc.ToString());
            }
            else
            {
                Console.WriteLine("\nThere isn't an NPC in this room.");
            }
        }

        /* Method used to give an item in your inventory to an NPC */
        public static void GiveItem(Player.Player player)
        {
            List<string> inventory = player.Inventory;
            Room room = AllObjects.allRooms.GetRoom(player.RoomIsIn);
            NPC npc = AllObjects.allNPCs.GetNPC(room.NPCInRoom);
            Item? item = null;

            // Nothing in inventory to give
            if (inventory.Count == 0)
            {
                Console.WriteLine("\nThere is nothing in your inventory to give.");
            }
            // Only one item in your inventory to give
            else if (inventory.Count == 1)
            {
                item = AllObjects.allItems.GetItem(inventory[0]);
            }
            else
            {
                item = AllObjects.allItems.GetItem(PlayerActions.TakeItemFromInventory(inventory));
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
        public static void TakeItem(Player.Player player)
        {
            Room room = AllObjects.allRooms.GetRoom(player.RoomIsIn);
            NPC npc = AllObjects.allNPCs.GetNPC(room.NPCInRoom);
            Item item;

            // If there isn't an item in the NPCs inventory, nothing to take
            if (npc.Inventory.Count == 0)
            {
                Console.WriteLine("\n" + npc.Name + " doesn't have an item.");
            }
            else
            {
                item = AllObjects.allItems.GetItem(PlayerActions.TakeItemFromInventory(npc.Inventory));

                // The item is able to be taken, so remove it from the NPCs inventory and add it to yours
                if (item != null)
                {
                    npc.Inventory.Remove(item.Name);
                    player.AddToInventory(item);
                    Console.WriteLine("\nYou take the " + item.Name +
                            "\nfrom " + npc.Name);
                }
            }
        }

        /* Method used to trade items with an NPC */
        // TODO: Implement
        public static void TradeItem(Player.Player player)
        {
            Room room = AllObjects.allRooms.GetRoom(player.RoomIsIn);
            NPC npc = AllObjects.allNPCs.GetNPC(room.NPCInRoom);
            //Item item;

            Console.WriteLine("\nCan't trade with " + npc.Name);
            Console.WriteLine("\nNot implemented.");
        }
    }
}