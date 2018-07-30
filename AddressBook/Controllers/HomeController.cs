using AddressBook.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Threading.Tasks;
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
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> UpdateAdresses(string country, string city, string street, string houseNumber)
        {
            Address address = new Address();
            address.Country = country;
            address.City = city;
            address.Street = street;
            address.HouseNumber = int.Parse(houseNumber);
            address.Date = DateTime.Now;
            if (ModelState.IsValid)
            {
                db.AddressesDB.Add(address);
                await db.SaveChangesAsync();
            }
            else
            {
                Console.WriteLine("ААААААААААААААААААААААА..... Сам не знаю как так получилось... Честно...");
            }
            return PartialView(db.AddressesDB);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }    
}