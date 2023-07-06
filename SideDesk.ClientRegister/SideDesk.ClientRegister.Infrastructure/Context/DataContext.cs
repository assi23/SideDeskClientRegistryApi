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
			ConfigureMappings(modelBuilder);
		}

		private void ConfigureMappings(ModelBuilder modelBuilder)
		{
			modelBuilder.ApplyConfiguration(new ClientMapping());
		}
	}
}
