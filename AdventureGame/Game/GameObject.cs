using AdventureGame.save;
using AdventureGame.Rooms;
using AdventureGame.NPCs;
using AdventureGame.Items;
using AdventureGame.Crafting;
using AdventureGame.Furnitures;
using AdventureGame.Dialogue;
using AdventureGame.Actions;
using AdventureGame.LUTs;

namespace AdventureGame.Game
{
    public class GameObject
    {

        public GameObject() 
        {
            UserActions = new Actions.Actions().actionsMap;
            IsRunning = true;
            PlayerChoice = "";
            AllObjects = new();
            GamePlayer = LoadFromFile.LoadPlayerFromFile(AllObjects);
        }

        public Dictionary<int, List<string>> UserActions { get; set; }
        private Player.Player GamePlayer { get; set; } 
        public bool IsRunning { get; set; }
        public string PlayerChoice { get; set; }
        private AllObjects AllObjects { get; set; }

        public Player.Player GetPlayer()
        {
            return GamePlayer; 
        }

        public void GetUserChoice(ref int choice)
        {
            Actions.Actions.CommandChoice();

            string? action = Console.ReadLine();  // Reads the next line into the player's action

            // Checks to see if the user choice is defined in the actions scope,
            // then assigns it to an int
            foreach (var entry in UserActions)
            {
                if (action != null && entry.Value.Contains(action.ToLower()))
                {
                    choice = entry.Key;
                    PlayerChoice = action;
                }
            }
        }

        public string GetPlayerMove()
        {
           return PlayerChoice != null ? PlayerChoice.ToUpper() : "";
        }

        public Room? GetRoom(string roomName)
        {
            return AllObjects.allRooms.GetRoom(roomName);
        }

        public List<Room> GetRooms()
        {
            return AllObjects.allRooms.GetRooms();
        }

        public List<Room> GetRooms(List<string> roomNames)
        {
            return AllObjects.allRooms.GetRooms(roomNames);
        }

        public Dictionary<string, Room> GetRoomsDictionary()
        {
            return AllObjects.allRooms.allRooms;
        }

        public Room? GetRoomPlayerIsIn()
        {
            return GetRoom(GamePlayer.RoomIsIn);
        }

        public void SetRoomPlayerIsIn(string roomName)
        {
            GamePlayer.RoomIsIn = roomName;
        }

        public NPC? GetNPC(string npcName)
        {
            return AllObjects.allNPCs.GetNPC(npcName);
        }

        public NPC? GetNPCInRoom()
        {
            return GetNPC(GetRoomPlayerIsIn().NPCInRoom);
        }

        public List<NPC> GetNPCs()
        {
            return AllObjects.allNPCs.GetNPCs();
        }

        public List<NPC> GetNPCs(List<string> npcNames)
        {
            return AllObjects.allNPCs.GetNPCs(npcNames);
        }

        public Dictionary<string, NPC> GetNPCDictionary()
        {
            return AllObjects.allNPCs.allNPCs;
        }

        public Furniture? GetFurniture(string furnitureName)
        {
            return AllObjects.allFurnitures.GetFurniture(furnitureName);
        }

        public List<Furniture> GetFurnitures(List<string > furnitureNames)
        {
            return AllObjects.allFurnitures.GetFurnitures(furnitureNames);
        }

        public Furniture? GetFurnitureInRoom()
        {
            return GetFurniture(GetRoomPlayerIsIn().FurnitureInRoom);
        }

        public List<Container> GetContainersList()
        {
            return AllObjects.allFurnitures.ReturnContainers().Values.ToList();
        }

        public Dictionary<string, Container> GetContainersDictionary()
        {
            return AllObjects.allFurnitures.ReturnContainers();
        }

        public Item GetItem(string itemName)
        {
            return AllObjects.allItems.GetItem(itemName);
        }

        public Item GetItemInRoom()
        {
            return GetItem(GetRoomPlayerIsIn().ItemInRoom);
        }

        public Item GetItemInInventory(List<string> inventory)
        {
            return GetItem(PlayerActions.TakeItemFromInventory(inventory));
        }

        public Item GetItemInInventory(List<Item> inventory)
        {
            List<string> items = new();
            foreach (Item i in inventory)
                items.Append(i.Name);

            return GetItem(PlayerActions.TakeItemFromInventory(items));
        }

        public List<Item> GetItemsInInventory()
        {
            return GetItems(GamePlayer.Inventory);
        }

        public List<Item> GetItems(List<string> itemNames)
        {
            return AllObjects.allItems.GetItems(itemNames);
        }

        public Recipe? GetRecipe(string recipeName)
        {
            return AllObjects.allRecipes.GetRecipe(recipeName);
        }

        public List<Recipe> GetRecipes(List<string> recipeNames)
        {
            return AllObjects.allRecipes.GetRecipes(recipeNames);
        }

        public DialogueList GetNPCDialogue(string NPCName)
        {
            return AllObjects.allDialogues.GetDialogueList(NPCName);
        }

        public LUT GetLUT(string lut)
        {
            return AllObjects.allLUTs.GetLUT(lut);
        }
    }
}
