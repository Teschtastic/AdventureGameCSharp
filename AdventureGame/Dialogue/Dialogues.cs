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
        }
    }
}