namespace AdventureGame.Rooms
{
    public class AllRooms
    {
        // Different room maps
        private readonly Dictionary<string, Room> rooms = new Rooms().roomsMap;

        public Dictionary<string, Room> allRooms = new();

        public AllRooms()
        {
            rooms.ToList().ForEach(x => allRooms.Add(x.Key, x.Value));
        }

        public Room GetRoom(string roomName)
        {
            return allRooms.ContainsKey(roomName) ? allRooms[roomName] : null;
        }

        public List<Room> GetRooms(List<string> roomNames)
        {
            var rooms = new List<Room>();
            foreach (string roomName in roomNames)
            {
                var room = GetRoom(roomName);
                if (room != null)
                {
                    rooms.Add(room);
                }
            }
            return rooms;
        }
    }
}
