using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace HSEapp.Data
{
    [Table("FairProjects")]
    public class FairProjectTable
    {
        [PrimaryKey, Column("_id")]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Campus { get; set; }
        public string Leader { get; set; }
        public string InitiatingUnit { get; set; }
        public string ForOP { get; set; }
        public string Type { get; set; }
        public string EmploymentType { get; set; }
        public string Location { get; set; }
        public string Course { get; set; }
        public string Period { get; set; }
        public string JoinUntil { get; set; }
        public string VacantPlaces { get; set; }
        public string CreditAmount { get; set; }
        public string Intencity { get; set; }
        public string WayOfSettingProblem { get; set; }
    }
}
