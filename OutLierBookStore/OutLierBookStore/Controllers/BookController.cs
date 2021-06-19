using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using OutLierBookStore.Context;
using OutLierBookStore.Models;
using OutLierBookStore.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OutLierBookStore.Controllers
{
    public class BookController : Controller
    {
        private readonly BookRepository _bookRepository;
        private readonly LanguageRepository _languageRepository;

        public BookController(BookRepository repository,LanguageRepository languageRepository)
        {
            _bookRepository = repository;
            _languageRepository = languageRepository;
        }

       public async Task<ViewResult> GetAllBooks()
        {
            var books = await _bookRepository.GetAllBooks();
            return View(books);
        }
        public async Task<ViewResult> GetBook(int id)
        {
            var book =  await _bookRepository.GetBookById(id);

            return View(book);
        }
        public List<Book> SearchAllBooks(string BookName,string AuthorName)
        {
            return _bookRepository.SearchBook(BookName, AuthorName);
        }

        public async Task<ViewResult> AddNewBook(bool isSuccess = false,int bookid = 0)
        {
            var model = new Book();

            ViewBag.Language =  new SelectList(await _languageRepository.GetLanguage(),"Id","Name");


            ViewBag.Id = bookid;
            ViewBag.IsSuccess = isSuccess;

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AddNewBook(BookModel bookModel)
        {
            if (ModelState.IsValid)
            {
                int id = await _bookRepository.AddNewBook(bookModel);
                if (id > 0)
                {
                    return RedirectToAction("AddNewBook", new { isSuccess = true, bookid = id });
                }

            }
            ViewBag.Language = new SelectList(await _languageRepository.GetLanguage(), "Id", "Name");

            return View();

        }

    }
}
