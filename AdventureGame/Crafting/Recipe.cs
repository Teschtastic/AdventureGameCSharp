namespace AdventureGame.Crafting
{
    public class Recipe
    {
        public Recipe(List<string> craftingItems, string craftedItem)
        {
            InputItems = craftingItems;
            OutputItem = craftedItem;
        }

        public List<string>  InputItems { get; set; }
        public string        OutputItem { get; set; }

        public bool CanCraft(List<string> inventory)
        {
            return InputItems.All(it => inventory.Contains(it));
        }
    }
}
