using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using HSEapp.Pages;
using HSEapp.Data;
using System.IO;


namespace HSEapp
{
    public partial class App : Application
    {
        public const string DATABASE_NAME = "tableFAirProjects.db";
        static FairProjectDB databaseFairProjects;
        public static FairProjectDB DatabaseFairProjects
        {
            get
            {
                if (databaseFairProjects == null)
                {
                    databaseFairProjects = new FairProjectDB(
                        Path.Combine(
                            Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), DATABASE_NAME));
                }
                return databaseFairProjects;
            }
        }

        public App()
        {
            InitializeComponent();

            MainPage = new MainPage();
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
