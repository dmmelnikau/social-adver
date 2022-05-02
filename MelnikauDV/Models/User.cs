using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MelnikauDV.Models
{
    public class User
    {

        public int Id { get; set; }
        [DisplayName("Почта")]
        [Required(ErrorMessage = " Поле Почта пустое")]
        [EmailAddress(ErrorMessage = "Нужно ввести значения в это поле в формате ****@***")]
        public string Email { get; set; }
        [Required(ErrorMessage = " Поле Пароль пустое")]
        [StringLength(50, ErrorMessage = "Введено больше 50 символов в поле Пароль")]
        [DisplayName("Пароль")]
        public string Password { get; set; }
        public List<Advertisement> Advertisements { get; set; } = new List<Advertisement>();
        public AdvMark Mark{ get; set; }

        public int? RoleId { get; set; }
        [DisplayName("Роль")]
        public Role Role { get; set; }
    }
    public class Role
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public List<User> Users { get; set; }
        public Role()
        {
            Users = new List<User>();
        }
    }
}
