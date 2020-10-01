using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HSEapp.Data;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HSEapp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : Shell
    {
        public MainPage()
        {
            InitializeComponent();
            T();
        }

        private async void T()
        {
            await DisplayAlert(App.DatabaseFairProjects.GetProjectsAsync().Result.Count().ToString(), App.DatabaseFairProjects.GetProjectAsync(1).Result.Name, "OK");
        }
    }
}