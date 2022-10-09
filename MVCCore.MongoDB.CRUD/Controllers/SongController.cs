using Microsoft.AspNetCore.Mvc;
using MVCCore.MongoDB.CRUD.Models;
using MVCCore.MongoDB.CRUD.Repositories;

namespace MVCCore.MongoDB.CRUD.Controllers
{
    public class SongController : Controller
    {
        private IAlbumCollection db = new AlbumCollection();
        public IActionResult Index()
        {
            return View();
        }
        public ActionResult Create(string id)
        {
            SongViewModel songVM = new SongViewModel() { AlbumId = id, Song = new Song() };
            return View(songVM);
        }

        // POST: SongController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                var album = db.GetAlbumById(collection["AlbumId"]);
                if (album.Songs == null)
                    album.Songs = new List<Song>();

                album.Songs.Add(new Song
                {
                    Name = collection["Song.Name"],
                    Duration = int.Parse(collection["Song.Duration"])
                });

                db.UpdateAlbum(album);

                return RedirectToAction("Index","Album");
            }
            catch
            {
                return View();
            }
        }
    }
}
