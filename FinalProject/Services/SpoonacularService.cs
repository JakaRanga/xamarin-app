using FinalProject.ApiObjects;
using FinalProject.ApiResources;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Services
{
    public class SpoonacularService
    {
        private readonly HttpClient HttpClient;
        private readonly SpoonacularApi SpoonacularApi;

        // Represents the number of recipies returned by the api
        private readonly int Limit;

        public SpoonacularService()
        {
            HttpClient = new HttpClient();
            SpoonacularApi = new SpoonacularApi();
            Limit = 5;
        }

        /* 
        ** Implementation of Spoonacular Api endpoints
        ** 
        ** https://spoonacular.com/food-api/docs#Search-Recipes
        */

        // GET https://spoonacular.com/recipes/search?query=
        // Get recipes by name e.g "Burger"
        public async Task<Recipes> GetRecipesByName(string name)
        {
            HttpResponseMessage response = await HttpClient.GetAsync(string.Format("{0}/recipes/search{2}&query={1}&number={3}",
                SpoonacularApi.ApiBaseUrl,
                name,
                SpoonacularApi.GetApiKeyParam(),
                Limit));

            Recipes recipes = null;
            if (response.IsSuccessStatusCode)
            {
                // Json string to C# object
                var rawResult = await response.Content.ReadAsStringAsync();
                recipes = JsonConvert.DeserializeObject<Recipes>(rawResult);
            }

            //If recipes still null, it means that the request fails.
            return recipes;
        }

        // GET https://spoonacular.com/recipes/search?query=
        // Get recipes by type e.g "Italian"
        public async Task<Recipes> GetRecipesByType(string type)
        {
            HttpResponseMessage response = await HttpClient.GetAsync(
                string.Format("{0}/recipes/search{2}&cuisine={1}&number={3}",
                SpoonacularApi.ApiBaseUrl,
                type,
                SpoonacularApi.GetApiKeyParam(),
                Limit));

            Recipes recipes = null;
            if (response.IsSuccessStatusCode)
            {
                // Json string to C# object
                var rawResult = await response.Content.ReadAsStringAsync();
                recipes = JsonConvert.DeserializeObject<Recipes>(rawResult);
            }

            //If recipes still null, it means that the request fails.
            return recipes;
        }

        // GET https://api.spoonacular.com/recipes/random
        // Get a random recipe
        public async Task<List<ApiObjects.RandomRecipe>> GetRandomRecipe()
        {
            HttpResponseMessage response = await HttpClient.GetAsync(
                string.Format("{0}/recipes/random{1}&number={2}",
                SpoonacularApi.ApiBaseUrl,
                SpoonacularApi.GetApiKeyParam(),
                Limit));

            RandomRecipes recipes = null;
            if (response.IsSuccessStatusCode)
            {
                // Json string to C# object
                var rawResult = await response.Content.ReadAsStringAsync();
                recipes = JsonConvert.DeserializeObject<RandomRecipes>(rawResult);
            }

            //If recipes still null, it means that the request fails.
            return recipes.recipes;
        }




        // GET https://api.spoonacular.com/recipes/{id}/ingredientWidget.json
        // Get recipe ingredients by recipe id
        public async Task<List<Ingredient>> GetRecipeIngredientById(int recipeId)
        {
            HttpResponseMessage response = await HttpClient.GetAsync(
                string.Format("{0}/recipes/{3}/ingredientWidget.json{1}&number={2}",
                SpoonacularApi.ApiBaseUrl,
                SpoonacularApi.GetApiKeyParam(),
                Limit,
                recipeId));

            IngredientsObject ingredientsObject = null;
            if (response.IsSuccessStatusCode)
            {
                // Json string to C# object
                var rawResult = await response.Content.ReadAsStringAsync();
                ingredientsObject = JsonConvert.DeserializeObject<IngredientsObject>(rawResult);
            }

            if (ingredientsObject == null)
                return null;

            return ingredientsObject.ingredients;
        }


        // GET https://api.spoonacular.com/recipes/{id}/analyzedInstructions
        // Get recipe instructions by recipe id
        public async Task<Instructions> GetRecipeInstructionById(int recipeId)
        {
            HttpResponseMessage response = await HttpClient.GetAsync(
                string.Format("{0}/recipes/{2}/analyzedInstructions{1}",
                SpoonacularApi.ApiBaseUrl,
                SpoonacularApi.GetApiKeyParam(),
                recipeId));

            List<Instructions> instructions = null;
            if (response.IsSuccessStatusCode)
            {
                // Json string to C# object
                var rawResult = await response.Content.ReadAsStringAsync();
                instructions = JsonConvert.DeserializeObject<List<Instructions>>(rawResult);
            }

            if (instructions.Count > 0)
                return instructions[0];

            return null;
        }


        // GET https://api.spoonacular.com/recipes/informationBulk
        // Get recipe by id
        public async Task<SingleRecipe> GetRecipeById(int recipeId)
        {
            HttpResponseMessage response = await HttpClient.GetAsync(
                string.Format("{0}/recipes/informationBulk{1}&ids={2}",
                SpoonacularApi.ApiBaseUrl,
                SpoonacularApi.GetApiKeyParam(),
                recipeId));

            List<SingleRecipe> recipes = null;
            if (response.IsSuccessStatusCode)
            {
                // Json string to C# object
                var rawResult = await response.Content.ReadAsStringAsync();
                recipes = JsonConvert.DeserializeObject<List<SingleRecipe>>(rawResult);
            }

            if (recipes != null && recipes.Count > 0)
                return recipes[0];

            return null;
        }
    }
}
