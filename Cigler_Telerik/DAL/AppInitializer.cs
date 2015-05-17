using System;
using System.Collections.Generic;
using System.Data.Entity;
using Cigler_Telerik.Models.Entities;

namespace Cigler_Telerik.DAL
{
	public class AppInitializer : DropCreateDatabaseAlways<CiglerContext>
	{
		public void SeedDebug(CiglerContext db)
		{
			Seed(db);
		}

		private List<string> _names = new List<string>() {"Jano","Petra","Zuzana","Tomas","Honza"};
		private List<string> _lastnames = new List<string>() {"Novotny", "Novakova", "Hudak", "Smith"};
		private List<string> _streets = new List<string>() {"Ceska", "Kounicova", "Orli", "Klusackova","Botanicka"};
		private List<string> _cities = new List<string>() {"Brno", "Praha", "Olomouc", "Frydek-Mystek", "Ceske Budejovice"};
		private List<int> _validIcs = new List<int> {26168685, 28291310, 01673408, 02238586};
        protected override void Seed(CiglerContext db)
		{
			GeneratePeople(5, db);
		}

		private void GeneratePeople(int count, CiglerContext db)
		{
			Random random = new Random();
			for (int i = 0; i < count; i++)
			{
				int r = random.Next(_names.Count);
				int s = random.Next(_lastnames.Count);
				int ic = random.Next(_validIcs.Count);
				Person p = new Person
				{
					FirstName = _names[r],
					LastName = _lastnames[s],
					IC = _validIcs[ic],
					DIC = "CZ"+random.Next(10000000,99999999).ToString()
				};
				db.People.Add(p);
				try
				{
					db.SaveChanges();
				}
				catch (Exception ex)
				{
					System.Diagnostics.Debug.WriteLine(ex.StackTrace);
				}

				for (int j = 0; j < 2; j++)
				{
					int c = random.Next(_cities.Count);
					int st = random.Next(_streets.Count);
					int psc = random.Next(10000, 99999);
					Address adr = new Address()
					{
						Street = _streets[st] + " " + random.Next(100).ToString(),
						City = _cities[c],
						PSC = psc,
						PersonId = p.Id
					};
					db.Addresses.Add(adr);
					db.SaveChanges();
				}
			}
		
		}
	}
}