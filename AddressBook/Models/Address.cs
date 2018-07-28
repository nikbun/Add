using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AddressBook.Models
{
    [Table("Addresses")]
    public class Address
    {
        [Key]
        public int AddressID { get; set; }
        // Страна
        public String Country { get; set; }
        // Город
        public String City { get; set; }
        // Улица
        public String Street { get; set; }
        // Номер дома
        public int HouseNumber { get; set; }
        // Дата добавления записи
        public DateTime Date { get; set; }
    }
}