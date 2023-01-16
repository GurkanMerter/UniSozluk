using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EntityLayer.Concrete
{
    public class Entry
    {
        [Key]
        public int EntryID { get; set; }
        public string EntryContent { get; set; }
        public DateTime EntryCreateDate { get; set; }
        public bool EntryStatus { get; set; }
        public int PersonID { get; set; }//id tutucak alan
        public Person Persons { get; set; }//entity türünde nesne
        ////'bir Entrya birden fazla yorum gelir' şeklinde 1-n ;
        public List<Comment> Comments { get; set; }
        public int? DepartmantID { get; set; }//id tutucak alan
        public Departmant Departmant { get; set; }//entity türünde nesne
    }
}