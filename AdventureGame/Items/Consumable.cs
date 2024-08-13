using AdventureGame.Game;

namespace AdventureGame.Items
{
    public class Consumable(string n, string d, string uMessage, int itW, bool cPickup, bool cUse, bool cC, Item.ItemType iType, Item.StatusType sType, int sM) : Item(n, d, uMessage, itW, cPickup, cUse, cC, iType, sType), IEquatable<Consumable?>
    {
        public int StatusModifier { get; set; } = sM;

        public override void UseItem(GameObject game)
        {
            if (CanUseItem())
            {
                Player.Player player = game.Player;

                Console.WriteLine(UseMessage);
                Console.WriteLine($"\nYour {StatusModified} increased by {StatusModifier}.");
                player.UpdatePlayerStatus(StatusModified, StatusModifier);
                player.RemoveFromInventory(this);
                player.AddToInventory(game.GetItem("Empty Bottle")!);
            }
        }

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
                   KindOfItem == other.KindOfItem &&
                   StatusModified == other.StatusModified &&
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
            hash.Add(KindOfItem);
            hash.Add(StatusModified);
            hash.Add(StatusModifier);
            return hash.ToHashCode();
        }
    }
}
