using CodingWiki_DataAccess.Data;
using CodingWiki_Model.Models;
using Microsoft.AspNetCore.Mvc;

namespace CodingWiki_Web.Controllers
{
    public class AuthorController : Controller
    {
        private readonly ApplicationDbContext _db;  

        public AuthorController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            List<Author> authorList = _db.Authors.ToList();
          return View(authorList);
        }

        //GET Method
        public IActionResult Upsert(int? id)
        {
            Author obj = new();
            if(id == null || id==0) 
            {
                //create
                return View(obj);
            }

            // update
            obj = _db.Authors.FirstOrDefault(u => u.Author_Id == id);
            if(obj == null) 
            {
                return NotFound();
            }

            return View(obj);
        }

        //POST 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(Author obj)
        {
            if(ModelState.IsValid) 
            {
                if(obj.Author_Id == 0)
                {
                    //create 
                    _db.Authors.Add(obj);
                }
                else { 
                    //update
                    _db.Authors.Update(obj);
                }
                _db.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(obj);
        }
    }
}
