using Microsoft.EntityFrameworkCore;
using OutLierBookStore.Context;
using OutLierBookStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OutLierBookStore.Repository
{
    public class BookRepository
    {
        //repository pattern
        //deals with all the read write operations performed on the data source at one place
        private readonly BookStoreContext _context;
        public BookRepository(BookStoreContext context)
        {
            _context = context;
        }



        public async Task<int> AddNewBook(BookModel book)
        {
            var newBook = new BookModel()
            {
                Author = book.Author,
                Category = book.Category,
                Description = book.Description,
                LangaugeId = book.LangaugeId,
                Title = book.Title,
                TotalPages = book.TotalPages
            };

            await _context.Books.AddAsync(newBook);
            await _context.SaveChangesAsync();

            return newBook.Id;

        }

        public async Task<List<Book>> GetAllBooks()
        {
            var AllBooks = new List<Book>();

            var books = await _context.Books.ToListAsync();
            if(books?.Any() == true)
            {
                foreach (var item in books)
                {
                    AllBooks.Add(
                        new Book()
                        {
                            Id = item.Id,
                            Author = item.Author,
                            Description = item.Description,
                            TotalPages = item.TotalPages ?? 0,
                            LangaugeId = item.LangaugeId,
                            Category = item.Category,
                            Title = item.Title

                        });
                }
            }
            return AllBooks;
        }

        public async Task<Book> GetBookById(int id)
        {
            var bookModel = await _context.Books.FirstOrDefaultAsync(x => x.Id == id);
            Book book = null;
            if(bookModel != null)
            {
                book = new Book()
                {
                    Id = bookModel.Id,
                    Author = bookModel.Author,
                    Description = bookModel.Description,
                    Category = bookModel.Category,
                    LangaugeId = bookModel.LangaugeId,
                    Title = bookModel.Title,
                    TotalPages = bookModel.TotalPages
                };
            }
            return book;
        }

        public List<Book> SearchBook(string title,string authorName)
        {
            return null;
        }

       
    }
}
