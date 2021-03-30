using System;
using System.Collections.Generic;
using System.Text;

namespace FinalProject.ApiObjects
{
    public class Length
    {
        public int number { get; set; }
        public string unit { get; set; }
    }

    public class Step
    {
        public List<object> equipment { get; set; }
        public List<object> ingredients { get; set; }
        public int number { get; set; }
        public string step { get; set; }
        public Length length { get; set; }
    }

    public class Instructions
    {
        public string name { get; set; }
        public List<Step> steps { get; set; }
    }
}
