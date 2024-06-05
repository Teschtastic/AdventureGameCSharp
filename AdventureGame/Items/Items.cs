using AdventureGame.save;

namespace AdventureGame.Items
{
    public class Items
    {
        // HashMap the items are stored in
        public Dictionary<string, Item> itemsMap = new();

        public Items()
        {
            LoadFromFile.LoadItemsFromFile(itemsMap);
        }
    }
}
