using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AddressBook.Models
{
    [Table("TypesBuilding")]
    public class TypesBuilding
    {
        [Key]
        [ScaffoldColumn(false)]
        public int BuildingId { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Длина строки должна быть от 2 до 50 символов")]
        [Display(Name = "Вид здания")]
        public String Type { get; set; }
    }
}