using AdventureGame.save;

namespace AdventureGame.NPCs
{
    public class NPCs
    {
        // HashMap the NPCs are stored in
        public Dictionary<string, NPC> npcMap = new();
        // HashMap the Enemies are stored in
        public Dictionary<string, NPC> enemyMap = new();

        public NPCs()
        {
            LoadFromFile.LoadNPCsFromFile(npcMap);
            LoadFromFile.LoadEnemiesFromFile(enemyMap);
        }
    }
}
