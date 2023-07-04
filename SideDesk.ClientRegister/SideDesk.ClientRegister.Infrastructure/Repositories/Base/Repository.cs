using Microsoft.EntityFrameworkCore;
using SideDesk.ClientRegister.Domain.Interfaces.Repositories.Base;
using SideDesk.ClientRegister.Infrastructure.Context;

namespace SideDesk.ClientRegister.Infrastructure.Repositories.Base
{
	public class Repository<T> : IRepository<T> where T : class
	{
		public DataContext context;
		public DbSet<T> Set;

		public Repository(DataContext dataContext)
		{
			context = dataContext;
			Set = dataContext.Set<T>();
		}

		public void Create(T entity) => Set.Add(entity);
		public int SaveChanges() => context.SaveChanges();
	}
}
