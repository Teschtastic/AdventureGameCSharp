using AdventureGame.save;

namespace AdventureGame.Items
{
    public class Consumables
    {
        public Dictionary<string, Consumable> consumablesMap = new();

        public Consumables()
        {
            LoadFromFile.LoadConsumablesFromFile(consumablesMap);
        }
    }
}
