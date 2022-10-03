using MongoDB.Driver;

namespace MVCCore.MongoDB.CRUD.Repositories
{
    public class MongoDBRepository
    {
        public MongoClient client;
        public IMongoDatabase db;
        public MongoDBRepository()
        {
            // La cadena de conexion para usar MongoDB Atlas
            // Mismo caso para conectar powershell, pero usamos la opciond de conectar a una aplicacion
            client = new MongoClient("mongodb+srv://jhere_1:mongodb2024@atlascluster.wlowxds.mongodb.net/?retryWrites=true&w=majority");
            db = client.GetDatabase("MusicCatalog");
        }
    }
}
