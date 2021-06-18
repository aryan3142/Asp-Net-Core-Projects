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
        public  List<Book> GetAllBooks()
        {
            return DataSource();
        }

        public Book GetBookById(int id)
        {
            return DataSource().Where(x => x.Id == id).FirstOrDefault();
        }

        public List<Book> SearchBook(string title,string authorName)
        {
            return DataSource().Where(x => x.Title.Contains(title) || x.Author.Contains(authorName)).ToList();
        }

        private List<Book> DataSource()
        {
            return new List<Book>()
            {
                new Book(){Id = 1, Title = "Mvc", Author="Aryan" , Description="This book is best for learning Asp.Net MVC", Category="Frameworks",Langauge ="English", TotalPages=1345},
                new Book(){Id = 2, Title = "Mvc2", Author="Chodankur", Description="This book is best for learning Asp.Net MVC latest version",Category="Programming",Langauge ="German", TotalPages=155},
                new Book(){Id = 3, Title = "Mvc C#", Author="Pelankur", Description="This book is best for learning Asp.Net MVC basics",Category="Developer",Langauge ="Russian", TotalPages=165},
                new Book(){Id = 4, Title = "Mvc with angular", Author="Ankur", Description="This book is best for learning Asp.Net MVC with angular",Category="Backend",Langauge ="Chinese", TotalPages=645},
                new Book(){Id = 5, Title = "Docker", Author="Swati", Description="This book is best for learning Docker",Category="Deployment",Langauge ="English", TotalPages=150},
                new Book(){Id = 6, Title = "Azure", Author="Singh", Description="This book is best for learning Azure",Category="Cloud" ,Langauge ="Italian", TotalPages=456}
            };
        }
    }
}
