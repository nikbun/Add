using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AddressBook.Models
{
    [Table("TypeBuilding")]
    public class TypeBuilding
    {
        [Key]
        [ScaffoldColumn(false)]
        public int BId { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Длина строки должна быть от 2 до 50 символов")]
        [Display(Name = "Вид здания")]
        public String TypeBuild { get; set; }

        public IEnumerable<Address> Addresses { get; set; }
    }
}