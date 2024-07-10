using AdventureGame.Actions;
using AdventureGame.Dialogue;
using AdventureGame.Game;

namespace AdventureGame.NPCs
{
    public class NPC
    {
        public NPC(string n, string d, int cH, int mH, int aC, int aD, bool isF, bool isA, string eA, bool hEA, string eW, bool hEW, List<string> inv)
        {
            Name                = n;
            Dialogue            = d;
            CurrentHealth       = cH;
            MaximumHealth       = mH;
            ArmorClass          = aC;
            AttackDamage        = aD;
            IsFriendly          = isF;
            IsAlive             = isA;
            EquippedArmor       = eA;
            HasEquippedArmor    = hEA;
            EquippedWeapon      = eW;
            HasEquippedWeapon   = hEW;
            Inventory           = inv;
        }

        public string       Name                { get; set; }
        public string       Dialogue            { get; set; }
        public int          CurrentHealth       { get; set; }
        public int          MaximumHealth       { get; set; }
        public int          ArmorClass          { get; set; }
        public int          AttackDamage        { get; set; }
        public bool         IsFriendly          { get; set; }
        public bool         IsAlive             { get; set; }
        public string       EquippedArmor       { get; set; }
        public bool         HasEquippedArmor    { get; set; }
        public string       EquippedWeapon      { get; set; }
        public bool         HasEquippedWeapon   { get; set; }
        public List<string> Inventory           { get; set; }

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

                    Actions.Actions.DialogueChoice();

                    string optionString = Console.ReadLine() ?? "";

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
