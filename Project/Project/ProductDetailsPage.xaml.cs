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
    public partial class ProductDetailsPage : ContentPage
    {
        private Produit product;
        private int quantity = 1;

        public ProductDetailsPage(Produit product)
        {
            InitializeComponent();
            this.product = product;
            BindingContext = product;

        }
        private void UpdateQuantityLabel()
        {
            QuantityLabel.Text = quantity.ToString();
        }

        private void Less(object sender, EventArgs e)
        {
            if (quantity > 1)
            {
                quantity--;
                UpdateQuantityLabel();
            }
        }

        private void More(object sender, EventArgs e)
        {
            quantity++;
            UpdateQuantityLabel();
        }
        private void Buy(object sender, EventArgs e)
        {
            Panier.AjouterArticle(product.Id,product.Nom,product.Prix,quantity);
            DisplayAlert("Added to Cart!", "", "ok");
        }
    }
}