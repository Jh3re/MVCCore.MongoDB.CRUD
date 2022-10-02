using MongoDB.Bson;
using MongoDB.Driver;
using MVCCore.MongoDB.CRUD.Models;

namespace MVCCore.MongoDB.CRUD.Repositories
{
    public class AlbumCollection : IAlbumCollection
    {
        internal MongoDBRepository _repository = new MongoDBRepository();
        private IMongoCollection<Album> Collection;
        public AlbumCollection()
        {
            Collection = _repository.db.GetCollection<Album>("Albums");
        }

        public void DeleteAlbum(string id)
        {
            var filter = Builders<Album>.Filter.Eq(s => s.Id, new ObjectId(id));
            Collection.DeleteOneAsync(filter);
        }

        public Album GetAlbumById(string id)
        {
            var album = Collection.Find(new BsonDocument { { "_id", new ObjectId(id) } }).FirstAsync().Result;

            return album;
        }

        public List<Album> GetAllAlbums()
        {
            var query = Collection.Find(new BsonDocument()).ToListAsync();
            return query.Result;
        }

        public void InsertAlbum(Album album)
        {
            Collection.InsertOneAsync(album);
        }

        public void UpdateAlbum(Album album)
        {
            var filter = Builders<Album>.Filter.Eq(s => s.Id, album.Id);
            Collection.ReplaceOneAsync(filter, album);
        }
    }
}
