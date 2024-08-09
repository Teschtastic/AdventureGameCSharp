using AdventureGame.Game;
using AdventureGame.Items;

namespace AdventureGame.Actions
{
    internal class UsedItemOnPlayer
    {
        public static void UseItem(GameObject game, Item item)
        {
            switch (item.KindOfItem)
            {
                case Item.ItemType.Consumable:
                    ((Consumable)item).UseConsumable(game);
                    break;

                case Item.ItemType.Trainer:
                   ((Trainer)item).UseTrainer(game);
                    break;

                default:
                    Console.WriteLine("\nThis doesn't seem to help you");
                    break;
            }
        }
    }
}
