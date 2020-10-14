using System.Collections.Generic;
using System.Threading.Tasks;
using backend.Models;
using MongoDB.Bson;
using MongoDB.Driver;

namespace backend.Repositories {
    public class BillCollection : IBillCollection {

        private IMongoCollection<Bill> collection;

        public BillCollection () {
            collection = MongoDbRepo.GetInstance().GetCollection<Bill> ("Bills");
        }

        public async Task DeleteBill (string id) {
            var filter = Builders<Bill>.Filter.Eq (x => x.Id, new ObjectId (id));
            await collection.DeleteOneAsync (filter);
        }

        public async Task<List<Bill>> GetAllBills () {
            return await collection.FindAsync (new BsonDocument ()).Result.ToListAsync();
        }

        public async Task<Bill> GetBillById (string id) {
            return await collection.FindAsync (new BsonDocument { { "_id", new ObjectId (id) } }).Result.FirstAsync ();
        }

        public async Task InsertBill (Bill bill) {
            await collection.InsertOneAsync (bill);
        }

        public async Task UpdateBill (Bill bill) {
            var filter = Builders<Bill>.Filter.Eq (x => x.Id, bill.Id);
            await collection.ReplaceOneAsync (filter, bill);
        }
    }
}