using AdventureGame.Game;
using AdventureGame.NPCs;

namespace AdventureGame.Rooms
{
    public class Room(string name,  bool hasItem, string iIR, bool hNPC, string npcIR, bool hF,  string fIR, Dictionary<string, string> connR)
    {
        public string Name { get; set; } = name;
        public string StartMessage { get; set; } = "You start in " + name;
        public string EnterMessage { get; set; } = "You've entered " + name;
        public string LeaveMessage { get; set; } = "You've left " + name;
        public string InMessage { get; set; } = "\nYou're in " + name;
        public Dictionary<string, string> ConnRooms { get; set; } = connR;
        public bool HasItem { get; set; } = hasItem;
        public string ItemInRoom { get; set; } = iIR;
        public bool HasNPC { get; set; } = hNPC;
        public string NPCInRoom { get; set; } = npcIR;
        public bool HasFurniture { get; set; } = hF;
        public string FurnitureInRoom { get; set; } = fIR;

        public bool HasAliveEnemy(GameObject game)
        {
            if(!HasNPC)
                return false;
            else
            {
                NPC npc = game.GetNPC(NPCInRoom)!;
                return npc.IsAlive && npc.IsNPCAnEnemy();
            }
        }

        public string GetMoves()
        {
            string move = "";

            foreach (var entry in ConnRooms)
                if (entry.Value != "")
                    move = move += " " + entry.Key;

            return "\nYou can move:" + move;
        }
    }
}
