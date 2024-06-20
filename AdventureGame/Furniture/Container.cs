using AdventureGame.Items;

namespace AdventureGame.Furnitures
{
    public class Container : Furniture
    {
        public Container(string n, string d, string uMessage, bool cUse, bool firstOpen, string lut)
            : base(n, d, uMessage, cUse)
        {
            InventoryNames  = new();
            FirstOpen       = firstOpen;
            Lut             = lut;
        }

        public List<string> InventoryNames  { get; set; }
        public bool         FirstOpen       { get; set; }
        public string       Lut             { get; set; }

        public void AddToInventory(Item item)
        {
            InventoryNames.Add(item.Name);
        }

        public void AddToInventory(string itemName)
        {
            InventoryNames.Add(itemName);
        }

        public void AddToInventory(List<Item> items)
        {
            foreach (Item item in items)
            {
                AddToInventory(item);
            }
        }

        public void AddToInventory(List<string> itemNames)
        {
            foreach (string itemName in itemNames)
            {
                AddToInventory(itemName);
            }
        }

        public void RemoveFromInventory(Item item)
        {
            InventoryNames.Remove(item.Name);
        }

        public void RemoveFromInventory(string itemName)
        {
            InventoryNames.Remove(itemName);
        }


        public void RemoveFromInventory(List<Item> items)
        {
            foreach (Item item in items)
            {
                RemoveFromInventory(item);
            }
        }

        public void RemoveFromInventory(List<string> itemNames)
        {
            foreach (string itemName in itemNames.ToList())
            {
                RemoveFromInventory(itemName);
            }
        }
    }
}