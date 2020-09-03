using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using HSEapp.Pages;

namespace HSEapp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new FairMainPage();
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
