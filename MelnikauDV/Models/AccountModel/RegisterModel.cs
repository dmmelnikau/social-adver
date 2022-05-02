using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MelnikauDV.Models.AccountModel
{
    public class RegisterModel
    {
      
        [Required(ErrorMessage = "Поле Почта пустое")]
        [DisplayName("Почта")]
        [EmailAddress(ErrorMessage = "Нужно ввести значения в это поле в формате ****@***")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Не указан пароль")]
        [DataType(DataType.Password)]
        [DisplayName("Пароль")]

        public string Password { get; set; }
        [DisplayName("Подтверждение пароля")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Пароль введен неверно")]
        public string ConfirmPassword { get; set; }
    }
}
