using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HSEapp.Pages.Volonteer
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class VolonteerMainPage : ContentPage
    {
        public VolonteerMainPage()
        {
            InitializeComponent();
        }

        private void sudentsHelpButton_Clicked(object sender, EventArgs e)
        {
            Uri siteUri = new Uri("https://www.hse.ru/volunteers/school");
            Launcher.OpenAsync(siteUri);
        }

        private void digitalVolonteerButton_Clicked(object sender, EventArgs e)
        {
            Uri siteUri = new Uri("https://www.hse.ru/volunteers/digital");
            Launcher.OpenAsync(siteUri);
        }

        private void HSEVoloteerCenterButton_Clicked(object sender, EventArgs e)
        {
            Uri siteUri = new Uri("https://www.hse.ru/volunteers/");
            Launcher.OpenAsync(siteUri);
        }

        private void elderyPeopleCenterButton_Clicked(object sender, EventArgs e)
        {
            Uri siteUri = new Uri("https://www.hse.ru/volunteers/seniors");
            Launcher.OpenAsync(siteUri);
        }
    }
}