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
        [Display(Name = "Страна")]
        public String Country { get; set; }

        [Required]
        [Display(Name = "Город")]
        public String City { get; set; }

        [Display(Name = "Улица")]
        public String Street { get; set; }

        [RegularExpression(@"^[0-9]{0,5}$", ErrorMessage = "Разрешен ввод только цифр")]
        [Display(Name = "Номер дома")]
        public int HouseNumber { get; set; }

        [ScaffoldColumn(false)]
        [Display(Name = "Дата добавления записи")]
        public DateTime Date { get; set; }
    }
}