using AdventureGame.Game;
using AdventureGame.Items;
using AdventureGame.Player;

namespace AdventureGame.Actions
{
    internal class UsedItemOnPlayer
    {
        public static void UseItem(GameObject game, Item item)
        {
            switch (item.Name)
            {
                case "Water Bottle":

                case "GFuel":

                case "Dr. Pepper":
                    UsedConsumable(game, (Consumable)item);
                    break;

                case "Desktop PC":
                    UsedPC(game, item);
                    break;

                default:
                    Console.WriteLine("\nThis doesn't seem to help you");
                    break;
            }
        }

        private static void UsedConsumable(GameObject game, Consumable item)
        {
            Player.Player player = game.GetPlayer();
            Console.WriteLine("\nYour carry weight increased by " + item.StatusModifier + ".");
            player.MaximumCarryWeight += item.StatusModifier;
            player.RemoveFromInventory(item);
            player.AddToInventory(game.GetItem("Empty Bottle"));
        }

        private static void UsedPC(GameObject game, Item item)
        {
            Player.Player player = game.GetPlayer();
            Console.WriteLine(
                    "\nYou look up fighting techniques\non the internet." +
                    "\nYour attack damage goes up by 10.");

            player.AttackDamage += 10;
            item.CanUse = false;
        }
    }
}
