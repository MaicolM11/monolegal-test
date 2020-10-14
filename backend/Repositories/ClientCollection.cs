using System.Collections.Generic;
using System.Threading.Tasks;
using backend.Models;
using MongoDB.Bson;
using MongoDB.Driver;

namespace backend.Repositories {
    public class ClientCollection : IClientCollection {

        private IMongoCollection<Client> collection;

        public ClientCollection () {
            collection = MongoDbRepo.GetInstance().GetCollection<Client> ("Clients");
        }

        public async Task DeleteClient (string id) {
            var filter = Builders<Client>.Filter.Eq (x => x.Id, new ObjectId (id));
            await collection.DeleteOneAsync (filter);
        }

        public async Task<List<Client>> GetAllClients () {
            return await collection.FindAsync (new BsonDocument ()).Result.ToListAsync ();
        }

        public async Task<Client> GetClientById (string id) {
            return await collection.FindAsync (new BsonDocument { { "_id", new ObjectId (id) } }).Result.FirstAsync ();
        }

        public async Task InsertClient (Client client) {
            await collection.InsertOneAsync (client);
        }

        public async Task UpdateClient (Client client) {
            var filter = Builders<Client>.Filter.Eq (x => x.Id, client.Id);
            await collection.ReplaceOneAsync (filter, client);
        }

    }
}