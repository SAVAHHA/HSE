using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HSEapp.Pages.Fair
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    //[QueryProperty("URL", "projectURL")]
    public partial class FairDetailPage : ContentPage
    {
       // public string _url { get; set; }
       // public string URL
       // {
         //   set
           // {
                //BindingContext = App.FairProjects.FirstOrDefault(m => m.N == Uri.UnescapeDataString(value));
                //_url = Uri.UnescapeDataString(value);
            //}
          //  get
           // {
           //     return _url;
           // }
       // }
        public FairDetailPage()
        {
            InitializeComponent();
            T();
        }

        private async void T()
        {
            await DisplayAlert(App.CurrentFairProject.Name, "", "OK");
        }
    }
}