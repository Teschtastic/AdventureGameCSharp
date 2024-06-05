using AdventureGame.save;

namespace AdventureGame.Furnitures
{
    public class Containers
    {
        public Dictionary<string, Container> containersMap = new();

        public Containers()
        {
            LoadFromFile.LoadContainersFromFile(containersMap);
        }
    }
}
