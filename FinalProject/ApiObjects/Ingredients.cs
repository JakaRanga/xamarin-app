using System;
using System.Collections.Generic;
using System.Text;

namespace FinalProject.ApiObjects
{
    public class Metric
    {
        public string unit { get; set; }
        public double value { get; set; }
    }

    public class Us
    {
        public string unit { get; set; }
        public double value { get; set; }
    }

    public class Amount
    {
        public Metric metric { get; set; }
        public Us us { get; set; }
    }

    public class Ingredient
    {
        public Amount amount { get; set; }
        public string image { get; set; }
        public string name { get; set; }
    }

    public class IngredientsObject
    {
        public List<Ingredient> ingredients { get; set; }
    }
}
