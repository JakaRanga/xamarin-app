using FinalProject.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace FinalProject
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : MasterDetailPage
    {
        private readonly SpoonacularService SpoonacularService;
        public MainPage()
        {
            InitializeComponent();

            //SpoonacularService = new SpoonacularService();
            masterPage.listView.ItemSelected += OnItemSelected;
        }

        private void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = e.SelectedItem as MasterPageItem;
            if (item != null)
            {
                Detail = new NavigationPage((Page)Activator.CreateInstance(item.TargetType));
                masterPage.listView.SelectedItem = null;
                IsPresented = false;
            }
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            //var obj = await SpoonacularService.GetRecipesByName("Burger");
            //Console.WriteLine(obj);
        }
    }
}
