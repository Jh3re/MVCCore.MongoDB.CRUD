using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using MVCCore.MongoDB.CRUD.Models;
using MVCCore.MongoDB.CRUD.Repositories;

namespace MVCCore.MongoDB.CRUD.Controllers
{
    public class AlbumController : Controller
    {
        private IAlbumCollection db = new AlbumCollection();
        // GET: AlbumController
        public ActionResult Index()
        {
            var albums = db.GetAllAlbums();
            return View(albums);
        }

        // GET: AlbumController/Details/5
        public ActionResult Details(string id)
        {
            var album = db.GetAlbumById(id);
            return View(album);
        }

        // GET: AlbumController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AlbumController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                var album = new Album()
                {
                    AlbumName = collection["AlbumName"],
                    Duration = int.Parse(collection["Duration"]),
                    Artist = collection["Artist"],
                    ReleaseDate = DateTime.Parse(collection["ReleaseDate"])
                };

                db.InsertAlbum(album);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: AlbumController/Edit/5
        public ActionResult Edit(string id)
        {
            var album = db.GetAlbumById(id);
            return View(album);
        }

        // POST: AlbumController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(string id, IFormCollection collection)
        {
            try
            {
                var album = new Album()
                {
                    Id = new ObjectId(id),
                    AlbumName = collection["AlbumName"],
                    Duration = int.Parse(collection["Duration"]),
                    Artist = collection["Artist"],
                    ReleaseDate = DateTime.Parse(collection["ReleaseDate"])
                };
                db.UpdateAlbum(album);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: AlbumController/Delete/5
        public ActionResult Delete(string id)
        {
            var album = db.GetAlbumById(id);
            return View(album);
        }

        // POST: AlbumController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(string id, IFormCollection collection)
        {
            try
            {
                db.DeleteAlbum(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
