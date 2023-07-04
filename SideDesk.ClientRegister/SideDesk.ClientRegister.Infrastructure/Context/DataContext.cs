using Microsoft.EntityFrameworkCore;
using SideDesk.ClientRegister.Infrastructure.Mappings;

namespace SideDesk.ClientRegister.Infrastructure.Context
{
	public class DataContext : DbContext
	{
		public DataContext(DbContextOptions<DataContext> contextOptions) : base(contextOptions)
		{
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.HasDefaultSchema("public");

			modelBuilder.ApplyConfiguration(new ClientMapping());
		}
	}
}
