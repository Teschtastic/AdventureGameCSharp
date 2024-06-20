using AdventureGame.NPCs;

namespace AdventureGame.Rooms
{
    public class Room
    {
        public Room(
            string name,
            bool hasItem,
            string iIR,
            bool hNPC,
            string npcIR,
            bool hF,
            string fIR,
            Dictionary<string, string> connR)
        {

            Name            = name;
            StartMessage    = "You start in "   + name;
            InMessage       = "\nYou're in "    + name;
            EnterMessage    = "You've entered " + name;
            LeaveMessage    = "You've left "    + name;
            HasItem         = hasItem;
            ItemInRoom      = iIR;
            HasNPC          = hNPC;
            NPCInRoom       = npcIR;
            HasFurniture    = hF;
            FurnitureInRoom = fIR;
            ConnRooms       = connR;
        }

        public string Name                          { get; set; }
        public string StartMessage                  { get; set; }
        public string EnterMessage                  { get; set; }
        public string LeaveMessage                  { get; set; }
        public string InMessage                     { get; set; }
        public Dictionary<string, string> ConnRooms { get; set; }
        public bool HasItem                         { get; set; }
        public string ItemInRoom                    { get; set; }
        public bool HasNPC                          { get; set; }
        public string NPCInRoom                     { get; set; }
        public bool HasFurniture                    { get; set; }
        public string FurnitureInRoom               { get; set; }

        public bool IsAliveNPCInRoom(NPC npc)
        {
            return HasNPC && npc.IsAlive && npc != null;
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
