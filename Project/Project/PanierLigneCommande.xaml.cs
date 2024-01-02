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
    public partial class PanierLigneCommande : ContentPage
    {
        public PanierLigneCommande()
        {
            InitializeComponent();
        }
        protected async override void OnAppearing()
        {
            listeLigneComannde.ItemsSource = await App.Database.ObtenirToutigneCommande();
        }
    }
}