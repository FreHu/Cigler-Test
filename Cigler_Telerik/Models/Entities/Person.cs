using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;
using Cigler_Telerik.Application;

namespace Cigler_Telerik.Models.Entities
{
	public class Person
	{
		public int Id { get; set; }

		[Required]
		[Display(Name="Jméno")]
		public string FirstName { get; set; }

		[Required]
		[Display(Name="Příjmení")]
		public string LastName { get; set; }

		[Display(Name="IČ")]
		[IcValidation]
		[DefaultValue(null)]
		public int? IC { get; set; }

		[Display(Name="DIČ")]
		public string DIC { get; set; }

		[Display(Name="Adresy")]
		public virtual ICollection<Address> Addresses { get; set; }
	}
}