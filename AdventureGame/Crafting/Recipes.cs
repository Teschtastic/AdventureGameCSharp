using AdventureGame.save;

namespace AdventureGame.Crafting
{
    public class Recipes
    {
        // Recipes map
        public Dictionary<string, Recipe> recipesMap = new();

        public Recipes()
        {
            LoadFromFile.LoadRecipesFromFile(recipesMap);
        }
    }
}
