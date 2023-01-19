using EntityLayer.Concrete;
using System.Collections.Generic;

namespace UniSozluk.Models
{
    public class UserUpdateViewModel
    {
        public string name { get; set; }
        public string surname { get; set; }
        public string nickname { get; set; }
        public string mail { get; set; }
        public string password { get; set; }
        public string telno { get; set; }
        public string university { get; set; }

        public List<University> Universities { get; set; }
        public string departmant { get; set; }

        public List<Departmant> departmants { get; set; }
    }
}
