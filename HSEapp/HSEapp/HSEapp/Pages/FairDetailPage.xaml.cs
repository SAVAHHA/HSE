using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HSEapp.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    [QueryProperty("Name", "projectName")]
    public partial class FairDetailPage : ContentPage
    {
        public string _name { get; set; }
        public string Name
        {
            set
            {
                BindingContext = App.FairProjects.FirstOrDefault(m => m.Name == Uri.UnescapeDataString(value));
                _name = Uri.UnescapeDataString(value);
            }
            get
            {
                return _name;
            }
        }
        public FairDetailPage()
        {
            InitializeComponent();
        }
    }
}