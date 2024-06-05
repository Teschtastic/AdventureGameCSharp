using AdventureGame.Crafting;
using AdventureGame.Dialogue;
using AdventureGame.Furnitures;
using AdventureGame.Globals;
using AdventureGame.Items;
using AdventureGame.LUTs;
using AdventureGame.NPCs;
using AdventureGame.Rooms;
using Newtonsoft.Json;

namespace AdventureGame.save
{
    public class LoadFromFile
	{
        static string workingDirectory = Environment.CurrentDirectory;
        static string projectDirectory = Directory.GetParent(workingDirectory).Parent.Parent.FullName;

        public static void LoadPlayerFromFile(out Player.Player? player)
		{
            string saveFilePathJSON = projectDirectory + @"\\save\\player\\Player.json";

            string playerStatsFile = File.ReadAllText(saveFilePathJSON);
            var playerJSONObject = JsonConvert.DeserializeObject<Player.Player>(playerStatsFile);

            if (playerJSONObject != null)
			{
                player = playerJSONObject;

                var items = AllObjects.allItems.GetItems(playerJSONObject.Inventory);
                int weight = 0;

                foreach (var item in items)
                {
                    weight += item.ItemWeight;
                }

                player.CurrentCarryWeight = weight;
            }
			else
			{
				Console.WriteLine("An error occurred loading the player from file.");
                player = null;
			}
		}

        public static void LoadItemsFromFile(Dictionary<string, Item> itemsMap)
        {
            string itemFilePathJSON = projectDirectory + @"\\save\\items\\Items.json";

            string itemFile = File.ReadAllText(itemFilePathJSON);
            var itemJSONObject = JsonConvert.DeserializeObject<Dictionary<string, Item>>(itemFile);

            if (itemJSONObject != null)
            {
                foreach (var item in itemJSONObject)
                {
                    itemsMap.Add(item.Key,
                        new(
                            item.Value.Name,
                            item.Value.Description,
                            item.Value.UseMessage,
                            item.Value.ItemWeight,
                            item.Value.CanPickup,
                            item.Value.CanUse,
                            item.Value.CanCraft,
                            item.Value.IsArmor,
                            item.Value.IsWeapon,
                            item.Value.IsConsumable
                            ));
                }
            }
            else
            {
                Console.WriteLine("An error occurred loading the items from file.");
            }
        }

        public static void LoadConsumablesFromFile(Dictionary<string, Consumable> consumablesMap)
        {
            string consumableFilePathJSON = projectDirectory + @"\\save\\items\\Consumables.json";

            string consumableFile = File.ReadAllText(consumableFilePathJSON);
            var consumableJSONObject = JsonConvert.DeserializeObject<Dictionary<string, Consumable>>(consumableFile);

            if (consumableJSONObject != null)
            {
                foreach (var consumable in consumableJSONObject)
                {
                    consumablesMap.Add(consumable.Key,
                        new(
                            consumable.Value.Name,
                            consumable.Value.Description,
                            consumable.Value.UseMessage,
                            consumable.Value.ItemWeight,
                            consumable.Value.CanPickup,
                            consumable.Value.CanUse,
                            consumable.Value.CanCraft,
                            consumable.Value.IsArmor,
                            consumable.Value.IsWeapon,
                            consumable.Value.IsConsumable,
                            consumable.Value.StatusModifier
                            ));
                }
            }
            else
            {
                Console.WriteLine("An error occurred loading the consumables from file.");
            }
        }

        public static void LoadArmorsFromFile(Dictionary<string, Armor> armorsMap)
        {
            string armorsFilePathJSON = projectDirectory + @"\\save\\items\\Armors.json";

            string armorFile = File.ReadAllText(armorsFilePathJSON);
            var armorJSONObject = JsonConvert.DeserializeObject<Dictionary<string, Armor>>(armorFile);

            if (armorJSONObject != null)
            {
                foreach (var armor in armorJSONObject)
                {
                    armorsMap.Add(armor.Key,
                        new(
                            armor.Value.Name,
                            armor.Value.Description,
                            armor.Value.UseMessage,
                            armor.Value.ItemWeight,
                            armor.Value.CanPickup,
                            armor.Value.CanUse,
                            armor.Value.CanCraft,
                            armor.Value.IsArmor,
                            armor.Value.IsWeapon,
                            armor.Value.IsConsumable,
                            armor.Value.ArmorClass
                            ));
                }
            }
            else
            {
                Console.WriteLine("An error occurred loading the armors from file.");
            }
        }

        public static void LoadWeaponsFromFile(Dictionary<string, Weapon> weaponsMap)
        {
            string weaponsFilePathJSON = projectDirectory + @"\\save\\items\\Weapons.json";

            string weaponFile = File.ReadAllText(weaponsFilePathJSON);
            var weaponJSONObject = JsonConvert.DeserializeObject<Dictionary<string, Weapon>>(weaponFile);

            if (weaponJSONObject != null)
            {
                foreach (var weapon in weaponJSONObject)
                {
                    weaponsMap.Add(weapon.Key,
                        new(
                            weapon.Value.Name,
                            weapon.Value.Description,
                            weapon.Value.UseMessage,
                            weapon.Value.ItemWeight,
                            weapon.Value.CanPickup,
                            weapon.Value.CanUse,
                            weapon.Value.CanCraft,
                            weapon.Value.IsArmor,
                            weapon.Value.IsWeapon,
                            weapon.Value.IsConsumable,
                            weapon.Value.AttackDamage
                            ));
                }
            }
            else
            {
                Console.WriteLine("An error occurred loading the weapons from file.");
            }
        }

        public static void LoadFurnituresFromFile(Dictionary<string, Furniture> furnituresMap)
        {
            string furnitureFilePathJSON = projectDirectory + @"\\save\\furniture\\Furnitures.json";

            string furnitureFile = File.ReadAllText(furnitureFilePathJSON);
            var furnitureJSONObject = JsonConvert.DeserializeObject<Dictionary<string, Furniture>>(furnitureFile);

            if (furnitureJSONObject != null)
            {
                foreach (var furniture in furnitureJSONObject)
                {
                    furnituresMap.Add(furniture.Key,
                        new(
                            furniture.Value.Name,
                            furniture.Value.Description,
                            furniture.Value.UseMessage,
                            furniture.Value.CanUse
                            ));
                }
            }
            else
            {
                Console.WriteLine("An error occurred loading the furnitures from file.");
            }
        }

        public static void LoadLUTsFromFile(Dictionary<string, LUT> lutsMap)
        {
            string saveFilePathJSON = projectDirectory + @"\\save\\luts\\LUTs.json";
            string lutFile = File.ReadAllText(saveFilePathJSON);
            var lutJSONObject = Lut.FromJson(lutFile);

            if (lutJSONObject != null)
            {
                foreach (var lut in lutJSONObject)
                {
                    lutsMap.Add(lut.Key, lut.Value);
                }
            }
            else
            {
                Console.WriteLine("An error occurred loading the luts from file.");
            }
        }

        public static void LoadContainersFromFile(Dictionary<string, Container> containersMap)
        {
            string containerFilePathJSON = projectDirectory + @"\\save\\furniture\\Containers.json";
            
            string containerFile = File.ReadAllText(containerFilePathJSON);
            var containerJSONObject = JsonConvert.DeserializeObject<Dictionary<string, Container>>(containerFile);

            if (containerJSONObject != null)
            {
                foreach (var container in containerJSONObject)
                {
                    containersMap.Add(container.Key,
                        new(
                            container.Value.Name,
                            container.Value.Description,
                            container.Value.UseMessage,
                            container.Value.CanUse,
                            container.Value.FirstOpen,
                            container.Value.Lut
                            ));

                    if (container.Value.FirstOpen == true)
                    {
                        containersMap[container.Key].AddToInventory(container.Value.InventoryNames);
                    }
                }
            }
            else
            {
                Console.WriteLine("An error occurred loading the containers from file.");
            }
        }

        public static void LoadRoomsFromFile(Dictionary<string, Room> rooms)
        {
            string roomFilePathJSON = projectDirectory + @"\\save\\rooms\\Rooms.json";

            string roomFile = File.ReadAllText(roomFilePathJSON);
            var roomJSONObject = JsonConvert.DeserializeObject<Dictionary<string, Room>>(roomFile);

            if (roomJSONObject != null)
            {
                foreach (var room in roomJSONObject)
                {
                    rooms.Add(room.Key,
                        new(
                            room.Value.Name,
                            room.Value.HasItem,
                            room.Value.ItemInRoom,
                            room.Value.HasNPC,
                            room.Value.NPCInRoom,
                            room.Value.HasFurniture,
                            room.Value.FurnitureInRoom,
                            room.Value.ConnRooms
                            ));
                }
            }
            else
            {
                Console.WriteLine("An error occurred loading the rooms from file.");
            }
        }

        public static void LoadDialoguesFromFile(Dictionary<string, DialogueList> dialogues)
        {
            string dialogueFilePathJSON = projectDirectory + @"\\save\\dialogue\\Dialogue.json";

            string dialogueFile = File.ReadAllText(dialogueFilePathJSON);
            var dialogueJSONObject = Dialogue.Dialogue.FromJson(dialogueFile);

            if (dialogueJSONObject != null)
            {
                foreach (var dialogueMap in dialogueJSONObject)
                {
                    dialogues.Add(dialogueMap.Key, dialogueMap.Value);
                }
            }
            else
            {
                Console.WriteLine("An error occurred loading the dialogues from file.");
            }
        }

        public static void LoadNPCsFromFile(Dictionary<string, NPC> npcs)
        {
            string npcFilePathJSON = projectDirectory + @"\\save\\npcs\\NPCs.json";

            string npcFile = File.ReadAllText(npcFilePathJSON);
            var npcJSONObject = JsonConvert.DeserializeObject<Dictionary<string, NPC>>(npcFile);

            if (npcJSONObject != null)
            {
                foreach (var npc in npcJSONObject)
                {
                    npcs.Add(npc.Key,
                        new(
                            npc.Value.Name,
                            npc.Value.Dialogue,
                            npc.Value.CurrentHealth,
                            npc.Value.MaximumHealth,
                            npc.Value.ArmorClass,
                            npc.Value.AttackDamage,
                            npc.Value.IsFriendly,
                            npc.Value.EquippedArmor,
                            npc.Value.HasEquippedArmor,
                            npc.Value.EquippedWeapon,
                            npc.Value.HasEquippedWeapon,
                            npc.Value.Inventory
                            ));
                }
            }
            else
            {
                Console.WriteLine("An error occurred loading the npcs from file.");
            }
        }

        public static void LoadRecipesFromFile(Dictionary<string, Recipe> recipes)
        {
            string recipeFilePathJSON = projectDirectory + @"\\save\\recipes\\Recipes.json";

            string recipeFile = File.ReadAllText(recipeFilePathJSON);
            var recipeJSONObject = JsonConvert.DeserializeObject<Dictionary<string, Recipe>>(recipeFile);

            if (recipeJSONObject != null)
            {
                foreach (var recipe in recipeJSONObject)
                {
                    recipes.Add(recipe.Key,
                        new(
                            recipe.Value.InputItems,
                            recipe.Value.OutputItem
                            ));
                }
            }
            else
            {
                Console.WriteLine("An error occurred loading the recipes from file.");
            }
        }
    }
}
