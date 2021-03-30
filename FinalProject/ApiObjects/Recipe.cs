using System;
using System.Collections.Generic;
using System.Text;

namespace FinalProject.ApiObjects
{
    public class Result
    {
        public int id { get; set; }
        public string image { get; set; }
        public List<string> imageUrls { get; set; }
        public int readyInMinutes { get; set; }
        public int servings { get; set; }
        public string title { get; set; }
    }

    public class Recipes
    {
        public int offset { get; set; }
        public int number { get; set; }
        public List<Result> results { get; set; }
        public int totalResults { get; set; }
    }
}
