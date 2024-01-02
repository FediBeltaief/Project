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
    public partial class GestionCategorie : ContentPage
    {
        public GestionCategorie()
        {
            InitializeComponent();
        }
        protected async override void OnAppearing()
        {
            listeCategorie.ItemsSource = await App.Database.ObtenirCategories();
        }
        
        private async void BtnDelete_Clicked(object sender, EventArgs e)
        {
            var menuItem = sender as MenuItem;
            var categorie = menuItem.CommandParameter as Categorie;
            bool result = await DisplayAlert("Confirmation", "Do you want to proceed?", "No", "Yes");
            if (result == false)//Yes hiya no w No hiya Yes 9lebthom 3al mandher
            {
                await App.Database.SupprimerCategorie(categorie.Id);
                this.OnAppearing();
            }
        }

        private void BtnModifier_Clicked(object sender, EventArgs e)
        {
            var menuItem = sender as MenuItem;
            var categorie = menuItem.CommandParameter as Categorie;

            Navigation.PushAsync(new AjouterCategorie(categorie));
        }
        private void BtnAjouter_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new AjouterCategorie());
        }
        private void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new AjouterCategorie());
        }
    }
}