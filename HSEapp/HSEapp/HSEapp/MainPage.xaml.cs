using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HSEapp.Data;
using HSEapp.Pages;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HSEapp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : Shell
    {
        Dictionary<string, Type> routes = new Dictionary<string, Type>();
        public Dictionary<string, Type> Routes { get { return routes; } }
        public MainPage()
        {
            InitializeComponent();
            RegisterRoutes();
        }

        void RegisterRoutes()
        {
            routes.Add("fairDetailPage", typeof(FairDetailPage));

            foreach (var item in routes)
            {
                Routing.RegisterRoute(item.Key, item.Value);
            }
        }
    }
}