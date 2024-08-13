using AdventureGame.Actions;
using AdventureGame.Dialogue;
using AdventureGame.Game;
using System.Linq;

namespace AdventureGame.NPCs
{
    public class NPC(string n, string d, int cH, int mH, int aC, int aD, bool isF, bool isA, string eA, bool hEA, string eW, bool hEW, List<string> inv)
    {
        public string Name { get; set; } = n;
        public string Dialogue { get; set; } = d;
        public int CurrentHealth { get; set; } = cH;
        public int MaximumHealth { get; set; } = mH;
        public int ArmorClass { get; set; } = aC;
        public int AttackDamage { get; set; } = aD;
        public bool IsFriendly { get; set; } = isF;
        public bool IsAlive { get; set; } = isA;
        public string EquippedArmor { get; set; } = eA;
        public bool HasEquippedArmor { get; set; } = hEA;
        public string EquippedWeapon { get; set; } = eW;
        public bool HasEquippedWeapon { get; set; } = hEW;
        public List<string> Inventory { get; set; } = inv;

        public bool IsNPCAnEnemy()
        {
            return !IsFriendly;
        }

        public void ProcessDialogue(Player.Player player, DialogueList list)
        {
            if (list != null)
            {
                int nodeID = 0;

                while (nodeID != -1)
                {
                    Node node = new();
                    foreach (Node n in from Node n in list.Dialogues![0].Nodes!
                                      where nodeID == n.NodeId
                                      select n)
                    {
                        node = n;
                    }

                    Console.WriteLine(node.Text);

                    if (node.HasMethod == true)
                    {
                        if (node.Params != null)
                        {
                            if (node.Params.Contains("player"))
                            {
                                GlobalMethods.CallByName(new NPCActions(), node.Method!, [player]);
                            }
                        }
                        else
                        {
                            GlobalMethods.CallByName(new NPCActions(), node.Method!, []);
                        }
                    }

                    int i = 1;
                    char[] slashes = ['\\', '/'];

                    Console.WriteLine("\n >>>>>>>>>>>>>>>>>>>>>>>>>");
                    foreach (var option in node.Options!)
                    {
                        Console.WriteLine(" " + slashes[i % 2 == 0 ? 0 : 1] + " " + i++ + " - " + option.Text);
                    }
                    Console.WriteLine(" >>>>>>>>>>>>>>>>>>>>>>>>>");

                    Actions.Actions.DialogueChoice();

                    string optionString = Console.ReadLine() ?? "";

                    if (int.TryParse(optionString, out int optionChoice))
                    {
                        if (optionChoice > 0 && optionChoice <= node.Options.Count)
                        {
                            Option option = node.Options[optionChoice - 1];
                            nodeID = option.DestinationNodeId;

                            foreach (var n in list.Dialogues[0].Nodes!)
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
                Console.WriteLine("\n" + Name + " has nothing to say.");
            }
        }

        public override string ToString()
        {
            return "\n\nNPC Description:\n\n" +
                    "Name:            " + Name + "\n" +
                    "Current health:  " + CurrentHealth + "\n" +
                    "Maximum health:  " + MaximumHealth + "\n" +
                    "Armor class:     " + ArmorClass + "\n" +
                    "Attack damage:   " + AttackDamage + "\n" +
                    "Equipped armor:  " + EquippedArmor + "\n" +
                    "Equipped weapon: " + EquippedWeapon;
        }
    }
}
