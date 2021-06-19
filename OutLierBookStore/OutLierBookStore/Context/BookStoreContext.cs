using Microsoft.EntityFrameworkCore;
using OutLierBookStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OutLierBookStore.Context
{
    public class BookStoreContext : DbContext
    {
        public BookStoreContext(DbContextOptions<BookStoreContext> options) : base(options)
        {

        }

        public DbSet<BookModel> Books { get; set; }
        public DbSet<Language> Languages { get; set; }
    }
}
