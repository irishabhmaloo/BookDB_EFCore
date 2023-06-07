using CodingWiki_DataAccess.Data;
using CodingWiki_Model.Models;
using Microsoft.AspNetCore.Mvc;

namespace CodingWiki_Web.Controllers
{
    public class PublisherController : Controller
    {
        private readonly ApplicationDbContext _db;

        public PublisherController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            List<Publisher> publisherList = _db.Publishers.ToList();
            return View(publisherList);
        }

        //GET Method
        public IActionResult Upsert(int? id)
        {
            Publisher obj = new();
            if (id == null || id == 0)
            {
                //create
                return View(obj);
            }

            // update
            obj = _db.Publishers.FirstOrDefault(u => u.Publisher_Id == id);
            if (obj == null)
            {
                return NotFound();
            }

            return View(obj);
        }

        //POST 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(Publisher obj)
        {
            if (ModelState.IsValid)
            {
                if (obj.Publisher_Id == 0)
                {
                    //create 
                    _db.Publishers.Add(obj);
                }
                else
                {
                    //update
                    _db.Publishers.Update(obj);
                }
                _db.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(obj);
        }

        public IActionResult Delete(int id)
        {
            Publisher obj = new();
            obj = _db.Publishers.FirstOrDefault(u => u.Publisher_Id == id);
            if (obj == null)
            {
                return NotFound(); //NO ENTRY IN RECORD
            }

            _db.Publishers.Remove(obj);
            _db.SaveChanges();

            return RedirectToAction(nameof(Index)); //redirecting back to the index page
        }
    }
}
