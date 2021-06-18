using Microsoft.AspNetCore.Mvc;
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
        private readonly BookRepository _bookRepository = null;

        public BookController()
        {
            _bookRepository = new BookRepository();
        }

       public ViewResult GetAllBooks()
        {
            var books = _bookRepository.GetAllBooks();
            return View(books);
        }
        public ViewResult GetBook(int id)
        {
            var book =  _bookRepository.GetBookById(id);

            return View(book);
        }
        public List<Book> SearchAllBooks(string BookName,string AuthorName)
        {
            return _bookRepository.SearchBook(BookName, AuthorName);
        }

    }
}
