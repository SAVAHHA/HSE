using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using HSEapp.Data;

namespace HSEapp.Pages
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class FairMainPage : ContentPage
    {
        public FairMainPage()
        {
            InitializeComponent();
        }

        private void CollectionView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
        void ScrollView_Scrolled(System.Object sender, Xamarin.Forms.ScrolledEventArgs e)
        {
        }

        void WhatIs_Clicked(System.Object sender, System.EventArgs e)
        {
        }
        void SignUpFor_Clicked(System.Object sender, System.EventArgs e)
        {
        }
        void Notification_Clicked(System.Object sender, System.EventArgs e)
        {
        }
        void Sign_Clicked(System.Object sender, System.EventArgs e)
        {
        }
        void TakeTheCourseOnline_Clicked(System.Object sender, System.EventArgs e)
        {
        }
        void Filtr_Clicked(System.Object sender, System.EventArgs e)
        {
        }
        void SortByAddData_Clicked(System.Object sender, System.EventArgs e)
        {
        }
        void SortByImplementationPeriod_Clicked(System.Object sender, System.EventArgs e)
        {
        }
        void SortByAmountOfCredits_Clicked(System.Object sender, System.EventArgs e)
        {
        }
        void SortByDeadlineForRecordingAProject_Clicked(System.Object sender, System.EventArgs e)
        {
        }

        private async void FairProjectListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            FairProjectTable fairProject = e.Item as FairProjectTable;
            if (fairProject != null)
            {
                var cfp = new FairProjectTable();
                cfp.Id = 0;
                cfp.JoinUntil = fairProject.JoinUntil;
                cfp.Name = fairProject.Name;
                cfp.OPs = fairProject.OPs;
                cfp.Period = fairProject.Period;
                cfp.URL = fairProject.URL;
                cfp.CreditAmount = fairProject.CreditAmount;
                cfp.Curator = fairProject.Curator;
                await App.DatabaseCurrentFairProject.DeleteAll();
                await App.DatabaseCurrentFairProject.SaveProjectAsync(cfp);
                await Shell.Current.GoToAsync($"fairDetailPage?projectName={fairProject.Name}");
            }
        }

        private void CloseButton_Clicked(object sender, EventArgs e)
        {
            InfoStackLayout.IsVisible = false;
        }
    }
}
