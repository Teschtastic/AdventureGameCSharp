namespace AdventureGame.Items
{
    public class Armor : Item, IEquatable<Armor?>
    {
        public Armor( string n, string d, string uMessage, int itW, bool cPickup, bool cUse, bool cC, ItemType type, int aC)
            : base(n, d, uMessage, itW, cPickup, cUse, cC, type)
        {
            ArmorClass = aC;
        }

        public int ArmorClass { get; set; }

        public override bool Equals(object? obj)
        {
            return Equals(obj as Armor);
        }

        public bool Equals(Armor? other)
        {
            return other is not null &&
                   base.Equals(other) &&
                   Name == other.Name &&
                   Description == other.Description &&
                   UseMessage == other.UseMessage &&
                   ItemWeight == other.ItemWeight &&
                   CanPickup == other.CanPickup &&
                   CanUse == other.CanUse &&
                   CanCraft == other.CanCraft &&
                   Type == other.Type &&
                   ArmorClass == other.ArmorClass;
        }

        public override int GetHashCode()
        {
            HashCode hash = new();
            hash.Add(base.GetHashCode());
            hash.Add(Name);
            hash.Add(Description);
            hash.Add(UseMessage);
            hash.Add(ItemWeight);
            hash.Add(CanPickup);
            hash.Add(CanUse);
            hash.Add(CanCraft);
            hash.Add(Type);
            hash.Add(ArmorClass);
            return hash.ToHashCode();
        }
    }
}
