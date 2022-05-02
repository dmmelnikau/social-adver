using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MelnikauDV.Models
{
    public class ProfitAdv
    {
        public int Id { get; set; }
        [Column(TypeName = "int")]
        [Required(ErrorMessage = " Поле Затраты пустое")]
        [DisplayName("Затраты")]
        [Range(1, 100000, ErrorMessage = "Нужно ввести целое число от 1 до 100000")]
        public int Effort { get; set; }
        [DisplayName("Просмотры")]
        [Range(1, 100000000, ErrorMessage = "Нужно ввести целое число от 1 до 10000000")]
        public int PageViews { get; set; }
        [DisplayName("Коэффицент")]
        /*  [Column(TypeName = "int")]
          [Required(ErrorMessage = " Поле Коэффицент пустое")]
         
          [Range(1, 100, ErrorMessage = "Нужно ввести целое число от 1 до 100")]
        */
        public int kef { get; set; }
        [DisplayName("Прибыль")]
        /*
        [Column(TypeName = "int")]
        [Required(ErrorMessage = " Поле Прибыль пустое")]
       
        [Range(1, 10000000, ErrorMessage = "Нужно ввести целое число от 1 до 10000000")]
        */
        public int Profit { get; set; }
        [DisplayName("Реклама")]
        public Advertisement Advertisement { get; set; }
        public int? AdvertisementId { get; set; }
    }
}
