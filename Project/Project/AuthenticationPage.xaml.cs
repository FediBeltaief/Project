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
    public partial class AuthenticationPage : ContentPage
    {
        public AuthenticationPage()
        {
            InitializeComponent();
        }
        private void OnLogin(object sender, EventArgs e)
        {
            string user = login.Text;
            string pass = password.Text;

            if (user == "admin" && pass == "admin")
            {
                DisplayAlert("Login Success", "Welcome!", "OK");
                Navigation.PushAsync(new AdminPage());
            }
            else
            {
                DisplayAlert("Login Failed", "Invalid username or password", "OK");
            }
        }
    }
}