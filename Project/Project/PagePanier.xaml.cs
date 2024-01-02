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
    public partial class PagePanier : ContentPage
    {
        public static ObservableCollection<ArticlePanier> Articles { get; set; } = new ObservableCollection<ArticlePanier>(Panier.Articles);
        private decimal totalPrice;
        public PagePanier()
        {
            InitializeComponent();
            foreach (var ap in Panier.Articles)
            {
                totalPrice = totalPrice + ap.PrixTotale;
            }
        }
        protected override void OnAppearing()
        {
            panier.ItemsSource = Panier.Articles;
            Total.Text = "Total: " + totalPrice.ToString() + "$";
        }
        private void QuantityTextChanged(object sender, TextChangedEventArgs e)
        {
            this.OnAppearing();
        }

        private async void Deleted(object sender, EventArgs e)
        {
            var image = sender as Image;
            var grid = image?.Parent as Grid;

            bool result = await DisplayAlert("Confirmation", "Do you want to proceed?", "No", "Yes");
            if (result == false)//Yes hiya no w No hiya Yes 9lebthom 3al mandher
            {
                if (grid != null)
                {
                    var AP = grid.BindingContext as ArticlePanier;

                    if (AP != null)
                    {
                        int idProduit = AP.IdProduit;
                        Panier.RetirerArticle(AP.IdProduit);
                        Articles.Remove(AP);
                        panier.ItemsSource = Articles;

                    }
                }
            }
        }


        /*private void Edit(object sender, EventArgs e)
        {
            Navigation.PushAsync(new AdminPage());
        }*/

        private async void Confirm(object sender, EventArgs e)
        {
            List<int> i = new List<int>();
            Commande commande = new Commande();
            //List<LigneCommande> lc = new List<LigneCommande>();
            foreach (var articlePanier in Panier.Articles)
            {
                LigneCommande ligneCommande = new LigneCommande
                {
                    IdProduit = articlePanier.IdProduit,
                    NomProduit = articlePanier.NomProduit,
                    Prix = articlePanier.PrixTotale,
                    Quantite = articlePanier.Quantite
                };
                i.Add(await App.Database.AjouterLigneCommandewithId(ligneCommande));
            }
            string resultString = string.Join("", i);
            if (resultString.Length > 0)
            {
                commande.LignesCommande = resultString;

                commande.NomClient = "Test3";

                int j = await App.Database.AjouterCommande(commande);

                //Console.WriteLine(j);
                Panier.ViderPanier();

                await DisplayAlert("", "Successful", "OK");
            }
            else
            {
                await DisplayAlert("Failed", "Empty!", "OK");
            }
        }


            /*
            private async void Confirm(object sender, EventArgs e)
            {
                List<int> i=new List<int>();
                Commande commande = new Commande();
                List<LigneCommande> lc = new List<LigneCommande>();
                foreach (var articlePanier in Panier.Articles)
                {
                    LigneCommande ligneCommande = new LigneCommande
                    {
                        IdProduit = articlePanier.IdProduit,
                        NomProduit = articlePanier.NomProduit,
                        Prix = articlePanier.PrixTotale,
                        Quantite = articlePanier.Quantite
                    };

                    i.Add(await App.Database.AjouterLigneCommandewithId(ligneCommande));

                }
                commande.LignesCommande = new List<LigneCommande>(await App.Database.GetLigneCommandesByIds(i));
                commande.NomClient = "Test3";

                await App.Database.AjouterCommande(commande);
                Panier.ViderPanier();
                await DisplayAlert("", "Successful", "OK");
            }*/

    }
}