using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using HSEapp.Pages;
using HSEapp.Data;
using System.IO;
using System.Collections.Generic;
using HSEapp.Data.Fair;
using HSEapp.Data.Event;
using HSEapp.Data.Volonteer;

namespace HSEapp
{
    public partial class App : Application
    {
        public const string DATABASE_NAME_FairProjects = "FairProjects.db";
        public const string DATABASE_NAME_CurrentFairProject = "CurrentFairProject.db";
        public const string DATABASE_NAME_EventProjects = "EventProjects.db";
        public const string DATABASE_NAME_VolonteerProjects = "VolonteerProjects.db";

        static FairProjectDataBase databaseFairProjects;
        static CurrentFairProjectDataBase databaseCurrentFairProject;
        static EventProjectDataBase databaseEventProjects;
        static VolonteerProjectDataBase databaseVolonteerProjects;

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

        public static EventProjectDataBase DatabaseEventProjects
        {
            get
            {
                if (databaseEventProjects == null)
                {
                    databaseEventProjects = new EventProjectDataBase(
                        Path.Combine(
                            Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), DATABASE_NAME_EventProjects));
                }
                return databaseEventProjects;
            }
        }

        public static IList<EventProjectTable> EventProjects
        {
            get
            {
                List<EventProjectTable> eventProjects = new List<EventProjectTable>();
                if (databaseEventProjects != null)
                {
                    eventProjects = App.DatabaseEventProjects.GetProjectsAsync().Result;
                }
                return eventProjects;
            }
        }

        public static VolonteerProjectDataBase DatabaseVolonteerProjects
        {
            get
            {
                if (databaseVolonteerProjects == null)
                {
                    databaseVolonteerProjects = new VolonteerProjectDataBase(
                        Path.Combine(
                            Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), DATABASE_NAME_VolonteerProjects));
                }
                return databaseVolonteerProjects;
            }
        }

        public static IList<VolonteerProjectTable> VolonteerProjects
        {
            get
            {
                List<VolonteerProjectTable> volonteerProjects = new List<VolonteerProjectTable>();
                if (databaseVolonteerProjects != null)
                {
                    volonteerProjects = App.DatabaseVolonteerProjects.GetProjectsAsync().Result;
                }
                return volonteerProjects;
            }
        }

        public App()
        {
            InitializeComponent();
            App.DatabaseFairProjects.DeleteAll();
            var fairparcer = new FairParser();
            fairparcer.pfHSEParse();
            var eventparser = new EventParser();
            eventparser.eventParse();
            var volonteerparser = new VolonteerParser();
            volonteerparser.volonteerNewsParse();
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
