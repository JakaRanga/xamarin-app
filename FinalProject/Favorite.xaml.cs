using FinalProject.ApiObjects;
using FinalProject.Services;
using FinalProject.LocalStorage;
using System.Collections.ObjectModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FinalProject
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Favorite : ContentPage
    {
        SpoonacularService SpoonacularService;
        public ObservableCollection<SingleRecipe> lstRecipe { get; set; }

        public object SelectedItem { get; set; }
        public Favorite()
        {
            SpoonacularService = new SpoonacularService();
            lstRecipe = new ObservableCollection<SingleRecipe>();
            InitializeComponent();
            GetAllFav();
        }

        private async void GetAllFav()
        {
            var AllFav = LocalStorageManager.GetFavoriteRecipes();
            foreach (int ele in AllFav)
                lstRecipe.Add(await SpoonacularService.GetRecipeById(ele));
            BindingContext = this;
        }
        private async void listView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            ApiObjects.SingleRecipe tappedItem = e.Item as ApiObjects.SingleRecipe; //Select item tapped
            if (tappedItem == null)
                return;
            await Navigation.PushModalAsync(new NavigationPage(
                new RecipeDetail(tappedItem)));
        }
    }
}