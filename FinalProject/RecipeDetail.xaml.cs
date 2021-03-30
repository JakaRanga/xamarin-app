using FinalProject.ApiObjects;
using FinalProject.Services;
using FinalProject.LocalStorage;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FinalProject
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RecipeDetail : ContentPage
    {
        SpoonacularService SpoonacularService;
        public string SlctdResult { get; set; }
        public List<Ingredient> Ingredient { get; set; }
        public Instructions Instructions { get; set; }
        private int Id { get; set; }
        public RecipeDetail()
        {
            InitializeComponent();

        }
        public RecipeDetail(Result res)
        {
            Ingredient = new List<Ingredient>();
            Instructions = new Instructions();
            SpoonacularService = new SpoonacularService();
            InitializeComponent();
            CheckedFav(res.id);
            GetAllRecipe(res);
        }

        public RecipeDetail(ApiObjects.RandomRecipe res)
        {
            Ingredient = new List<Ingredient>();
            Instructions = new Instructions();
            SpoonacularService = new SpoonacularService();
            InitializeComponent();
            CheckedFav(res.id);
            GetAllRecipe(res);
        }
        public RecipeDetail(SingleRecipe res)
        {
            Ingredient = new List<Ingredient>();
            Instructions = new Instructions();
            SpoonacularService = new SpoonacularService();
            InitializeComponent();
            CheckedFav(res.id);
            GetAllRecipe(res);
        }
        private void CheckedFav(int id) 
        {
            var allFav = LocalStorageManager.GetFavoriteRecipes();
            Id = id;
            if (allFav.Contains(id))
                button.Text = "Remove to fav";
            else
                button.Text = "Add to fav";
        }
        private async void GetAllRecipe(Result res)
        {
            await GetIngredients(res.id);
            await GetInstructions(res.id);
            SlctdResult = res.title;
            BindingContext = this;
        }

        private async void GetAllRecipe(ApiObjects.RandomRecipe res)
        {
            await GetIngredients(res.id);
            await GetInstructions(res.id);
            SlctdResult = res.title;
            BindingContext = this;
        }
        private async void GetAllRecipe(SingleRecipe res)
        {
            await GetIngredients(res.id);
            await GetInstructions(res.id);
            SlctdResult = res.title;
            BindingContext = this;
        }

        private async Task GetIngredients(int id)
        {
            Ingredient = await SpoonacularService.GetRecipeIngredientById(id);
        }

        private async Task GetInstructions(int id)
        {
            Instructions = await SpoonacularService.GetRecipeInstructionById(id);
        }

        private void button_Clicked(object sender, System.EventArgs e)
        {
            if (button.Text == "Add to fav")
            {
                LocalStorageManager.AddRecipeAsFavorite(Id);
                button.Text = "Remove to fav";
            }
            else
            {
                LocalStorageManager.DeleteFavoriteRecipe(Id);
                button.Text = "Add to fav";
            }
        }
    }
}