using System;
using System.Collections.Generic;
using System.Text;

namespace FinalProject.ApiObjects
{
    public class SingleRecipe
    {
        public int weightWatcherSmartPoints { get; set; }
        public string gaps { get; set; }
        public int preparationMinutes { get; set; }
        public int cookingMinutes { get; set; }
        public string sourceName { get; set; }
        public double pricePerServing { get; set; }
        public List<ExtendedIngredient> extendedIngredients { get; set; }
        public int id { get; set; }
        public string title { get; set; }
        public int readyInMinutes { get; set; }
        public int servings { get; set; }
        public string sourceUrl { get; set; }
        public string image { get; set; }
        public string imageType { get; set; }
        public string summary { get; set; }
    }
}
