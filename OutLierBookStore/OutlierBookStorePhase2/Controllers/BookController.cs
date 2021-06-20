using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using OutlierBookStorePhase2.Models;
using OutlierBookStorePhase2.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OutlierBookStorePhase2.Controllers
{
    public class BookController : Controller
    {
        private readonly IBookOperations _bookOperations;
        private readonly ILanguageOperations _languageOperations;
        public BookController(IBookOperations bookOperations,ILanguageOperations languageOperations)
        {
            _bookOperations = bookOperations;
            _languageOperations = languageOperations;
        }



        public IActionResult GetAllBooks()
        {
            var allBooks = _bookOperations.GetAllBooks();
            if (allBooks == null)
            {
                return Content("No Books Found");
            }
            return View(allBooks);
        }


        public IActionResult GetBookById(int id)
        {
            var book = _bookOperations.GetBookById(id);
            return book == null ? Content($"No Book with Id {id} found") : View(book);
        }

        public IActionResult AddNewBook(bool isSuccess = false,int id = 0)
        {
            var book = new Book();

            ViewBag.Language = new SelectList(_languageOperations.GetAllLanguages(), "Id", "Name");

            ViewBag.IsSuccess = isSuccess;
            ViewBag.Id = id;

            return View(book);
        }

        [HttpPost]
        public IActionResult AddNewBook(Book book)
        {
            if (ModelState.IsValid)
            {
                int id = _bookOperations.AddNewBook(book);
                if(id > 0)
                {
                    return RedirectToAction("AddNewBook", new { isSuccess = true, id = book.Id });
                }
            }

           ViewBag.Language = new SelectList(_languageOperations.GetAllLanguages(), "Id", "Name");
            return View();
        }

    }
}
