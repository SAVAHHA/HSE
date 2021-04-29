using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using Xamarin.Forms;

namespace HSEapp.Data.Volonteer
{
    public class VolonteerSearchHandler : SearchHandler
    {
        public IList<VolonteerProjectTable> VolonteerProjects { get; set; }
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
                ItemsSource = VolonteerProjects
                    .Where(project => project.Name.ToLower().Contains(newValue.ToLower()))
                    .ToList<VolonteerProjectTable>();

            }
        }
    }
}
