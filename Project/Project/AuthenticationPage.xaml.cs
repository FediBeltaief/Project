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
        protected async override void OnAppearing()
        {
            Admin admin = await App.Database.getAdmin();

            if (admin.username != "admin" || admin.password != "admin")
            {
                if (Content is StackLayout stackLayout)
                {
                    var label = stackLayout.Children.FirstOrDefault(x => x is Label) as Label;
                    if (label != null)
                    {
                        stackLayout.Children.Remove(label);
                    }
                }
                ToolbarItem toolbarItem = new ToolbarItem
                {
                    IconImageSource = "setings.png",
                    Order = ToolbarItemOrder.Primary,
                    Priority = 1
                };
                toolbarItem.Clicked += SettingsPageTapped;
                this.ToolbarItems.Clear();
                this.ToolbarItems.Add(toolbarItem);
            }
        }
        private void MoreInfo(object sender, EventArgs e)
        {
            string message = "Default username: admin\n" +
                             "Default password: admin\n\n" +
                             "You can change your username and password whenever you want.";

            DisplayAlert("Details", message, "OK");
        }
        private async void OnLogin(object sender, EventArgs e)
        {
            Admin admin = await App.Database.getAdmin();
            string user = login.Text;
            string pass = password.Text;

            if (user == admin.username && pass == admin.password)
            {
                await DisplayAlert("Login Success", "Welcome!", "OK");
                await Navigation.PushAsync(new AdminPage());
            }
            else
            {
                await DisplayAlert("Login Failed", "Invalid username or password", "OK");
            }
        }
        private void SettingsPageTapped(object sender, EventArgs e)
        {
            Navigation.PushAsync(new AdminSettings());
        }
        
    }
}