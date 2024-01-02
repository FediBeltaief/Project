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
    public partial class GestionProduit : ContentPage
    {
        public GestionProduit()
        {
            InitializeComponent();
        }

        protected async override void OnAppearing()
        {
            listeProduit.ItemsSource = await App.Database.ObtenirToutProduits();
        }
        private async void BtnAfficher_Clicked(object sender, EventArgs e)
        {
            var menuItem = sender as MenuItem;
            var produit = menuItem.CommandParameter as Produit;

            Categorie cat = await App.Database.GetCategorieParId(produit.IdCategorie);

            await DisplayAlert("Details",
                $"ID: {produit.Id}\nNom: {produit.Nom}\nDescription: {produit.Description}\nPrice: {produit.Prix}\nImage: {produit.UrlImage}\nIDCategory: {produit.IdCategorie}\nNom Category: {cat.Nom}",
                "OK");
        }

        private async void BtnDelete_Clicked(object sender, EventArgs e)
        {
            var menuItem = sender as MenuItem;
            var produit = menuItem.CommandParameter as Produit;
            bool result = await DisplayAlert("Confirmation", "Do you want to proceed?", "No", "Yes");
            if (result == false)//Yes hiya no w No hiya Yes 9lebthom 3al mandher
            {
                await App.Database.SupprimerProduit(produit);
                this.OnAppearing();
            }
        }

        private void BtnModifier_Clicked(object sender, EventArgs e)
        {
            var menuItem = sender as MenuItem;
            var produit = menuItem.CommandParameter as Produit;

            Navigation.PushAsync(new AjouterProduit(produit));
        }

        private void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new AjouterProduit());
        }
    }

}