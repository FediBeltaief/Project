using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Project
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CategoriePage : ContentPage
    {
        private List<Categorie> listeCategorie;
    
        public CategoriePage()
        {
            InitializeComponent();
            listeCategorie = App.Database.ObtenirCategories().Result;
            categoryPicker.Items.Add("All");
            foreach (var categorie in listeCategorie)
            {
                categoryPicker.Items.Add(categorie.Nom);
            }
            /*collectionView.ItemsSource = produits;
            BoutiqueDataBase bdb = new BoutiqueDataBase("boutique.db3"); 
            produits = new ObservableCollection<Produit>(bdb.ObtenirToutProduits());
            collectionView.ItemsSource = produits;
        */
        }

        protected async override void OnAppearing()
        {
            collectionView.ItemsSource = await App.Database.ObtenirToutProduits();
        }

        private async void OnCategoryChanged(object sender, EventArgs e)
        {
            if(categoryPicker.SelectedItem.Equals("All"))
            {
                collectionView.ItemsSource = await App.Database.ObtenirToutProduits();
            }
            else if (categoryPicker.SelectedItem != null)
            {
                int idCategorie = categoryPicker.SelectedIndex;
                Categorie cat = listeCategorie[idCategorie-1];
                List<Produit> produits = await App.Database.ObtenirProduits(cat.Id);
                collectionView.ItemsSource = produits;
            }
            else
            {
                await DisplayAlert("Erreur", "Veuillez sélectionner une catégorie", "OK");
            }
        }
        private async void OnGridTapped(object sender, EventArgs e)
        {
            var grid = (Grid)sender;
            var produit = (Produit)grid.BindingContext;
            await Navigation.PushAsync(new ProductDetailsPage(produit));
        }
        private void BtnAfficher_Clicked(object sender, EventArgs e)
        {
            var menuItem = sender as MenuItem;
            var produit = menuItem.CommandParameter as Produit;
            DisplayAlert("Détails", "Product :" + produit.Id + "\nDescription" + produit.Description, "OK");
        }
        /*private void BtnDelete_Clicked(object sender, EventArgs e)
        {
            var menuItem = sender as MenuItem;
            var produit = menuItem.CommandParameter as Product;
            listproduits.Remove(produit);
        }*/

    }
}