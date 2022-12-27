using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EntityLayer.Concrete
{
    public class Departmant
    {
        [Key]
        public int DepartmantID { get; set; }
        public string DepartmantName { get; set; }
        public bool DepartmantStatus { get; set; }
        public int? UniversityID { get; set; }
        public University University { get; set; }
        public List<Entry> Entries { get; set; }
        public List<User> Users { get; set; }

    }
}
