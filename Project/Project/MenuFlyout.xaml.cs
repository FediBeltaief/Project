using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Project
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MenuFlyout : ContentPage
    {
        public ListView ListView;

        public MenuFlyout()
        {
            InitializeComponent();
            BindingContext = new MenuFlyoutViewModel();
            ListView = MenuItemsListView;
        }

        class MenuFlyoutViewModel : INotifyPropertyChanged
        {
            public ObservableCollection<MenuFlyoutMenuItem> MenuItems { get; set; }

            public MenuFlyoutViewModel()
            {
                MenuItems = new ObservableCollection<MenuFlyoutMenuItem>(new[]
                {

                    new MenuFlyoutMenuItem { Id = 0, Title = "Shop" ,TargetType=typeof(CategoriePage)},
                    new MenuFlyoutMenuItem { Id = 1, Title = "Shopping Cart", TargetType=typeof(PagePanier)},
                    new MenuFlyoutMenuItem { Id = 2, Title = "Admin" ,TargetType=typeof(AuthenticationPage)},
                });
            }

            #region INotifyPropertyChanged Implementation
            public event PropertyChangedEventHandler PropertyChanged;
            void OnPropertyChanged([CallerMemberName] string propertyName = "")
            {
                if (PropertyChanged == null)
                    return;

                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
            #endregion
        }
    }
}