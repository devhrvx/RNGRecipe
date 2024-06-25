using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RNGRecipe.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecipeController : ControllerBase
    {
        private static readonly string[] Titles = new[]
        {
            "Not so Noodle",
            "Blandwich",
            "Scareberry Pie",
            "Dessert Desert",
            "Probably Salad"
        };

        private static readonly string[] Ingredients = new[]
        {
            "3 cup of flour",
            "99 cups of sugar",
            "1 drop of water",
            "1 pinch of salt",
            "Your tears",
            "1 bucket of pepper",
            "1 bag of raw chicken",
            "10 cabbages",
            "666 gallons of scorpion venom",
            "1 cup of coffee",
            "Flamin' hot cheetos",
            "1 pound of butter",
            "50 cooked pasta",
            "1 loaf of bread",
            "1 pound of cheese",
            "100 pounds of chocolate",
            "1 gallon of milk",
            "1 pint of ice cream",
            "1 dozen eggs",
            "1 cup of vinegar",
            "1 cup of oil",
            "Live chicken (optional)",
            "1 cup of soy sauce",
            "1 cup of ketchup",
            "1 cup of mustard",
            "1 cup of mayonnaise",
            "1 cup of hot sauce",
            "1 cup of honey",
            "1 cup of syrup",
            "1 cup of jam",
            "1 cup of jelly",
            "1 cup of peanut butter"
        };

        private static readonly string[] Instructions = new[]
        {
            "Mix {0} with {1} for about an hour",
            "Bake {0} together with {1} at 350 degrees for 99 minutes",
            "Fry {0} in {1} for 10 minutes",
            "You do not need to cook the {0} and {1}, just eat them raw",
            "Boil {0} in {1} for 5 minutes",
            "Microwave {0} and {1} for 5 minutes",
            "Grill {0} with {1} for 25 minutes",
            "Bake {0} with {1} for 30 minutes",
            "Throw the {0} in {1} and mix for 20 minutes",
            "Delete the {0} and {1} and order takeout instead",
            "Forget about the {0} and {1} and go to bed",
            "Throw the {0} and {1} in the trash",
            "Mix {0} with {1} and serve"
        };

        private Random random = new Random();

        [HttpGet]
        public ActionResult<Recipe> GetRandomRecipe()
        {   
            Random random = new Random();
            var title = Titles[random.Next(Titles.Length)];
            var ingredients = new HashSet<string>();
            var instructions = new List<string>();
            

            // Select 5 unique ingredients
            while (ingredients.Count < 5)
            {
                AddRandomIngredient(ingredients, random);
            }

            // Generate 5 unique instructions
            while (instructions.Count < 5)
            {
                AddRandomInstruction(instructions, ingredients, random);
            }

            var recipe = new Recipe
            {
                Title = title,
                Ingredients = ingredients.ToList(),
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

        private void AddRandomInstruction(List<string> instructions, HashSet<string> ingredients, Random random)
        {
            string instruction = Instructions[random.Next(Instructions.Length)];
            var listIng = ingredients.ToList();
            string[] ings = new string[listIng.Count];
            int i = 0;

            foreach (string ing in listIng)
            {
                ings[i] = ing;
                i++;
            }

            string formattedInstruction = "";

            for (int j = 0; j < ings.Length - 1; j += 2)
            {
                formattedInstruction = string.Format(instruction, ings[j], ings[j + 1]);
                Console.WriteLine(formattedInstruction);
            }

                if (!instructions.Contains(formattedInstruction))
                {
                    instructions.Add(formattedInstruction);
                }
            }
            
        }
    
}
