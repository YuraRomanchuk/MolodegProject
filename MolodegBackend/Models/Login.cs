using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MolodegBackend.Models.Resources
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Вкажіть логін")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Вкажіть пароль")]
        [StringLength(100, ErrorMessage = "Пароль повинен складатися з не менш ніж 6 символів", MinimumLength = 6)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

    }

    public class LoginResult
    {
        public bool Successful { get; set; }
        public List<string> Errors { get; set; }
        public string Token { get; set; }
        public string UserId { get; set; }
    }
}
