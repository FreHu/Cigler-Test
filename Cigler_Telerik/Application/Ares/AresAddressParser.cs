using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Cigler_Telerik.Models.Entities;

namespace Cigler_Telerik.Application.Ares
{
	public class AresAddressParser
	{
		public static Address Parse(int ic)
		{
			return null;
			// chcel som tu nacitat adresu automaticky z aresu, no adresy v odpovedi nie su rovnakeho formatu, takze to nejde rozparsovat
			// na porovnanie napriklad 
			// 26168685 - Praha 5 - Smíchov, Radlická 3294/10, PSČ 15000
			// 27074358 - Budějovická 778/3a, Michle, 140 00 Praha 4
			var doc = XmlLoader.GetAresResponse(ic);
			doc.Root.Element("Odpoved").Element("Zaznam").Element("Identifikace").Element("Adresa_ARES").Element("Adresa_textem");
			System.Diagnostics.Debug.WriteLine(doc);
		}

	}
}