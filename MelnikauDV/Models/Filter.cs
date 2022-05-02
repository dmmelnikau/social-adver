using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MelnikauDV.Models
{
    public class Filter
    {
        [Column(TypeName = "int")]
        [Required(ErrorMessage = " Поле Прибыль пустое")]
        [DisplayName("Прибыль")]
        [Range(1, 10000000, ErrorMessage = "Нужно ввести целое число от 1 до 10000000")]
        public IEnumerable<ProfitAdv> Profits { get; set; }
            public SelectList Advertisements { get; set; }
        [Column(TypeName = "int")]
        [Required(ErrorMessage = " Поле Прибыль пустое")]
        [DisplayName("Прибыль")]
        [Range(1, 10000000, ErrorMessage = "Нужно ввести целое число от 1 до 10000000")]
        public int Profit { get; set; }
        
    }
}
