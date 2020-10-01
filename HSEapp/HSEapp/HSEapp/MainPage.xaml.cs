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
            List<pfHSEData> pfHSEDatas = new List<pfHSEData>();
            try
            {
                var parcer = new Parser();
                pfHSEDatas = parcer.pfHSEParse();
                T(pfHSEDatas);
            }
            catch
            {
                F();
            }
        }

        private async void T(List<pfHSEData> pfHSEDatas)
        {
            await DisplayAlert(pfHSEDatas.Count.ToString(), "", "OK");
        }

        private async void F()
        {
            await DisplayAlert("Bad", "", "OK");
        }
    }
}