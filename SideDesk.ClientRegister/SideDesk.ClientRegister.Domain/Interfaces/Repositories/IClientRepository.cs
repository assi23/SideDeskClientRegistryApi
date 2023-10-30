using SideDesk.ClientRegister.Application.Entities;
using SideDesk.ClientRegister.Domain.Interfaces.Repositories.Base;

namespace SideDesk.ClientRegister.Domain.Interfaces.Repositories
{
	public interface IClientRepository : IRepository<Client>
	{
		Task<Client?> GetClientByDocumentAsync(string document);
	}
}
