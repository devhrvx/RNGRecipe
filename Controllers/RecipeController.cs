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
            "Mix %s with %s for about an hour",
            "Bake %s together with %s at 350 degrees for 99 minutes",
            "Fry %s in %s for 10 minutes",
            "Boil %s in %s for 5 minutes",
            "Microwave %s and %s for 1 minute",
            "Grill %s with %s for 30 minutes",
            "Bake %s with %s for 20 minutes",
            "Fry %s and %s for 15 minutes",
            "Boil %s and %s for 10 minutes",
            "Microwave %s and %s for 5 minutes"
        };

        [HttpGet]
        public ActionResult<Recipe> GetRandomRecipe()
        {
            var random = new Random();

            var title = Titles[random.Next(Titles.Length)];
            var ingredients = new List<string>();
            var instructions = new List<string>();
            var insPart = "Instrcutions: \n\n";
            string ingPart1 = "";
            string ingPart2 = "";
            instructions.Add(insPart);
            string ins = "";
            var insArr = new List<string>();
            for (int i = 0; i < 5; i++)
            {
                foreach (string ingredient in ingredients)
                {
                    ingPart1 = Ingredients[random.Next(Ingredients.Length)];
                    ingPart2 = Ingredients[random.Next(Ingredients.Length)];
                    if (ingPart1 != ingredient && ingPart2 != ingPart1)
                    {
                        ingredients.Add(ingPart1);
                        ingredients.Add(ingPart2);
                    }
                    else if (ingPart1 != ingredient)
                    {
                        ingredients.Add(ingPart1);
                        ingredients.Add(Ingredients[random.Next(Ingredients.Length)]);
                    }
                    else if (ingPart2 != ingPart1)
                    {
                        ingredients.Add(ingPart2);
                        ingredients.Add(Ingredients[random.Next(Ingredients.Length)]);
                    }
                    else {
                        ingredients.Add(Ingredients[random.Next(Ingredients.Length)]);
                        ingredients.Add(Ingredients[random.Next(Ingredients.Length)]);
                    }
                }
                foreach (string instruction in insArr)
                {
                    insPart = Instructions[random.Next(Instructions.Length)];
                    if (insPart != instruction)
                    {
                        insArr.Add(insPart);
                    }
                }
                //ins = string.Format(insArr[i], ingredients[i], ingredients[i + 1]); ERROR 
                instructions.Add(ins);
            }
            var recipe = new Recipe
            {
                Title = title,
                Ingredients = ingredients,
                Instructions = instructions
            };

            return Ok(recipe);
        }
    }
}
