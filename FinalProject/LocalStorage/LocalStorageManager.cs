//using PCLStorage;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace FinalProject.LocalStorage
{
    public static class LocalStorageManager
    {
        private static string KeyName = "favorite_recipes";

        public static bool AddRecipeAsFavorite(int id)
        {
            // Call the method to get favorite recipes from the local storage
            var favRecipes = ReadRecipesFromLocalStorage();

            // Add the new favorite recipe
            favRecipes.Add(id);

            // Return true or false. True -> success in writing, False -> error while writing
            return WriteRecipesInLocalStorage(favRecipes);
        }

        public static List<int> GetFavoriteRecipes()
        {
            // Call the method to get favorite recipes from the local storage
            return ReadRecipesFromLocalStorage();
        }

        public static bool DeleteFavoriteRecipe(int id)
        {
            // Get favorite recipes from the local storage
            var favRecipes = ReadRecipesFromLocalStorage();

            // Remove the id corresponding to the recipe the user want to delete
            favRecipes.Remove(id);

            // Update the list in the local storage
            return WriteRecipesInLocalStorage(favRecipes);
        }

        private static bool WriteRecipesInLocalStorage(List<int> recipes)
        {
            // Convert the list into a string to store it in the local storage
            var updatedRawFav = JsonConvert.SerializeObject(recipes);

            try
            {
                // Update favorite recipes list in the local storage
                Application.Current.Properties[KeyName] = updatedRawFav;
                return true;
            }
            catch
            {
                // Error: cannot read the localstorage
                return false;
            }
        }

        private static List<int> ReadRecipesFromLocalStorage()
        {
            if (Application.Current.Properties.ContainsKey(KeyName))
            {
                // Get favorite recipes as a string
                var rawRecipes = Application.Current.Properties[KeyName] as string;

                // Deserialize the string to get a list of recipe id
                var favRecipes = JsonConvert.DeserializeObject<List<int>>(rawRecipes);

                return favRecipes;
            }

            // Return an empty list if no favorite found or key not created yet
            return new List<int>();
        }
    }
}
