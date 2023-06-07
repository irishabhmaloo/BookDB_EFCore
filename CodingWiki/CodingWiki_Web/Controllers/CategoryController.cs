using CodingWiki_DataAccess.Data;
using CodingWiki_Model.Models;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;

namespace CodingWiki_Web.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _db;

        public CategoryController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            List<SubCategory> objList = _db.SubCategories.ToList();
            return View(objList);
        }

        public IActionResult Upsert(int? id) //based on parameter / if yes:update / no:create
        {
            SubCategory obj = new();
            if(id == null || id == 0)
            {
                // create
                return View(obj);
            }

            // edit
            obj = _db.SubCategories.FirstOrDefault(u => u.Subcatagory_Id == id); 
            if(obj == null)
            {
                return NotFound(); //NO ENTRY IN RECORD
            }
            return View(obj);
        
        }


        [HttpPost]
        [ValidateAntiForgeryToken] //security
        public IActionResult Upsert(SubCategory obj)
        {
            if (ModelState.IsValid)
            {
                if (obj.Subcatagory_Id == 0)
                {
                    //create
                    _db.SubCategories.Add(obj);
                }
                else
                {
                    //update
                    _db.SubCategories.Update(obj);
                }

                _db.SaveChanges();
                return RedirectToAction(nameof(Index)); //redirecting back to the index page
            }
            return View(obj); //if the model state is not valid
        }

        public IActionResult Delete(int id)
        {
            SubCategory obj = new();
            obj = _db.SubCategories.FirstOrDefault(u => u.Subcatagory_Id == id);
            if (obj == null)
            {
                return NotFound(); //NO ENTRY IN RECORD
            }

            _db.SubCategories.Remove(obj);
            _db.SaveChanges();

            return RedirectToAction(nameof(Index)); //redirecting back to the index page
        }

        public IActionResult CreateMultiple2()
        {
            List<SubCategory> subCategories = new();
            for(int i=1; i<=2; i++)
            {
                subCategories.Add(new SubCategory { Name = Guid.NewGuid().ToString() });
            }
            _db.SubCategories.AddRange(subCategories);
            _db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult CreateMultiple5()
        {
            for (int i = 1; i <= 5; i++)
            {
                _db.SubCategories.Add(new SubCategory { Name = Guid.NewGuid().ToString() });
            }
            _db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult RemoveMultiple2()
        {
            IEnumerable<SubCategory> subCategories = _db.SubCategories.OrderByDescending(u => u.Subcatagory_Id).Take(2);
            _db.SubCategories.RemoveRange(subCategories);
            _db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult RemoveMultiple5()
        {
            List<SubCategory> subCategories = _db.SubCategories.OrderByDescending(u => u.Subcatagory_Id).Take(5).ToList();
            _db.SubCategories.RemoveRange(subCategories);
            _db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
