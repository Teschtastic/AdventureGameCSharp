using AdventureGame.save;

namespace AdventureGame.NPCs
{
    public class NPCs
    {
        // HashMap the NPCs are stored in
        public Dictionary<string, NPC> npcMap = new();

        public NPCs()
        {
            LoadFromFile.LoadNPCsFromFile(npcMap);
        }
    }
}
