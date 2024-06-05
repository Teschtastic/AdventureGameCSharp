namespace AdventureGame.Items
{
    public class Weapon : Item, IEquatable<Weapon?>
    {
        public Weapon(string n, string d, string uMessage, int itW, bool cPickup, bool cUse, bool cC, bool iA, bool iW, bool iC, int aD)
            : base(n, d, uMessage, itW, cPickup, cUse, cC, iA, iW, iC)
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
                   IsArmor == other.IsArmor &&
                   IsWeapon == other.IsWeapon &&
                   IsConsumable == other.IsConsumable &&
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
            hash.Add(IsArmor);
            hash.Add(IsWeapon);
            hash.Add(IsConsumable);
            hash.Add(AttackDamage);
            return hash.ToHashCode();
        }
    }
}
