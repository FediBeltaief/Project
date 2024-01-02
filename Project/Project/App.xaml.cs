using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Project
{
    public partial class App : Application
    {
        static BoutiqueDataBase database;
        public static BoutiqueDataBase Database
        {
            get
            {
                if (database == null)
                {
                    database = new BoutiqueDataBase(Path.Combine(Environment.GetFolderPath((Environment.SpecialFolder.LocalApplicationData)), "BoutiqueDataBase.db3"));
                }
                return database;
            }
        }
        public App()
        {
            InitializeComponent();

            MainPage = new Menu();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
