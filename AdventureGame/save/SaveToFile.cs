﻿using AdventureGame.Furnitures;
using AdventureGame.Game;
using AdventureGame.NPCs;
using AdventureGame.Rooms;
using Newtonsoft.Json;

namespace AdventureGame.save
{
    public class SaveToFile
    {
        static readonly string workingDirectory = Environment.CurrentDirectory;
        static readonly string projectDirectory = Directory.GetParent(workingDirectory)!.Parent!.Parent!.FullName;
        public static void SavePlayerToFile(Player.Player player)
        {
            string saveFilePathJSON = projectDirectory + "/save/player/Player.json";

            var playerJSONObject = JsonConvert.SerializeObject(player, Formatting.Indented);

            File.WriteAllText(saveFilePathJSON, playerJSONObject);
        }

        public static void SaveRoomsToFile(Dictionary<string, Room> rooms)
        {
            string saveFilePathJSON = projectDirectory + "/save/rooms/Rooms.json";

            var roomsJSONObject = JsonConvert.SerializeObject(rooms, Formatting.Indented);

            File.WriteAllText(saveFilePathJSON, roomsJSONObject);
        }

        public static void SaveContainersToFile(Dictionary<string, Container> containers)
        {
            string saveFilePathJSON = projectDirectory + "/save/furniture/Containers.json";

            var containersJSONObject = JsonConvert.SerializeObject(containers, Formatting.Indented);

            File.WriteAllText(saveFilePathJSON, containersJSONObject);
        }

        public static void SaveNPCsToFile(Dictionary<string, NPC> allNPCs)
        {
            string saveFilePathJSONnpcs = projectDirectory + "/save/npcs/NPCs.json";
            string saveFilePathJSONenemies = projectDirectory + "/save/npcs/Enemies.json";

            Dictionary<string, NPC> npcs = [];
            Dictionary<string, NPC> enemies = [];

            foreach (var npc in allNPCs)
            {
                if (npc.Value.IsNPCAnEnemy())
                    enemies.Add(npc.Key, npc.Value);
                else
                    npcs.Add(npc.Key, npc.Value);
            }

            var npcsJSONObject = JsonConvert.SerializeObject(npcs, Formatting.Indented);
            var enemiesJSONObject = JsonConvert.SerializeObject(enemies, Formatting.Indented);

            File.WriteAllText(saveFilePathJSONnpcs, npcsJSONObject);
            File.WriteAllText(saveFilePathJSONenemies, enemiesJSONObject);
        }

        public static void SaveGameObjectToFile(GameObject game)
        {
            string saveFilePathJSON = projectDirectory + "/save/game/Game.json";

            var gameJSONObject = JsonConvert.SerializeObject(game, Formatting.Indented);

            File.WriteAllText(saveFilePathJSON, gameJSONObject);
        }
    }
}