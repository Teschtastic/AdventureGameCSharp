namespace AdventureGame.NPCs
{
    public class AllNPCs
    {
        // Different NPC maps
        private readonly Dictionary<string, NPC> npcs = new NPCs().npcMap;

        public Dictionary<string, NPC> allNPCs = new();

        public AllNPCs()
        {
            npcs.ToList().ForEach(x => allNPCs.Add(x.Key, x.Value));
        }

        public NPC GetNPC(string npcName)
        {
            return allNPCs.ContainsKey(npcName) ? allNPCs[npcName] : null;
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
