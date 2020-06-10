using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MolodegBackend.Models
{
    public class Register
    {
        public class RegisterModel
        {
            [Required(ErrorMessage = "Вкажіть ім'я.")]
            [StringLength(20, ErrorMessage = "Ім'я задовге.")]
            public string Login { get; set; }

            [Required(ErrorMessage = "Вкажіть пароль")]
            [StringLength(100, ErrorMessage = "Пароль повинен складатися з не менш ніж 6 символів", MinimumLength = 6)]
            [DataType(DataType.Password)]
            [Display(Name = "Password")]
            public string Password { get; set; }

            [DataType(DataType.Password)]
            [Display(Name = "Підтвердіть пароль")]
            [Compare("Password", ErrorMessage = "Паролі не співпадають")]
            public string ConfirmPassword { get; set; }

            [Required]
            [EmailAddress]
            public string Email { get; set; }
        }

        public class RegisterResult
        {
            public bool Successful { get; set; }
            public List<string> Errors { get; set; }
        }
    }
}
