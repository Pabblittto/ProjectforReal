using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectforReal.ViewModels
{
    public class RegistrationViewModel
    {
        [Required]
        public string Login { get; set; }

        [Display(Name ="Email Addressaa")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name ="Confirm Password")]
        [DataType(DataType.Password)]
        [Compare("Password",ErrorMessage ="Passwords not match")]
        public string ConfirmPassword { get; set; }

        [Display(Name ="Name of your blog")]
        [MaxLength(200,ErrorMessage ="Name of your blog can't have over 200 characters!")]
        public string BlogName { get; set; }

        [DataType(DataType.MultilineText)]
        [MaxLength(1000,ErrorMessage ="Description of your blog can't have over 1000 characters!")]
        public string Description { get; set;}//description of blog

        [Display(Name = "Do you want to create own Blog?")]
        public bool CreateBlog { get; set; }

    }
}
