using System.Data.Entity;
using Cigler_Telerik.Models.Entities;

namespace Cigler_Telerik.DAL 
{
	public class CiglerContext : DbContext
	{
		public DbSet<Person> People { get; set; }
		public DbSet<Address> Addresses { get; set; }
	}
}