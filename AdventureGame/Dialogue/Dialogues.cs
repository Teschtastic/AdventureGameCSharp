using AdventureGame.save;
using Newtonsoft.Json;

namespace AdventureGame.Dialogue
{
    public class Dialogues
    {
        public Dictionary<string, DialogueList> dialoguesMap = new();

        public Dialogues()
        {
            LoadFromFile.LoadDialoguesFromFile(dialoguesMap);
            //dialoguesMap.Add(LoadClaudiaDialogue());
            //dialoguesMap.Add(LoadJeffDialogue());
            //dialoguesMap.Add(LoadMichaelaDialogue());
        }

        //public static DialogueList LoadClaudiaDialogue()
        //{
        //    DialogueNode nodeBegin = new()
        //    {
        //        Text = "\nHi Seanie!",
        //        NodeID = 0,
        //        HasMethod = false,
        //        Options = new()
        //        {
        //            new("Hi Claudi!", 1),
        //            new("Goodbye Claudi!", -1)
        //        }
        //    };

        //    DialogueNode node1 = new()
        //    {
        //        Text = "\nHow can I help you?",
        //        NodeID = 1,
        //        HasMethod = false,
        //        Options = new()
        //        { 
        //            new("Quest available?", 4),
        //            new("Trade.", 5),
        //            new("Take.", 7),
        //            new("Give.", 8),
        //            new("Chat.", 6),
        //            new("Goodbye Claudi!", -1)
        //        }
        //    };

        //    DialogueNode node6 = new()
        //    {
        //        Text = "\nHow are you?",
        //        NodeID = 6,
        //        HasMethod = false,
        //        Options = new()
        //        {
        //            new("Good.", 2),
        //            new("Bad.", 3)
        //        }
        //    };

        //    DialogueNode node2 = new()
        //    {
        //        Text = "\nThat's good to hear.",
        //        NodeID = 2,
        //        HasMethod = false,
        //        Options = new()
        //        {
        //            new("Keep talking.", 1),
        //            new("Goodbye Claudi!", -1)
        //        }
        //    };

        //    DialogueNode node3 = new()
        //    {
        //        Text = "\nI'm sorry to hear that.",
        //        NodeID = 3,
        //        HasMethod = false,
        //        Options = new()
        //        {
        //            new("Keep talking.", 1),
        //            new("Goodbye Claudi!", -1)
        //        }
        //    };

        //    DialogueNode node4 = new()
        //    {
        //        Text = "\nUnfortunately not.\nCheck again later.",
        //        NodeID = 4,
        //        HasMethod = false,
        //        Options = new()
        //        {
        //            new("Keep talking.", 1),
        //            new("Goodbye Claudi!", -1)
        //        }
        //    };

        //    DialogueNode node5 = new()
        //    {
        //        Text = "\nLet's trade.",
        //        NodeID = 5,
        //        HasMethod = true,
        //        Method = "TradeItem",
        //        Params = new object[] { "player" },
        //        Options = new()
        //        {
        //            new("Keep talking.", 1),
        //            new("Goodbye Claudi!", -1)
        //        }
        //    };

        //    DialogueNode node7 = new()
        //    {
        //        Text = "\nWhat would you like?",
        //        NodeID = 7,
        //        HasMethod = true,
        //        Method = "TakeItem",
        //        Params = new object[] { "player" },
        //        Options = new()
        //        {
        //            new("Keep talking.", 1),
        //            new("Goodbye Claudi!", -1)
        //        }
        //    };

        //    DialogueNode node8 = new()
        //    {
        //        Text = "\nWhat are you giving me?",
        //        NodeID = 8,
        //        HasMethod = true,
        //        Method = "GiveItem",
        //        Params = new object[] { "player" },
        //        Options = new()
        //        {
        //            new("Keep talking.", 1),
        //            new("Goodbye Claudi!", -1)
        //        }
        //    };

        //    DialogueNode nodeEnd = new()
        //    {
        //        Text = "\nGoodbye Seanie!",
        //        NodeID = -1,
        //        HasMethod = false
        //    };

        //    DialogueNodes nodes = new();
        //    nodes.Nodes.Add(nodeBegin);
        //    nodes.Nodes.Add(node1);
        //    nodes.Nodes.Add(node2);
        //    nodes.Nodes.Add(node3);
        //    nodes.Nodes.Add(node4);
        //    nodes.Nodes.Add(node5);
        //    nodes.Nodes.Add(node6);
        //    nodes.Nodes.Add(node7);
        //    nodes.Nodes.Add(node8);
        //    nodes.Nodes.Add(nodeEnd);

        //    DialogueList dialogueList = new()
        //    {
        //        Name = "Claudia dialogue"
        //    };

        //    dialogueList.Dialogues.Add(nodes);

        //    return dialogueList;
        //}

        //public static DialogueList LoadJeffDialogue()
        //{
        //    DialogueNode nodeBegin = new()
        //    {
        //        Text = "\nHey Tesch!\n",
        //        NodeID = 0,
        //        HasMethod = false
        //    };

        //    nodeBegin.Options.Add(new("Hey Gennick!", 1));
        //    nodeBegin.Options.Add(new("Goodbye Gennick!", -1));

        //    DialogueNode node1 = new()
        //    {
        //        Text = "\nTalk to you later.\n",
        //        NodeID = 1,
        //        HasMethod = false
        //    };

        //    node1.Options.Add(new("Goodbye Gennick!", -1));

        //    DialogueNode nodeEnd = new()
        //    {
        //        Text = "\nGoodbye Tesch!",
        //        NodeID = -1,
        //        HasMethod = false
        //    };

        //    DialogueNodes nodes = new();
        //    nodes.Nodes.Add(nodeBegin);
        //    nodes.Nodes.Add(node1);
        //    nodes.Nodes.Add(nodeEnd);

        //    DialogueList dialogueList = new()
        //    {
        //        Name = "Jeff dialogue"
        //    };

        //    dialogueList.Dialogues.Add(nodes);

        //    var v = JsonConvert.SerializeObject(dialogueList);

        //    return dialogueList;
        //}

        //public static DialogueList LoadMichaelaDialogue()
        //{
        //    DialogueNode nodeBegin = new()
        //    {
        //        Text = "\nHey Tesch!\n",
        //        NodeID = 0,
        //        HasMethod = false
        //    };

        //    nodeBegin.Options.Add(new("My man!", 1));
        //    nodeBegin.Options.Add(new("Goodbye Michaela!", -1));

        //    DialogueNode node1 = new()
        //    {
        //        Text = "\nMy man!\n",
        //        NodeID = 1,
        //        HasMethod = false
        //    };

        //    node1.Options.Add(new("Goodbye Michaela!", -1));

        //    DialogueNode nodeEnd = new()
        //    {
        //        Text = "\nGoodbye Tesch!",
        //        NodeID = -1,
        //        HasMethod = false
        //    };

        //    DialogueNodes nodes = new();
        //    nodes.Nodes.Add(nodeBegin);
        //    nodes.Nodes.Add(node1);
        //    nodes.Nodes.Add(nodeEnd);

        //    DialogueList dialogueList = new()
        //    {
        //        Name = "Michaela dialogue"
        //    };

        //    dialogueList.Dialogues.Add(nodes);

        //    var v = JsonConvert.SerializeObject(dialogueList);

        //    return dialogueList;
        //}
    }
}