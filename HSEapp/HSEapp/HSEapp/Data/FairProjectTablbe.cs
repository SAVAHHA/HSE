using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace HSEapp.Data
{
    [Table("FairProjects")]
    public class FairProjectTablbe
    {
        [PrimaryKey, Column("_id")]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

    }
}
