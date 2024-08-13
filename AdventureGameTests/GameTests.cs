using AdventureGame.Items;
using AdventureGame.Game;
using AdventureGame.Player;

namespace AdventureGameTests
{
    [TestClass]
    public class GameTests
    {
        [TestMethod]
        public void TestConsumables()
        {
            GameObject gameObject = new();
            foreach (var item in gameObject.Objects.allItems.allItems)
            {
                if (item.Value.KindOfItem == Item.ItemType.Consumable)
                {
                    TestUseConsumable(gameObject, (Consumable)item.Value);
                }
            }
        }

        public static void TestUseConsumable(GameObject gameObject, Consumable consumable)
        {

            Player player = gameObject.Player;
            Player playerCopy = player.DeepCopy();

            int initialMaxWeight = playerCopy.MaximumCarryWeight;
            List<string> initialInventory = [];
            playerCopy.Inventory.ForEach(initialInventory.Add);

            consumable.UseItem(gameObject);

            int postMaxWeight = player.MaximumCarryWeight;
            List<string> postInventory = player.Inventory;

            Assert.AreNotEqual(playerCopy, player);
            Assert.AreEqual(initialMaxWeight + consumable.StatusModifier, postMaxWeight);
            Assert.IsFalse(initialInventory.Equals(postInventory));
        }
    }
}