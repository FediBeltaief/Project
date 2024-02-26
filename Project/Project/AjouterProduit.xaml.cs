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
    public partial class AjouterProduit : ContentPage
    {
        private List<Categorie> listeCategorie;

        public AjouterProduit()
        {
            InitializeComponent();
            listeCategorie = App.Database.ObtenirCategories().Result;
            
            foreach (var categorie in listeCategorie)
            {
                categoryPicker.Items.Add(categorie.Nom);
            }
        }
        public AjouterProduit(Produit produit)
        {
            InitializeComponent();
            listeCategorie = App.Database.ObtenirCategories().Result;
            foreach (var categorie in listeCategorie)
            {
                categoryPicker.Items.Add(categorie.Nom);
            }
            if (produit != null)
            {
                txtId.Text = produit.Id.ToString();
                txtNom.Text = produit.Nom;
                txtDescription.Text = produit.Description;
                txtPrix.Text = produit.Prix.ToString();
                txtURLimage.Text = produit.UrlImage;
                categoryPicker.SelectedIndex = produit.IdCategorie;
            }
        }
        

        private async void Btnadd_Clicked(Object sender, EventArgs e)
        {
            Produit produit = new Produit();
            if(txtNom.Text !=null && txtDescription.Text!=null && txtPrix.Text!=null && txtURLimage.Text !=null)
            { 
            if (txtId.Text == null)
            {
                {
                    produit.Nom = txtNom.Text;
                    produit.Description = txtDescription.Text;
                    produit.Prix = Decimal.Parse(txtPrix.Text);
                    produit.UrlImage = txtURLimage.Text;
                    produit.IdCategorie = listeCategorie[categoryPicker.SelectedIndex].Id;
                };
            }
            else
            {
                {
                    produit.Id = int.Parse(txtId.Text);
                    produit.Nom = txtNom.Text;
                    produit.Description = txtDescription.Text;
                    produit.Prix = Decimal.Parse(txtPrix.Text);
                    produit.UrlImage = txtURLimage.Text;
                    produit.IdCategorie =  listeCategorie[categoryPicker.SelectedIndex].Id;
                };
            }

            await DisplayAlert("Done!", "Product Saved", "ok");
            await App.Database.AjouterProduit(produit);
            await Navigation.PopAsync();
            }
            else
            {
                await DisplayAlert("Error", "Please fill in all the fields ", "Ok");
            }
        }
        
    }
}