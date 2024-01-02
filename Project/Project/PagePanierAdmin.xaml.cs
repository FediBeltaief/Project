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
    public partial class PagePanierAdmin : ContentPage
    {
        public PagePanierAdmin()
        {
            InitializeComponent();
        }

        protected async override void OnAppearing()
        {
            listeCommande.ItemsSource = await App.Database.ObtenirToutCommande();
        }
        /*public async void BtnAfficher_Clicked(object sender, EventArgs e)
        {
            int i = 0;
            Commande commande = await App.Database.ObtenirCommande(1);
            try
            {
                Console.WriteLine("0");
                List<LigneCommande> lc = new List<LigneCommande>(await App.Database.GetLigneCommandesByIds(commande.LignesCommande.Select(c => int.Parse(c.ToString())).ToList()));
                Console.WriteLine("1");

                if (lc != null)
                {
                    Console.WriteLine("bruh");
                    foreach (var lignecommande in lc)
                    {
                        Console.WriteLine(lignecommande.NomProduit);
                        i++;
                        Console.WriteLine(i);
                    }
                    Console.Write("Done");
                }
                else
                {
                    Console.WriteLine("CommandParameter is null");
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
        public async void BtnAfficher_Clicked(object sender, EventArgs e)
        {
            int i = 0;
            Commande commande = await App.Database.ObtenirCommande(1);
            try
            {
                Console.WriteLine("0");
                List<LigneCommande> lc = new List<LigneCommande>(commande.LignesCommande);
                Console.WriteLine("1");

                if (commande.LignesCommande != null)
                {
                    Console.WriteLine("bruh");
                    Console.WriteLine(commande.LignesCommande.Count);
                    foreach (var lignecommande in lc)
                    {
                        Console.WriteLine(lignecommande.NomProduit);
                        i++;
                        Console.WriteLine(i);
                    }
                    Console.Write("Done");
                }
                else
                {
                    Console.WriteLine("CommandParameter is null");
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
        /*
        public async void BtnAfficher_Clickeddqsdqsd(object sender, EventArgs e)
        {
            int i = 0;
            Commande commande=await App.Database.ObtenirCommande(5);
            try
            {
               
            List<LigneCommande> lc = new List<LigneCommande>(commande.LignesCommande);
            

                if (commande.LignesCommande != null)
                {
                    Console.WriteLine("bruh");
                    foreach (var lignecommande in commande.LignesCommande)
                    {
                        i++;
                        Console.WriteLine(i);
                    }
                    Console.Write("Done");
                }
                else
                {
                    Console.WriteLine("CommandParameter is null");
                }

            }
            catch(Exception ex)
            {
                Console.WriteLine("wrong 2");
            }

        }*/
        private async void BtnAfficher_Clicked2(object sender, EventArgs e)
        {
            //int i = 0;
            var image = sender as Image;
            var grid = image?.Parent as Grid;
            var commande = grid.BindingContext as Commande;
            
            string msg = "";
            List<LigneCommande> lc = new List<LigneCommande>(await App.Database.GetLigneCommandesByIds(commande.LignesCommande.Select(c => int.Parse(c.ToString())).ToList()));
            try
            {

                if (commande.LignesCommande != null)
                {
                    foreach (var lignecommande in lc)
                    {
                        msg = msg + "Product: " + lignecommande.NomProduit + " Quantity: " + lignecommande.Quantite + "\n";
                    }
                }
                else
                {
                    Console.WriteLine("CommandParameter is null");
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("wrong 2");
            }
            await DisplayAlert("List de Produit Commandé ", msg, "OK");

        }/**/
    }
}