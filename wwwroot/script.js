document.getElementById('generateRecipeBtn').addEventListener('click', function () {
    fetch('api/recipe')
        .then(response => response.json())
        .then(data => {
            document.getElementById('recipeTitle').innerText = data.title;

            const ingredientsList = document.getElementById('ingredientsList');
            ingredientsList.innerHTML = '';
            data.ingredients.forEach(ingredient => {
                const li = document.createElement('li');
                li.innerText = ingredient;
                ingredientsList.appendChild(li);
            });

            const instructionsList = document.getElementById('instructionsList');
            instructionsList.innerHTML = '';
            data.instructions.forEach(instruction => {
                const li = document.createElement('li');
                li.innerText = instruction;
                instructionsList.appendChild(li);
            });

            document.getElementById('recipe').style.display = 'block';
        });
});
