namespace AdventureGame.Items
{
    public class Weapon : Item, IEquatable<Weapon?>
    {
        public Weapon(string n, string d, string uMessage, int itW, bool cPickup, bool cUse, bool cC, ItemType type, int aD)
            : base(n, d, uMessage, itW, cPickup, cUse, cC, type)
        {
            AttackDamage = aD;
        }

        public int AttackDamage { get; set; }

        public override bool Equals(object? obj)
        {
            return Equals(obj as Weapon);
        }

        public bool Equals(Weapon? other)
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
                   AttackDamage == other.AttackDamage;
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
            hash.Add(AttackDamage);
            return hash.ToHashCode();
        }
    }
}
