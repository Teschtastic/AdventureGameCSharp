namespace AdventureGame.Items
{
    public class Consumable : Item, IEquatable<Consumable?>
    {
        public Consumable( string n, string d, string uMessage, int itW, bool cPickup, bool cUse,  bool cC, ItemType type, int sM)
            : base(n, d, uMessage, itW, cPickup, cUse, cC, type)
        {
            StatusModifier = sM;
        }

        public int StatusModifier { get; set; }

        public override bool Equals(object? obj)
        {
            return Equals(obj as Consumable);
        }

        public bool Equals(Consumable? other)
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
                   StatusModifier == other.StatusModifier;
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
            hash.Add(StatusModifier);
            return hash.ToHashCode();
        }
    }
}
