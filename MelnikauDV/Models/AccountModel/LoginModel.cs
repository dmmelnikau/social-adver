using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MelnikauDV
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Поле Почта пустое")]
        [DisplayName("Почта")]
        [EmailAddress(ErrorMessage = "Нужно ввести значения в это поле в формате ****@***")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Не указан пароль")]
        [DataType(DataType.Password)]
        [DisplayName("Пароль")]
        public string Password { get; set; }
    }
}
