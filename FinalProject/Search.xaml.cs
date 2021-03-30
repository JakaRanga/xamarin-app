using FinalProject.ApiObjects;
using FinalProject.Services;
using System.Collections.ObjectModel;


using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FinalProject
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Search : ContentPage
    {
        SpoonacularService SpoonacularService;
        public ObservableCollection<Result> lstRecipe { get; set; }

        public object SelectedItem { get; set; }

        public Search()
        {
            SpoonacularService = new SpoonacularService();
            lstRecipe = new ObservableCollection<Result>();
            InitializeComponent();
        }

        private async void Button_Clicked(object sender, System.EventArgs e)
        {
            var obj = await SpoonacularService.GetRecipesByName(entry.Text);
            lstRecipe.Clear();
            foreach (Result ele in obj.results)
            {
                lstRecipe.Add(ele);
            }
            BindingContext = this;
        }

        private async void listView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            Result tappedItem = e.Item as Result; //Select item tapped
            if (tappedItem == null)
                return;
            await Navigation.PushModalAsync(new NavigationPage(
                new RecipeDetail(tappedItem)));
        }
    }
}