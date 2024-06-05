using AdventureGame.Items;

namespace AdventureGame.Actions
{
    internal class UsedItemOnPlayer
    {
        public static void UseItem(Player.Player player, Item item)
        {
            switch (item.Name)
            {
                case "Water Bottle":

                case "GFuel":

                case "Dr. Pepper":
                    UsedConsumable(player, (Consumable)item);
                    break;

                case "Desktop PC":
                    UsedPC(player, item);
                    break;

                default:
                    Console.WriteLine("\nThis doesn't seem to help you");
                    break;
            }
        }

        private static void UsedConsumable(Player.Player player, Consumable item)
        {
            Console.WriteLine("\nYour carry weight increased by " + item.StatusModifier + ".");
            player.MaximumCarryWeight += item.StatusModifier;
            player.RemoveFromInventory(item);
            player.AddToInventory("Empty Bottle");
        }

        private static void UsedPC(Player.Player player, Item item)
        {
            Console.WriteLine(
                    "\nYou look up fighting techniques\non the internet." +
                    "\nYour attack damage goes up by 10.");

            player.AttackDamage += 10;
            item.CanUse = false;
        }
    }
}
