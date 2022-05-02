using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MelnikauDV.Models
{
    public class Advertisement
    {
        [Key]
        public int AdvertisementId { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        [Required(ErrorMessage = " Поле Компания пустое")]
        [StringLength(50, ErrorMessage = "Введено больше 50 символов в поле Компания")]
        [DisplayName("Компания")]
        public string Company { get; set; }
        [Required(ErrorMessage = "Поле Текст рекламы пустое")]
        [DisplayName("Текст рекламы")]
        [Column(TypeName = "nvarchar(250)")]
        [StringLength(250, ErrorMessage = "Введено больше 250 символов в поле Текст")]
        public string Text { get; set; }
        public int NumberOfLikes { get; set; }
        public int NumberOfDislikes { get; set; }
        public List<User> Users { get; set; } = new List<User>();
        public List<AdvMark> AdvMarks { get; set; } = new List<AdvMark>();

    }
}
