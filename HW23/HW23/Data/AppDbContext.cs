using HW23.Models;
using Microsoft.EntityFrameworkCore;

namespace HW23.Data
{
	public class AppDbContext : DbContext
	{
		public virtual DbSet<Car> Cars => Set<Car>();

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer();
		}
	}
}
