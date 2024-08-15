using AdventureGame.Actions;
using AdventureGame.Game;

namespace AdventureGame.Items
{
    public class Weapon(string n, string d, string uMessage, int itW, bool cPickup, bool cUse, bool cC, Item.ItemType iType, Item.StatusType sType, int sM) : Item(n, d, uMessage, itW, cPickup, cUse, cC, iType, sType, sM), IEquatable<Weapon?>
    {
        public override void UseItem(GameObject game)
        {
            Player.Player player = game.Player;

            if (!player.HasEquippedWeapon)
            {
                Equip(game);
            }
            else if (player.HasEquippedWeapon && player.EquippedWeapon == Name)
            {
                Unequip(game);
            }
            else if (player.HasEquippedWeapon && player.EquippedWeapon != Name)
            {
                Console.WriteLine($"\nYou already have equipped weapon." +
                    $"\nWould you like to unequip your {player.EquippedWeapon}?" +
                    $"\n1 - Yes\n2 - No");
                Actions.Actions.CommandChoice();

                string equipChoice = Console.ReadLine() ?? "";

                switch (equipChoice)
                {
                    case "1":
                        Unequip(game);
                        Equip(game);
                        break;
                    case "2":
                        Console.WriteLine($"\nYou don't un-equip anything.");
                        break;
                    default:
                        Console.WriteLine("\nInvalid choice.");
                        break;
                }
            }
        }

        public void Equip(GameObject game)
        {
            Console.WriteLine($"\nYou equip your {Name}.");
            Console.WriteLine(UseMessage);
            game.Player.EquippedWeapon = Name;
            game.Player.HasEquippedWeapon = true;
            game.Player.UpdatePlayerStatus(StatusModified, StatusModifier, GetStatusModifierDirection());
        }

        public void Unequip(GameObject game)
        {
            Weapon unequipped = (Weapon)game.GetItem(game.Player.EquippedWeapon)!;
            Console.WriteLine($"\nYou un-equip your {game.Player.EquippedWeapon}.");
            game.Player.EquippedWeapon = "Fists";
            game.Player.HasEquippedWeapon = false;
            game.Player.UpdatePlayerStatus(StatusModified, unequipped.StatusModifier, "decreased");
        }
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
