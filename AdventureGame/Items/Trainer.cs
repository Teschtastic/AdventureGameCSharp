using AdventureGame.Game;

namespace AdventureGame.Items
{
    public class Trainer(string n, string d, string uMessage, int itW, bool cPickup, bool cUse, bool cC, Item.ItemType iType, Item.StatusType sType, int sM) : Item(n, d, uMessage, itW, cPickup, cUse, cC, iType, sType, sM), IEquatable<Trainer?>
    {
        public override void UseItem(GameObject game)
        {
            Player.Player player = game.Player;

            Console.WriteLine(UseMessage);
            Console.WriteLine( "\nYou look up fighting techniques\non the internet.");

            player.UpdatePlayerStatus(StatusModified, StatusModifier, GetStatusModifierDirection());
            CanUse = false;
        }

        public override bool Equals(object? obj)
        {
            return Equals(obj as Trainer);
        }

        public bool Equals(Trainer? other)
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
