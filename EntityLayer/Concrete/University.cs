using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EntityLayer.Concrete
{
    public class University
    {
        [Key]
        public int UniversityID { get; set; }
        public string UniversityName { get; set; }
        public bool UniversityStatus { get; set; }
        public List<Departmant> Departmants { get; set; }
    }
}
