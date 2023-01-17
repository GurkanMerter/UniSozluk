using System.ComponentModel.DataAnnotations;

namespace UniSozluk.Models
{
    public class UserLoginViewModel
    {
        [Required(ErrorMessage = "Lütfen kullanıcı adınızı girin..")]
        public string usernickname { get; set; }

        [Required(ErrorMessage = "Lütfen şifrenizi girin..")]
        public string password { get; set; }
    }
}
