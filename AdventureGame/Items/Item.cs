using AdventureGame.Game;

namespace AdventureGame.Items
{
    public class Item(string n, string d, string uMessage, int itW, bool cPickup, bool cUse, bool cC, Item.ItemType iType, Item.StatusType sType) : IEquatable<Item?>
    {
        public enum ItemType
        {
            Default,
            Armor,
            Weapon,
            Consumable,
            Trainer
        }

        public enum StatusType
        {
            Default,
            Name,
            CurrentHealth,
            MaximumHealth,
            ArmorClass,
            AttackDamage,
            CurrentCarryWeight,
            MaximumCarryWeight
        }

        public string Name { get; set; } = n;
        public string Description { get; set; } = d;
        public string UseMessage { get; set; } = uMessage;
        public int ItemWeight { get; set; } = itW;
        public bool CanPickup { get; set; } = cPickup;
        public bool CanUse { get; set; } = cUse;
        public bool CanCraft { get; set; } = cC;
        public ItemType KindOfItem { get; set; } = iType;
        public StatusType StatusModified { get; set; } = sType;

        public bool CanUseItem()
        {

            if (!CanUse)
            {
                Console.WriteLine("\nYou can't use " + Name);
                return false;
            }
            return true;
        }

        public virtual void UseItem(GameObject game)
        {
            if (CanUseItem())
                Console.WriteLine("\nThis doesn't seem to help you");
        }

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
                   KindOfItem == other.KindOfItem &&
                   StatusModified == other.StatusModified;
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
            hash.Add(KindOfItem);
            hash.Add(StatusModified);
            return hash.ToHashCode();
        }
    }
}
