namespace SideDesk.ClientRegister.Domain.Interfaces.Repositories.Base
{
	public interface IRepository<T> where T : class
	{
		Task CreateAsync(T model);
		Task<int> SaveChangesAsync();
	}
}
