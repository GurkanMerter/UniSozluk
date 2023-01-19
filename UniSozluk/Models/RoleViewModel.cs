using System.ComponentModel.DataAnnotations;

namespace UniSozluk.Models
{
    public class RoleViewModel
    {
        [Required(ErrorMessage = "Lütffen rol adı giriniz")]
        public string name { get; set; }
    }
}
