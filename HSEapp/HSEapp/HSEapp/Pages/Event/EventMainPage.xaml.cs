using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HSEapp.Pages.Event
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EventMainPage : ContentPage
    {
        public EventMainPage()
        {
            InitializeComponent();
        }

        private void studLiveButton_Clicked(object sender, EventArgs e)
        {
            Uri siteUri = new Uri("https://studlife.hse.ru/");
            Launcher.OpenAsync(siteUri);
        }

        private void sportButton_Clicked(object sender, EventArgs e)
        {
            Uri siteUri = new Uri("https://sport.hse.ru/");
            Launcher.OpenAsync(siteUri);
        }

        private void openCoursesButton_Clicked(object sender, EventArgs e)
        {
            Uri siteUri = new Uri("https://elearning.hse.ru/mooc");
            Launcher.OpenAsync(siteUri);
        }
    }
}