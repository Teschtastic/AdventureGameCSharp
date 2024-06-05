using AdventureGame.NPCs;
using AdventureGame.Furnitures;
using AdventureGame.Items;
using AdventureGame.Rooms;
using AdventureGame.Crafting;
using AdventureGame.Dialogue;
using AdventureGame.LUTs;

namespace AdventureGame.Globals
{
    public static class AllObjects
    {
        public static readonly AllItems          allItems;
        public static readonly AllLUTs           allLUTs;
        public static readonly AllFurnitures     allFurnitures;
        public static readonly AllNPCs           allNPCs;
        public static readonly AllRooms          allRooms;
        public static readonly AllRecipes        allRecipes;
        public static readonly AllDialogues      allDialogues;

        static AllObjects()
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
