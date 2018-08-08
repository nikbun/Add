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
        public int AddressId { get; set; }

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

        [RegularExpression(@"^([1-9][0-9]?|([1-9][0-9][0-57-9]|[1-57-9][0-9]{2}|[1-9][0-57-9][0-9])|[1-9][0-9]{3,4})$", ErrorMessage = "Введите целое число от 1 до 665 или от 667 до 99999")]
        [Display(Name = "№ дома")]
        public int? HouseNumber { get; set; }

        [ScaffoldColumn(false)]
        [Display(Name = "Дата добавления записи")]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
        
        [Display(Name = "Вид здания")]
        [RegularExpression(@"^[0-9]{0,5}$", ErrorMessage = "Целое число от 0 до 99999")]
        public int? TypeBuild {get; set;}

        public TypeBuilding Type { get; set; }
    }
}