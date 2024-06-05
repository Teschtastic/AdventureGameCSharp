using AdventureGame.save;

namespace AdventureGame.Rooms
{
    public class Rooms
    {
        public Dictionary<string, Room> roomsMap = new();

        public Rooms()
        {
            LoadFromFile.LoadRoomsFromFile(roomsMap);
        }
    }
}
