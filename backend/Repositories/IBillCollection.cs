using System.Collections.Generic;
using System.Threading.Tasks;
using backend.Models;

namespace backend.Repositories
{
    public interface IBillCollection   {

        Task InsertBill(Bill bill);
        Task UpdateBill(Bill bill);
        Task DeleteBill(string id);
        Task<List<Bill>> GetAllBills();
        Task<Bill> GetBillById(string id);

    }

}