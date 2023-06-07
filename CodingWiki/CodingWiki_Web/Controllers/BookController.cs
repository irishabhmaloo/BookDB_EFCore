using CodingWiki_DataAccess.Data;
using CodingWiki_Model.Models;
using CodingWiki_Model.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol;
using System.Reflection.Metadata.Ecma335;

namespace CodingWiki_Web.Controllers
{
    public class BookController : Controller
    {
        private readonly ApplicationDbContext _db;

        public BookController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            List<Book> objList = _db.Books.Include(U => U.Publisher).ToList();
            
            // foreach(var obj in objList)
            // {
                // obj.Publisher = _db.Publishers.Find(obj.Publisher_Id);
            //     _db.Entry(obj).Reference(u => u.Publisher).Load();
            // }
            return View(objList);
        }

        public IActionResult Upsert(int? id) //based on parameter / if yes:update / no:create
        {
            BookVM obj = new();
            obj.PublisherList = _db.Publishers.Select(i => new SelectListItem{
               Text = i.Name,
               Value = i.Publisher_Id.ToString()
            });

            if (id == null || id == 0)
            {
                // create
                return View(obj);
            }

            // edit
            obj.Book = _db.Books.FirstOrDefault(u => u.BookId == id);
            if (obj == null)
            {
                return NotFound(); //NO ENTRY IN RECORD
            }
            return View(obj);

        }


        [HttpPost]
        [ValidateAntiForgeryToken] //security
        public IActionResult Upsert(BookVM obj)
        {
            
            
                if (obj.Book.BookId == 0)
                {
                    //create
                    _db.Books.Add(obj.Book);
                }
                else
                {
                    //update
                    _db.Books.Update(obj.Book);
                }

                _db.SaveChanges();
                return RedirectToAction(nameof(Index)); //redirecting back to the index page
            
        }

        public IActionResult Details(int? id) //based on parameter / if yes:update / no:create
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            BookDetail obj = new();


            // edit
            //.Book1 = _db.Books.FirstOrDefault(u => u.BookId == id);
            obj = _db.BookDetails.Include(u => u.Book1).FirstOrDefault(u => u.Book_Id == id);
            
            if (obj == null)
            {
                return View(obj);
                // return NotFound(); //NO ENTRY IN RECORD
            }
            return View(obj);

        }


        [HttpPost]
        [ValidateAntiForgeryToken] //security
        public IActionResult Details(BookDetail obj)
        {
            
            
                if (obj.BookDetail_Id == 0)
                {
                    //create
                    _db.BookDetails.Add(obj.Book1.BookDetail1);
                }
                else
                {
                    //update
                    _db.BookDetails.Update(obj.Book1.BookDetail1);
                }

                _db.SaveChanges();
                return RedirectToAction(nameof(Index)); //redirecting back to the index page
            
        }

        public IActionResult Delete(int id)
        {
            Book obj = new();
            obj = _db.Books.FirstOrDefault(u => u.BookId == id);
            if (obj == null)
            {
                return NotFound(); //NO ENTRY IN RECORD
            }

            _db.Books.Remove(obj);
            _db.SaveChanges();

            return RedirectToAction(nameof(Index)); //redirecting back to the index page
        }
    }
}
