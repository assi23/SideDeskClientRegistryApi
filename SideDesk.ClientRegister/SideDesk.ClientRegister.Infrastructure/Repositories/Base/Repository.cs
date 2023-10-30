using Microsoft.EntityFrameworkCore;
using SideDesk.ClientRegister.Domain.Interfaces.Repositories.Base;
using SideDesk.ClientRegister.Infrastructure.Context;

namespace SideDesk.ClientRegister.Infrastructure.Repositories.Base
{
	public abstract class Repository<T> : IRepository<T> where T : class
	{
		public DataContext context;
		public DbSet<T> Set;

		public Repository(DataContext dataContext)
		{
			context = dataContext;
			Set = dataContext.Set<T>();
		}

		public async Task CreateAsync(T entity)
		{
			await Set.AddAsync(entity);
		}

		public async Task<int> SaveChangesAsync()
		{
			return await context.SaveChangesAsync();
		}
	}
}
