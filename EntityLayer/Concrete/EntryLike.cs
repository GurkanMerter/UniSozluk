using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class EntryLike
    {
        
        public int EntryLikeID { get; set; }
        public int EntryID { get; set; }
        public int Score { get; set; } // artı eksi toplamı
        public int Count { get; set; }  // toplam etkileşim
    }
}
