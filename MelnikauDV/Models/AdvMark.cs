using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MelnikauDV.Models
{
    public class AdvMark
    {

        [Required(ErrorMessage = " Поле Ид.номер пустое")]
        [DisplayName("Ид.номер")]
        [Range(1, 10, ErrorMessage = "Нужно ввести целое число от 1 до 10")]
        public int Id { get; set; }
       
        public int UserId { get; set; }
        public User User { get; set; }
        public int AdvertisementId { get; set; }
        public Advertisement Advertisement { get; set; }
    }
}
