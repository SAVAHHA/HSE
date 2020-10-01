using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using HSEapp.Pages;
using HSEapp.Data;
using System.IO;
using System.Collections.Generic;

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

        public static FairProjectTable CurrentFairProject
        {
            get
            {
                var cfp = new FairProjectTable();
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
            var parcer = new Parser();
            parcer.pfHSEParse();
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
