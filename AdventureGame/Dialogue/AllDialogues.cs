namespace AdventureGame.Dialogue
{
    public class AllDialogues
    {
        private readonly Dictionary<string, DialogueList> dialogues = new Dialogues().dialoguesMap;

        public Dictionary<string, DialogueList> allDialogues = new();

        public AllDialogues()
        {
            foreach (var dialogue in dialogues)
            {
                allDialogues.Add(dialogue.Key, dialogue.Value);
            }
        }

        public DialogueList GetDialogueList(string npcName)
        {
            foreach (var dialogue in allDialogues)
            {
                if (npcName == dialogue.Key)
                {
                    return dialogue.Value;
                }
            }
            return null;
        }
    }
}