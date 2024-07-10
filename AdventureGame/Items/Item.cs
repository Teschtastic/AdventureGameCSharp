namespace AdventureGame.Items
{
    public class Item : IEquatable<Item?>
    {
        public enum ItemType
        {
            Default,
            Armor,
            Weapon,
            Consumable
        }

        public Item(string n, string d, string uMessage, int itW, bool cPickup, bool cUse, bool cC, ItemType type)
        {
            Name = n;
            Description = d;
            UseMessage = uMessage;
            ItemWeight = itW;
            CanPickup = cPickup;
            CanUse = cUse;
            CanCraft = cC;
            Type = type;
        }

        public string Name { get; set; }
        public string Description { get; set; }
        public string UseMessage { get; set; }
        public int ItemWeight { get; set; }
        public bool CanPickup { get; set; }
        public bool CanUse { get; set; }
        public bool CanCraft { get; set; }
        public ItemType Type { get; set; }

        public override bool Equals(object? obj)
        {
            return Equals(obj as Item);
        }

        public bool Equals(Item? other)
        {
            return other is not null &&
                   Name == other.Name &&
                   Description == other.Description &&
                   UseMessage == other.UseMessage &&
                   ItemWeight == other.ItemWeight &&
                   CanPickup == other.CanPickup &&
                   CanUse == other.CanUse &&
                   CanCraft == other.CanCraft &&
                   Type == other.Type;
        }

        public override int GetHashCode()
        {
            HashCode hash = new();
            hash.Add(Name);
            hash.Add(Description);
            hash.Add(UseMessage);
            hash.Add(ItemWeight);
            hash.Add(CanPickup);
            hash.Add(CanUse);
            hash.Add(CanCraft);
            hash.Add(Type);
            return hash.ToHashCode();
        }
    }
}
