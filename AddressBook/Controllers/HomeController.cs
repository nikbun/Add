using AddressBook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AddressBook.Controllers
{
    public class HomeController : Controller
    {
        AddressContext db = new AddressContext();
        
        public ActionResult Index()
        {
            return View(db.AddressesDB);
        }

        [HttpPost]
        public ActionResult UpdateAdresses(string country, string city, string street, string houseNumber)
        {
            Address newAddress = new Address();
            newAddress.Country = country;
            newAddress.City = city;
            newAddress.Street = street;
            newAddress.HouseNumber = int.Parse(houseNumber);
            newAddress.Date = DateTime.Now;
            db.AddressesDB.Add(newAddress);
            db.SaveChanges();
            return PartialView(db.AddressesDB);
        }
    }    
}