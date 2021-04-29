using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using Xamarin.Forms;

namespace HSEapp.Data.Fair
{
    public class FairSearchHandler: SearchHandler
    {
        public IList<FairProjectTable> FairProjects { get; set; }
        public Type SelectedItemNavigationTarget { get; set; }

        protected override void OnQueryChanged(string oldValue, string newValue)
        {
            base.OnQueryChanged(oldValue, newValue);

            if (string.IsNullOrWhiteSpace(newValue))
            {
                ItemsSource = null;
            }
            else
            {
                ItemsSource = FairProjects
                    .Where(project => project.Name.ToLower().Contains(newValue.ToLower()) | project.CreditAmount.ToString().ToLower().Contains(newValue.ToLower()))
                    .ToList<FairProjectTable>();

            }
        }
    }
}
