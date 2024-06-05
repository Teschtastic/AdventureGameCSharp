namespace AdventureGame.Crafting
{
    public class AllRecipes
    {
        // Different recipes lists
        private readonly Dictionary<string, Recipe> recipes = new Recipes().recipesMap;

        public Dictionary<string, Recipe> allRecipes = new();

        public AllRecipes()
        {
            recipes.ToList().ForEach(x => allRecipes.Add(x.Key, x.Value));
        }

        public Recipe? GetRecipe(string recipeName)
        {
            return allRecipes.ContainsKey(recipeName) ? allRecipes[recipeName] : null;
        }

        public List<Recipe> GetRecipes(List<string> recipeNames)
        {
            var recipes = new List<Recipe>();
            foreach (string recipeName in recipeNames)
            {
                var recipe = GetRecipe(recipeName);
                if (recipe != null)
                {
                    recipes.Add(recipe);
                }
            }
            return recipes;
        }
    }
}
