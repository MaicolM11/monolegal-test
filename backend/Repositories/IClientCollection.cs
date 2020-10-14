using System.Collections.Generic;
using System.Threading.Tasks;
using backend.Models;

namespace backend.Repositories {
    public interface IClientCollection   {

        Task InsertClient(Client client);
        Task UpdateClient(Client client);
        Task DeleteClient(string id);
        Task<List<Client>> GetAllClients();
        Task<Client> GetClientById(string id);

    }

}