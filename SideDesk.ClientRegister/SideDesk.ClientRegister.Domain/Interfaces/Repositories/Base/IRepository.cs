namespace SideDesk.ClientRegister.Domain.Interfaces.Repositories.Base
{
	public interface IRepository<T> where T : class
	{
		void Create(T model);
		int SaveChanges();
	}
}
