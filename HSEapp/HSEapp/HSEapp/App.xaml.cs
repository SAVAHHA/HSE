using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using HSEapp.Pages;
using HSEapp.Data;
using System.IO;
using System.Collections.Generic;
using HSEapp.Data.Fair;

namespace HSEapp
{
    public partial class App : Application
    {
        public const string DATABASE_NAME_FairProjects = "FairProjects.db";
        static FairProjectDataBase databaseFairProjects;
        public static FairProjectDataBase DatabaseFairProjects
        {
            get
            {
                if (databaseFairProjects == null)
                {
                    databaseFairProjects = new FairProjectDataBase(
                        Path.Combine(
                            Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), DATABASE_NAME_FairProjects));
                }
                return databaseFairProjects;
            }
        }

        public static IList<FairProjectTable> FairProjects
        {
            get
            {
                List<FairProjectTable> fairProjects = new List<FairProjectTable>();
                if (databaseFairProjects != null)
                {
                    fairProjects = App.DatabaseFairProjects.GetProjectsAsync().Result;
                }
                return fairProjects;
            }
        }

        public const string DATABASE_NAME_CurrentFairProject = "CurrentFairProject.db";
        static CurrentFairProjectDataBase databaseCurrentFairProject;
        public static CurrentFairProjectDataBase DatabaseCurrentFairProject
        {
            get
            {
                if (databaseCurrentFairProject == null)
                {
                    databaseCurrentFairProject = new CurrentFairProjectDataBase(
                        Path.Combine(
                            Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), DATABASE_NAME_CurrentFairProject));
                }
                return databaseCurrentFairProject;
            }
        }

        public static CurrentFairProjectTable CurrentFairProject
        {
            get
            {
                var cfp = new CurrentFairProjectTable();
                if(DatabaseCurrentFairProject != null)
                {
                    cfp = DatabaseCurrentFairProject.GetProjectAsync(0).Result;
                }
                return cfp;
            }
        }

        public App()
        {
            InitializeComponent();
            App.DatabaseFairProjects.DeleteAll();
            var fairparcer = new FairParser();
            fairparcer.pfHSEParse();
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
