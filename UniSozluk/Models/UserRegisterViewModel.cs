using EntityLayer.Concrete;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace UniSozluk.Models
{
    public class UserRegisterViewModel
    {
        [Display(Name = "Ad")]
        [Required(ErrorMessage = "Ad Giriniz...")]
        public string FirsName { get; set; }

        [Display(Name = "Soyad ")]
        [Required(ErrorMessage = "Soyad Giriniz...")]
        public string LastName { get; set; }

        [Display(Name = "Mail Adresi")]
        [Required(ErrorMessage = "Mail Adresinizi Giriniz...")]
        public string Mail { get; set; }

        [Display(Name = "Kullanıcı Adı")]
        [Required(ErrorMessage = "Kullanıcı Adı Giriniz...")]
        public string NickName { get; set; }

        [Display(Name = "Üniversite")]
        public string University { get; set; }

        [Display(Name = "Bölüm")]
        public string DepartmantID { get; set; }

        //----------------------------------------------------------

        [Display(Name = "Üniversite")]
        public List<University> Universities { get; set; }

        //----------------------------------------------------------

        [Display(Name = "Şifre")]
        [Required(ErrorMessage = "Şifre Giriniz..")]
        public string Password { get; set; }

        [Display(Name = "Şifre Onay")]
        [Compare("Password", ErrorMessage = "Şifreler uyuşmuyor!")]
        public string ConfirmPassword { get; set; }

    }
}
