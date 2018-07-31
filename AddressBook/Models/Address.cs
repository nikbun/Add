using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AddressBook.Models
{
    [Table("Addresses")]
    public class Address
    {
        [Key]
        [ScaffoldColumn(false)]
        public int AddressID { get; set; }
        
        [Required]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Длина строки должна быть от 2 до 50 символов")]
        [Display(Name = "Страна")]
        public String Country { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Длина строки должна быть от 2 до 50 символов")]
        [Display(Name = "Город")]
        public String City { get; set; }

        [StringLength(50, ErrorMessage = "Длина строки должна быть до 50 символов")]
        [Display(Name = "Улица")]
        public String Street { get; set; }

        [RegularExpression(@"^[0-9]{0,5}$", ErrorMessage = "Введите целое число от 0 до 99999")]
        [Display(Name = "№ дома")]
        public int HouseNumber { get; set; }

        [ScaffoldColumn(false)]
        [Display(Name = "Дата добавления записи")]
        public DateTime Date { get; set; }
    }
}