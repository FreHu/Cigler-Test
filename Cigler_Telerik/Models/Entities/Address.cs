using System.ComponentModel.DataAnnotations;

namespace Cigler_Telerik.Models.Entities
{
	public class Address
	{
		public int PersonId { get; set; }
		public int Id { get; set; }

		[Display(Name="Ulice")]
		public string Street { get; set; }

		[Display(Name="Město")]
		public string City { get; set; }

		[Display(Name="PSČ")]
		public int PSC { get; set; }

	}
}