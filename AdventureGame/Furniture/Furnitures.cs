using AdventureGame.save;

namespace AdventureGame.Furnitures
{
    public class Furnitures
    {
        public Dictionary<string, Furniture> furnituresMap = new();

        public Furnitures()
        {
            LoadFromFile.LoadFurnituresFromFile(furnituresMap);
        }
    }
}
