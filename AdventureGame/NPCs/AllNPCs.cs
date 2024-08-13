using AdventureGame.Items;

namespace AdventureGame.NPCs
{
    public class AllNPCs
    {
        // Different NPC maps
        private readonly Dictionary<string, NPC> npcs = new NPCs().npcMap;
        private readonly Dictionary<string, NPC> enemies = new NPCs().enemyMap;

        public Dictionary<string, NPC> allNPCs = [];

        public AllNPCs()
        {
            npcs.ToList().ForEach(x => allNPCs.Add(x.Key, x.Value));
            enemies.ToList().ForEach(x => allNPCs.Add(x.Key, x.Value));
        }

        public NPC? GetNPC(string npcName)
        {
            return allNPCs.TryGetValue(npcName, out NPC? value) ? value : null;
        }

        public List<NPC> GetNPCs()
        {
            return [.. allNPCs.Values];
        }

        public List<NPC> GetNPCs(List<string> npcNames)
        {
            var npcs = new List<NPC>();
            foreach (string npcName in npcNames)
            {
                var npc = GetNPC(npcName);
                if (npc != null)
                {
                    npcs.Add(npc);
                }
            }
            return npcs;
        }
    }
}
