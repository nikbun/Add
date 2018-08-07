using AddressBook.Models;
using System;
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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ValidateAddAddressForm(string country, string city, string street, int? houseNumber)
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
                await db.SaveChangesAsync();
                return PartialView(State.emptyForm);
            }
            return PartialView(State.errorForm);
        }


        [HttpPost]
        public async Task<ActionResult> UpdateAddressesTable()
        {
            return PartialView("UpdateAddressesTable", db.AddressesDB);
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

    public enum State { emptyForm = 0, errorForm, errorExsist }
}