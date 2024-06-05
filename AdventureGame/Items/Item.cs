namespace AdventureGame.Items
{
    public class Item : IEquatable<Item?>
    {
        public Item(string n, string d, string uMessage, int itW, bool cPickup, bool cUse, bool cC, bool iA, bool iW, bool iC)
        {
            Name = n;
            Description = d;
            UseMessage = uMessage;
            ItemWeight = itW;
            CanPickup = cPickup;
            CanUse = cUse;
            CanCraft = cC;
            IsArmor = iA;
            IsWeapon = iW;
            IsConsumable = iC;
        }

        public string Name { get; set; }
        public string Description { get; set; }
        public string UseMessage { get; set; }
        public int ItemWeight { get; set; }
        public bool CanPickup { get; set; }
        public bool CanUse { get; set; }
        public bool CanCraft { get; set; }
        public bool IsArmor { get; set; }
        public bool IsWeapon { get; set; }
        public bool IsConsumable { get; set; }

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
                   IsArmor == other.IsArmor &&
                   IsWeapon == other.IsWeapon &&
                   IsConsumable == other.IsConsumable;
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
            hash.Add(IsArmor);
            hash.Add(IsWeapon);
            hash.Add(IsConsumable);
            return hash.ToHashCode();
        }
    }
}
