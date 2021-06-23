using Microsoft.EntityFrameworkCore;
using OutlierBookStorePhase2.Context;
using OutlierBookStorePhase2.Models;
using OutlierBookStorePhase2.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OutlierBookStorePhase2.Repository
{
    public class BookOperations : IBookOperations
    {
        private readonly ApplicationDbContext _context;

        public BookOperations(ApplicationDbContext context)
        {
            _context = context;
        }

        public int AddNewBook(Book book)
        {
            foreach (var file in book.Gallery)
            {
                _context.Galleries.Add(file);
            }
            _context.Books.Add(book);
           return _context.SaveChanges() <= 0 ? 0 : book.Id;
        }

        public ICollection<Book> GetAllBooks()
        {
            var allBooks = _context.Books.ToList();
            if(allBooks == null)
            {
                return null;
            }
            return allBooks;
        }

        public Book GetBookById(int id)
        {
            var book = _context.Books.FirstOrDefault(x => x.Id == id);

            var language = _context.Languages.FirstOrDefault(x => x.Id == book.LanguageId);

            var galleryfiles = _context.Galleries.Where(x => x.BookId == book.Id).ToList();        
           
            book.Gallery = galleryfiles;
            
            book.Language = language;

            return book == null ? null : book;
        }
    }
}
