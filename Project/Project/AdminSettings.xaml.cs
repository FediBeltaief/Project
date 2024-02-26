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
    public partial class AdminSettings : ContentPage
    {
        public AdminSettings()
        {
            InitializeComponent();
        }

        public async void ChangeInfo(object sender, EventArgs e)
        {
            string user = login.Text;
            string pass = password.Text;
            string confirmpass = confirmpassword.Text;

            if (user.Length > 4 && pass.Length >= 8)
            {
                if (confirmpass == pass)
                {
                    App.Database.UpdateAdmin(new Admin(user, pass));
                    await DisplayAlert("Update Success", "Credentials changed!", "OK");
                    await Navigation.PopAsync();
                }
                else
                {
                    await DisplayAlert("Update Failed", "Password not matching!", "OK");
                    password.Text = "";
                    confirmpassword.Text = "";
                }
            }
            else
            {
                await DisplayAlert("Update Failed", "Login should be more than 4 characters and Password should be more than 8 characters!", "OK");
                password.Text = "";
                confirmpassword.Text = "";
            }
        }
    }
}
