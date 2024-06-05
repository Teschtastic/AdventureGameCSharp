using AdventureGame.Globals;
using Newtonsoft.Json;

namespace AdventureGame.save
{
    public class SaveToFile
    {
        static string workingDirectory = Environment.CurrentDirectory;
        static string projectDirectory = Directory.GetParent(workingDirectory).Parent.Parent.FullName;
        public static void SavePlayerToFile(Player.Player player)
        {
            string saveFilePathJSON = projectDirectory + @"\\save\\player\\Player.json";

            var playerJSONObject = JsonConvert.SerializeObject(player, Formatting.Indented);

            File.WriteAllText(saveFilePathJSON, playerJSONObject);
        }

        public static void SaveRoomsToFile()
        {
            string saveFilePathJSON = projectDirectory + @"\\save\\rooms\\Rooms.json";

            var roomsJSONObject = JsonConvert.SerializeObject(AllObjects.allRooms.allRooms, Formatting.Indented);

            File.WriteAllText(saveFilePathJSON, roomsJSONObject);
        }

        public static void SaveContainersToFile()
        {
            string saveFilePathJSON = projectDirectory + @"\\save\\furniture\\Containers.json";

            var containersJSONObject = JsonConvert.SerializeObject(AllObjects.allFurnitures.ReturnContainers(), Formatting.Indented);

            File.WriteAllText(saveFilePathJSON, containersJSONObject);
        }

        public static void SaveNPCsToFile()
        {
            string saveFilePathJSON = projectDirectory + @"\\save\\npcs\\NPCs.json";

            var npcsJSONObject = JsonConvert.SerializeObject(AllObjects.allNPCs.allNPCs, Formatting.Indented);

            File.WriteAllText(saveFilePathJSON, npcsJSONObject);
        }
    }
}