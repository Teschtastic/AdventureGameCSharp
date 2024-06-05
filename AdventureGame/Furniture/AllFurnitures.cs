namespace AdventureGame.Furnitures
{
    public class AllFurnitures
    {
        // Different Furniture maps
        private readonly Dictionary<string, Furniture> furnitures = new Furnitures().furnituresMap;
        private readonly Dictionary<string, Container> containers = new Containers().containersMap;

        public Dictionary<string, Furniture> allFurnitures = new();

        public AllFurnitures()
        {
            furnitures.ToList().ForEach(x => allFurnitures.Add(x.Key, x.Value));
            containers.ToList().ForEach(x => allFurnitures.Add(x.Key, x.Value));
        }

        public Furniture GetFurniture(string furnitureName)
        {
            return allFurnitures.ContainsKey(furnitureName) ? allFurnitures[furnitureName] : null;
        }

        public List<Furniture> GetFurnitures(List<string> furnitureNames)
        {
            var furnitures = new List<Furniture>();
            foreach (string furnitureName in furnitureNames)
            {
                var furniture = GetFurniture(furnitureName);
                if (furniture != null)
                {
                    furnitures.Add(furniture);
                }
            }
            return furnitures;
        }

        public Dictionary<string, Container> ReturnContainers()
        {
            return containers;
        }

        public Dictionary<string, Furniture> ReturnFurniture()
        {
            return furnitures;
        }
    }
}
