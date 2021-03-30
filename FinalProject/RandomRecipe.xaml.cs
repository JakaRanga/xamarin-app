using FinalProject.Services;
using FinalProject.ApiObjects;
using System.Collections.ObjectModel;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FinalProject
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RandomRecipe : ContentPage
    {
        SpoonacularService SpoonacularService;
        public ObservableCollection<ApiObjects.RandomRecipe> lstRecipe { get; set; }

        public object SelectedItem { get; set; }

        public RandomRecipe()
        {
            SpoonacularService = new SpoonacularService();
            lstRecipe = new ObservableCollection<ApiObjects.RandomRecipe>();
            InitializeComponent();
            GetRdmRecipe();
        }

        private async void GetRdmRecipe()
        {
            var obj = await SpoonacularService.GetRandomRecipe();
            foreach (ApiObjects.RandomRecipe ele in obj)
            {
                lstRecipe.Add(ele);
            }
            this.BindingContext = this;
        }

        private async void listView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            ApiObjects.RandomRecipe tappedItem = e.Item as ApiObjects.RandomRecipe; //Select item tapped
            if (tappedItem == null)
                return;
            await Navigation.PushModalAsync(new NavigationPage(
                new RecipeDetail(tappedItem)));
        }
    }
}