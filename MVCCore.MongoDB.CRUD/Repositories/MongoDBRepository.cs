using MongoDB.Driver;

namespace MVCCore.MongoDB.CRUD.Repositories
{
    public class MongoDBRepository
    {
        public MongoClient client;
        public IMongoDatabase db;
        public MongoDBRepository()
        {
            client = new MongoClient("mongodb+srv://jhere_1:mongodb2024@atlascluster.wlowxds.mongodb.net/?retryWrites=true&w=majority");
            db = client.GetDatabase("MusicCatalog");
        }
    }
}
