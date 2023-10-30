using Microsoft.EntityFrameworkCore;
using SideDesk.ClientRegister.Application.Entities;
using SideDesk.ClientRegister.Domain.Interfaces.Repositories;
using SideDesk.ClientRegister.Infrastructure.Context;
using SideDesk.ClientRegister.Infrastructure.Repositories.Base;

namespace SideDesk.ClientRegister.Infrastructure.Repository
{
	public class ClientRepository : Repository<Client>, IClientRepository
	{
		public ClientRepository(DataContext dataContext) : base(dataContext)
		{
		}

		public async Task<Client?> GetClientByDocumentAsync(string document) 
		{
			return await Set.Where(client => client.Document.Equals(document)).FirstOrDefaultAsync();
		}
	}
}
