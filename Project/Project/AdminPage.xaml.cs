using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Project
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AdminPage : ContentPage
    {
        public AdminPage()
        {
            InitializeComponent();
        }

        private async void toProductPage(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new GestionProduit());

        }
        
        private async void toCategoryPage(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new GestionCategorie());
        }
       
        private async void toCommandePage(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new PagePanierAdmin());
        }
    }
}