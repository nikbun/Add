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
			SelectList types = new SelectList(db.TypeBuildDB, "BuildingId", "TypeBuild");
			ViewBag.Types = types;
			return View(State.emptyForm);
		}
		
		// Добавление/редактирование базы данных
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<ActionResult> ValidateAddAddressForm(string addressId, string country, string city, string street, int? houseNumber, int? buildingId)
		{
			Address address = new Address();
			address.Country = CapitalLetter(country);
			address.City = CapitalLetter(city);
			if (address.Street != "")
				address.Street = CapitalLetter(street);
			address.HouseNumber = houseNumber;
			address.Date = DateTime.Now;
			address.TypeBuildId = buildingId;

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
					addr.TypeBuildId = address.TypeBuildId;
				}
				await db.SaveChangesAsync();
				return PartialView(State.emptyForm);
			}
			return PartialView(State.errorForm);
		}

		[HttpPost]
		public async Task<ActionResult> UpdateAddressesTable()
		{
			//var adrs = await db.AddressesDB.Include(p => p.TypeBuilding).ToListAsync<Address>();
			return PartialView("UpdateAddressesTable", await db.AddressesDB.Include(t => t.TypeBuilding).ToListAsync());
		}

		/// <summary>
		/// Перевести первую букву в верхний регистр
		/// </summary>
		/// <param name="str">Пример: "слово"</param>
		/// <returns>Пример: "Слово"</returns>
		private string CapitalLetter(string str)
		{
			if (str != "")
			{
				String[] astr = str.Split(' ');
				str = "";
				foreach (String s in astr)
				{
					str += s.Substring(0, 1).ToUpper() + (s.Length > 1 ? s.Substring(1).ToLower() : "") + " ";
				}
				//дод Удалить последний пробел
				

				return str;
			}
			else
				return "";
		}
	}

	public enum State { emptyForm = 0, errorForm, errorExsist }
}