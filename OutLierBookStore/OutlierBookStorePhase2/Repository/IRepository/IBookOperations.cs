using OutlierBookStorePhase2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OutlierBookStorePhase2.Repository.IRepository
{
    public interface IBookOperations
    {
        public ICollection<Book> GetAllBooks();

        public Book GetBookById(int id);

        public int AddNewBook(Book book);
    }
}
