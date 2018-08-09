using AddressBook.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace AddressBook.Controllers
{
    public class HomeController : Controller
    {
        AddressContext db = new AddressContext();

        public ActionResult Index()
        {
            return View(State.emptyForm);
        }
        
        // Добавление/редктирование базы данных
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ValidateAddAddressForm(string addressId, string country, string city, string street, int? houseNumber)
        {
            Address address = new Address();
            address.Country = country;
            address.City = city;
            if (address.Street != "")
                address.Street = street;
            address.HouseNumber = houseNumber;
            address.Date = DateTime.Now;

            if (ModelState.IsValid)
            {
                if (addressId == "")
                {
                    foreach (Address adrs in db.AddressesDB)
                    {
                        if (adrs.Country == address.Country &&
                            adrs.City == address.City &&
                            adrs.Street == address.Street &&
                            adrs.HouseNumber == address.HouseNumber)
                        {
                            return PartialView(State.errorExsist);
                        }
                    }
                    db.AddressesDB.Add(address);
                }
                else
                {
                    var addr = await db.AddressesDB.FindAsync(int.Parse(addressId));
                    addr.Country = address.Country;
                    addr.City = address.City;
                    addr.Street = address.Street;
                    addr.HouseNumber = address.HouseNumber;
                    addr.Date = address.Date;
                }
                await db.SaveChangesAsync();
                return PartialView(State.emptyForm);
            }
            return PartialView(State.errorForm);
        }


        [HttpPost]
        public async Task<ActionResult> UpdateAddressesTable()
        {
            var adresses = db.AddressesDB.Include(p => p.TypeBuilding);
            return PartialView("UpdateAddressesTable", await adresses.ToListAsync());
        }
        
    }

    public enum State { emptyForm = 0, errorForm, errorExsist }
}