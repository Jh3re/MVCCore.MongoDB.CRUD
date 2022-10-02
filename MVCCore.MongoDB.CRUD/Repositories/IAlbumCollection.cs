using MVCCore.MongoDB.CRUD.Models;

namespace MVCCore.MongoDB.CRUD.Repositories
{
    public interface IAlbumCollection
    {
        void InsertAlbum(Album album);
        void UpdateAlbum(Album album);
        void DeleteAlbum(string id);
        List<Album> GetAllAlbums();
        Album GetAlbumById(string id);
    }
}
