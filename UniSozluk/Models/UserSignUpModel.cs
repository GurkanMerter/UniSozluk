using System.ComponentModel.DataAnnotations;

namespace UniSozluk.Models
{
    public class UserSignUpModel
    {
        [Display(Name = "Ad")]
        [Required(ErrorMessage ="Ad Giriniz...")]
        public string Name { get; set; }

        [Display(Name = "Soyad")]
        [Required(ErrorMessage = "Soyad Giriniz...")]
        public string Surname { get; set; }

        [Display(Name = "Şifre")]
        [Required(ErrorMessage = "Şifre Giriniz..")]
        public string Password { get; set; }

        [Display(Name = "Şifre Onay")]
        [Compare("Password", ErrorMessage ="Şifreler uyuşmuyor!")]
        public string ConfirmPassword { get; set; }

        [Display(Name = "Mail Adresi")]
        [Required(ErrorMessage = "Mail Adresinizi Giriniz...")]
        public string Mail { get; set; }

        [Display(Name = "Kullanıcı Adı")]
        [Required(ErrorMessage = "Kullanıcı Adı Giriniz...")]
        public string UserName { get; set; }

        [Display(Name = "Üniversite")]
        [Required(ErrorMessage = "Üniversitenizi Seçiniz...")]
        public string University { get; set; }

        [Display(Name = "Bölüm")]
        [Required(ErrorMessage = "Bölümünüzü Seçiniz...")]
        public string Departmant { get; set; }
    }
}
