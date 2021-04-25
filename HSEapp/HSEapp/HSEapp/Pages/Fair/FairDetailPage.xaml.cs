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
            CampusLabel.Text = App.CurrentFairProject.Campus;
            ForOPLabel.Text = App.CurrentFairProject.OPs;
            JoinUntilLabel.Text = App.CurrentFairProject.Deadline;
            CreditAmountLabel.Text = App.CurrentFairProject.Points;
            LeaderLabel.Text = App.CurrentFairProject.Curator;
            InitiatingUnitLabel.Text = App.CurrentFairProject.Initiator;
            ProjectTypeLabel.Text = App.CurrentFairProject.ProjectType;
            ProjectDescriptionLabel.Text = App.CurrentFairProject.Description;
            EmploymentTypeLabel.Text = App.CurrentFairProject.WorkType;
            LocationLabel.Text = App.CurrentFairProject.Territory;
            CourseLabel.Text = App.CurrentFairProject.Course;
            ProjectPeriodLabel.Text = App.CurrentFairProject.Dates;
            VacantPlacesLabel.Text = App.CurrentFairProject.VacancyNum;
            ProjectIntencityLabel.Text = App.CurrentFairProject.Intensivity;
            WayOfSettingProblemLabel.Text = App.CurrentFairProject.TaskType;
            //T();
        }

        private async void T()
        {
            await DisplayAlert(App.CurrentFairProject.Name, "", "OK");
        }
    }
}