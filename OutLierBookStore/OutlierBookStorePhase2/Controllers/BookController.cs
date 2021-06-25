using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using OutlierBookStorePhase2.Models;
using OutlierBookStorePhase2.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace OutlierBookStorePhase2.Controllers
{
    public class BookController : Controller
    {
        private readonly IBookOperations _bookOperations;
        private readonly ILanguageOperations _languageOperations;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public BookController(IBookOperations bookOperations,
            ILanguageOperations languageOperations,
            IWebHostEnvironment webHostEnvironment)
        {
            _bookOperations = bookOperations;
            _languageOperations = languageOperations;
            _webHostEnvironment = webHostEnvironment;
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

        [Authorize]
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
                if(book.CoverPhoto!= null)
                {
                    //if we use this path when we deploy our application into any platform we will get an error of type : this folder is not available, becuse we need the server actual path here
                    //to store the images into this application
                    //we have to use an instance of IWebHostEnvironment, it contains all the details about this environment
                    //we need to make a new variable "serverfolder" inside it we need to define the path of actual folder.
                    string folder = "Book/Cover/";

                    book.CoverPhotoUrl =  UploadFile(folder,book.CoverPhoto);

                }

                if (book.GalleryFiles != null)
                {
                    string folder = "Book/Gallery/";

                    book.Gallery = new List<Gallery>();

                    foreach (var file in book.GalleryFiles)
                    {
                        Gallery gallery1 = new Gallery()
                        {
 
                            Name = file.FileName,
                            URL = UploadFile(folder, file)
                        };
                        book.Gallery.Add(gallery1);
                    }
                   
                }
                if (book.BookPdf != null)
                {
               
                    string folder = "Book/Pdf/";
                    book.BookPdfUrl = UploadFile(folder, book.BookPdf);

                }

                int id = _bookOperations.AddNewBook(book);
                if(id > 0)
                {
                    return RedirectToAction("AddNewBook", new { isSuccess = true, id = book.Id });
                }
            }

           ViewBag.Language = new SelectList(_languageOperations.GetAllLanguages(), "Id", "Name");
            return View();
        }

        private string UploadFile(string folder,IFormFile file)
        {
            //append the filename to the path
            folder += Guid.NewGuid().ToString() + "_" + file.FileName;

            //combining it with the server path
            string serverFolder = Path.Combine(_webHostEnvironment.WebRootPath, folder);

            //save this copy to this particular folder or uploading the file to the folder
            file.CopyTo(new FileStream(serverFolder, FileMode.Create));

            //returning the url or path of the file
            return "/" + folder;
        }
    }
}
