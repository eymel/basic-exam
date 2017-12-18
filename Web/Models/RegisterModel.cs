using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Web.Models
{
    public class RegisterModel
    {
        [Required(ErrorMessage = "Lütfen Ad Soyad Bölümünü doldurunuz")]
        public string FullName { get; set; }
        [Required(ErrorMessage = "Kullanıcı Adı Zorunludur")]
        public string UserName { get; set; }

        [Display(Name ="Şifre")]
        [Required(ErrorMessage = "Şifre Zorunludur")]
        [StringLength(255, ErrorMessage = "Lütfen En az beş karakterli bir şifre giriniz", MinimumLength = 5)]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Display(Name = "Şifre Tekrarı")]
        [Required(ErrorMessage = "Parola Tekrarı Zorunludur")]
        [StringLength(255, ErrorMessage = "Lütfen En az beş karakterli bir şifre giriniz", MinimumLength = 5)]
        [DataType(DataType.Password)]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }
    }
}