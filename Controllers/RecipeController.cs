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
            "Mix {0} with {1} for about an hour",
            "Bake {0} together with {1} at 350 degrees for 99 minutes",
            "Fry {0} in {1} for 10 minutes",
            "Boil {0} in {1} for 5 minutes",
            "Microwave {0} and {1} for 1 minute",
            "Grill {0} with {1} for 30 minutes",
            "Bake {0} with {1} for 20 minutes",
            "Fry {0} and {1} for 15 minutes",
            "Boil {0} and {1} for 10 minutes",
            "Microwave {0} and {1} for 5 minutes"
        };

        [HttpGet]
        public ActionResult<Recipe> GetRandomRecipe()
        {
            var random = new Random();

            var title = Titles[random.Next(Titles.Length)];
            var ingredients = new HashSet<string>();
            var instructions = new HashSet<string>();
            for (int i = 0; i < 5; i++)
            {
                AddRandomIngredient(ingredients, random);
                AddRandomIngredient(ingredients, random);
            }

            while (instructions.Count < 5)
            {
                AddRandomInstruction(instructions, ingredients, random);
            }

            var recipe = new Recipe
            {
                Title = title,
                Ingredients = ingredients,
                Instructions = instructions
            };

            return Ok(recipe);
        }


        private void AddRandomIngredient(HashSet<string> ingredients, Random random)
        {
            while (true)
            {
                var ingredient = Ingredients[random.Next(Ingredients.Length)];
                if (ingredients.Add(ingredient))
                {
                    break;
                }
            }
        }

        private void AddRandomInstruction(HashSet<string> instructions, HashSet<string> ingredients, Random random)
        {
            var ingredientsList = new List<string>(ingredients);
            while (true)
            {
                var instructionTemplate = Instructions[random.Next(Instructions.Length)];
                var formattedInstructions = string.Format(instructionTemplate, ingredientsList[random.Next(ingredientsList.Count)], ingredientsList[random.Next(ingredientsList.Count)]);
                if (instructions.Add(formattedInstructions))
                {
                    break;
                }
            }
        }

    }
}
