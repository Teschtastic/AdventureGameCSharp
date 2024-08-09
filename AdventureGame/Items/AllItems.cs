namespace AdventureGame.Items
{
    public class AllItems
    {
        // Different Item maps
        private readonly Dictionary<string, Item> items             = new Items().itemsMap;
        private readonly Dictionary<string, Armor> armors           = new Armors().armorMap;
        private readonly Dictionary<string, Weapon> weapons         = new Weapons().weaponMap;
        private readonly Dictionary<string, Consumable> consumables = new Consumables().consumablesMap;
        private readonly Dictionary<string, Trainer> trainers       = new Trainers().trainersMap;

        public Dictionary<string, Item> allItems = [];

        public AllItems()
        {
            items.ToList().ForEach(         x => allItems.Add(x.Key, x.Value));
            armors.ToList().ForEach(        x => allItems.Add(x.Key, x.Value));
            weapons.ToList().ForEach(       x => allItems.Add(x.Key, x.Value));
            consumables.ToList().ForEach(   x => allItems.Add(x.Key, x.Value));
            trainers.ToList().ForEach(      x => allItems.Add(x.Key, x.Value));
        }

        public Item? GetItem(string itemName)
        {
            return allItems.ContainsKey(itemName) ? allItems[itemName] : null;
        }

        public List<Item> GetItems(List<string> itemNames)
        {
            var items = new List<Item>();
            foreach (string itemName in itemNames)
            {
                var item = GetItem(itemName);
                if (item != null)
                {
                    items.Add(item);
                }
            }
            return items;
        }
    }
}
