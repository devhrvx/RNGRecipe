namespace RNGRecipe
{
    public class Recipe
    {
        public string Title { get; set; }
        public HashSet<string> Ingredients { get; set; }
        public HashSet<string> Instructions { get; set; }
    }
}
