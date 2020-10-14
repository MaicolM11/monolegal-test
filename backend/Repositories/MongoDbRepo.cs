using MongoDB.Driver;

namespace backend.Repositories {
    public class MongoDbRepo {
        public static MongoClient client;
        public static IMongoDatabase db;

        private MongoDbRepo () {

        }

        public static IMongoDatabase GetInstance () {
            if (db == null) {
                client = new MongoClient ("mongodb+srv://maicol:1234@cluster0.c7ppq.mongodb.net/monolegal?retryWrites=true&w=majority");
                db = client.GetDatabase ("monolegal");
            }
            return db;
        }
    }
}