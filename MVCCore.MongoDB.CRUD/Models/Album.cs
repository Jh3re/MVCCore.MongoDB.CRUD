using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MVCCore.MongoDB.CRUD.Models
{
    public class Album
    {
        [BsonId]
        public ObjectId Id { get; set; }
        public string AlbumName { get; set; }
        public string Artist { get; set; }
        public DateTime ReleaseDate { get; set; }
        public int Duration { get; set; }

    }
}
