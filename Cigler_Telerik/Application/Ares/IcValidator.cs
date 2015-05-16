using System;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
using System.Xml.Linq;
using Cigler_Telerik.Application.Ares;

namespace Cigler_Telerik.Application
{
	public class IcValidationAttribute : ValidationAttribute
	{ 
		protected override ValidationResult IsValid(object value, ValidationContext validationContext)
		{
			if (value == null)
			{
				return null;
			}

			int ic = 0;
			bool success = Int32.TryParse(value.ToString(), out ic);

			if (!success)
			{
				return new ValidationResult(ErrorMessage = "IČ musí být číslo.");
			}

			var doc = XmlLoader.GetAresResponse(ic);
			if (doc == null)
			{
				return new ValidationResult(ErrorMessage = "Nastala chyba pri spojení s ARES");
			}
			bool valid  = doc.Root.Element("Odpoved").Element("Pocet_zaznamu").Value != "0";
			if (!valid)
			{
				return new ValidationResult(ErrorMessage = "IČ nenalezeno v ARES.");
			}
			return null;
		}
	}
}