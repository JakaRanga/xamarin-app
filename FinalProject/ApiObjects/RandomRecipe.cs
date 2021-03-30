using System;
using System.Collections.Generic;
using System.Text;

namespace FinalProject.ApiObjects
{
    public class Measures
    {
        public Metric metric { get; set; }
        public Us us { get; set; }
    }

    public class ExtendedIngredient
    {
        public string aisle { get; set; }
        public double amount { get; set; }
        public string consitency { get; set; }
        //public int? id { get; set; }
        public string image { get; set; }
        public Measures measures { get; set; }
        public List<object> meta { get; set; }
        public string name { get; set; }
        public string original { get; set; }
        public string originalName { get; set; }
        public string unit { get; set; }
    }

    public class RandomRecipe
    {
        public int id { get; set; }
        public string title { get; set; }
        public string image { get; set; }
        public string imageType { get; set; }
        public int servings { get; set; }
        public string sourceName { get; set; }
        public string sourceUrl { get; set; }
        public string spoonacularSourceUrl { get; set; }
        public string instructions { get; set; }
        public int weightWatcherSmartPoints { get; set; }
        public List<ExtendedIngredient> extendedIngredients { get; set; }
        public string summary { get; set; }
    }

    public class RandomRecipes
    {
        public List<RandomRecipe> recipes { get; set; }
    }
}
