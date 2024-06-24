using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace RNGRecipe.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecipeController : ControllerBase
    {
        private static readonly string[] Titles = new[]
        {
            "Not so Noodle", "Blandwich", "Scareberry Pie", "Dessert Desert", "Probably Salad"
        };

        private static readonly string[] Ingredients = new[]
        {
            "3 cup of flour", "99 cups of sugar", "1 cup of water", "1 pinch of salt", "1 bucket of pepper", "1 bag of raw chicken", "10 cabbages", "Flaming hot cheetos", "1 pound of butter", "50 cooked pasta", "1 loaf of bread"
        };

        private static readonly string[] Instructions = new[]
        {
            "Mix all ingredients together",
            "Bake at 350 degrees for 30 minutes",
            "Fry in a pan for 10 minutes",
            "Boil for 5 minutes",
            "Microwave for 2 minutes",
            "Serve cold",
            "Serve hot",
            "Serve with a side of fries",
            "Serve with a side of salad",
            "Serve with a side of rice"
        };

        [HttpGet]
        public ActionResult<Recipe> GetRandomRecipe()
        {
            var random = new Random();

            var title = Titles[random.Next(Titles.Length)];
            var ingredients = new List<string>();
            for (int i = 0; i <= 5; i++)
            {
                   ingredients.Add(Ingredients[random.Next(Ingredients.Length)]);
            }

            var instructuions = Instructions[random.Next(Instructions.Length)];

            var recipe = new Recipe
            {
                Title = title,
                Ingredients = ingredients,
                Instructions = instructuions
            };

            return Ok(recipe);
        }
    }
}
