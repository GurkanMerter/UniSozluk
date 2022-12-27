using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EntityLayer.Concrete
{
    public class User
    {
        [Key]
        public int UserID { get; set; }      
        public string UserFirstName { get; set; }
        public string UserLastName { get; set; }
        public string UserNickName { get; set; }
        public string UserMail { get; set; }
        public string UserPassword { get; set; }
        public string UserTelNo { get; set; } //varchar olarak
        public bool UserStatus { get; set; }
        public List<Entry> Entrys { get; set; }
        public int? DepartmantID { get; set; }
        public Departmant Departmant { get; set; }
    }
}
