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
    public partial class AjouterCategorie : ContentPage
    {
        public AjouterCategorie()
        {
            InitializeComponent();
        }

        public AjouterCategorie(Categorie categorie)
        {


            InitializeComponent();
            if (categorie != null)
            {
                txtId.Text = categorie.Id.ToString();
                txtNom.Text = categorie.Nom;
            }

        }
        private async void Btnadd_Clicked(Object sender, EventArgs e)
        {
            Categorie categorie = new Categorie();
            if (txtNom.Text != null)
            {
                if (txtId.Text == null)
                {
                    {
                        categorie.Nom = txtNom.Text;
                    };
                }
                else
                {
                    {
                        categorie.Id = int.Parse(txtId.Text);
                        categorie.Nom = txtNom.Text;
                    };
                }

                await DisplayAlert("Done!", "Categorie Saved", "ok");
                await App.Database.SaveCategorie(categorie);
                await Navigation.PopAsync();
            }
            else
            {
                await DisplayAlert ("Error", "Name can't be Empty", "Ok");
            }
        }
        

    }
}