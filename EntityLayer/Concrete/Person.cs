using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EntityLayer.Concrete
{
    public class Person
    {
        [Key]
        public int PersonID { get; set; }      
        public string PersonName { get; set; }
        //public string UserLastName { get; set; }
        public string PersonNickName { get; set; }
        public string PersonMail { get; set; }
        public string PersonPassword { get; set; }
        public string PersonTelNo { get; set; } //varchar olarak
        public bool PersonStatus { get; set; }
        public List<Entry> Entrys { get; set; }
        public int? DepartmantID { get; set; }
        public Departmant Departmant { get; set; }
    }
}
