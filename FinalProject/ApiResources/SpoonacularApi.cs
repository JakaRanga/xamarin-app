using System;
using System.Collections.Generic;
using System.Text;

namespace FinalProject.ApiResources
{
    public class SpoonacularApi
    {
        public string ApiBaseUrl { get; set; } = "https://api.spoonacular.com";
        public string ApiKey { get; set; } = "942fdc8290e245fd8eb7841eef1102e0";

        public string GetApiKeyParam()
        {
            return "?apiKey=" + ApiKey;
        }
    }
}
