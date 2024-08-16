using AdventureGame.Game;

namespace AdventureGame.Items
{
    public class Armor(string n, string d, string uMessage, int itW, bool cPickup, bool cUse, bool cC, Item.ItemType iType, Item.StatusType sType, int sM) : Item(n, d, uMessage, itW, cPickup, cUse, cC, iType, sType, sM), IEquatable<Armor?>
    {
        public override void UseItem(GameObject game)
        {
            Player.Player player = game.Player;

            if(!player.HasEquippedArmor)
            {
                Equip(game);
            }
            else if(player.HasEquippedArmor && player.EquippedArmor == Name)
            {
                Unequip(game);
            }
            else if(player.HasEquippedArmor && player.EquippedArmor != Name)
            {
                Console.WriteLine($"\nYou already have equipped armor." +
                    $"\nWould you like to unequip your {player.EquippedArmor}?" +
                    $"\n1 - Yes\n2 - No");
                Actions.Actions.CommandChoice();

                string equipChoice = Console.ReadLine() ?? "";

                switch(equipChoice)
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
            game.Player.EquippedArmor = Name;
            game.Player.HasEquippedArmor = true;
            game.Player.UpdatePlayerStatus(StatusModified, StatusModifier, GetStatusModifierDirection());
        }

        public void Unequip(GameObject game)
        {
            Armor unequipped = (Armor)game.GetItem(game.Player.EquippedArmor)!;
            Console.WriteLine($"\nYou un-equip your {game.Player.EquippedArmor}.");
            game.Player.EquippedArmor = "Clothes";
            game.Player.HasEquippedArmor = false;
            game.Player.UpdatePlayerStatus(StatusModified, unequipped.StatusModifier, "decreased");
        }

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
