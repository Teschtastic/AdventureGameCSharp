using AdventureGame.NPCs;
using AdventureGame.Furnitures;
using AdventureGame.Items;
using AdventureGame.Rooms;
using AdventureGame.Crafting;
using AdventureGame.Dialogue;
using AdventureGame.LUTs;

namespace AdventureGame.Game
{
    public class AllObjects
    {
        public readonly AllItems          allItems;
        public readonly AllLUTs           allLUTs;
        public readonly AllFurnitures     allFurnitures;
        public readonly AllNPCs           allNPCs;
        public readonly AllRooms          allRooms;
        public readonly AllRecipes        allRecipes;
        public readonly AllDialogues      allDialogues;

        public AllObjects()
        {
            allItems        = new AllItems();
            allLUTs         = new AllLUTs();
            allFurnitures   = new AllFurnitures();
            allNPCs         = new AllNPCs();
            allRooms        = new AllRooms();
            allRecipes      = new AllRecipes();
            allDialogues    = new AllDialogues();
        }
    }
}
