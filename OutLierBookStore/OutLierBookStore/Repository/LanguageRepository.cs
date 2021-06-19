using Microsoft.EntityFrameworkCore;
using OutLierBookStore.Context;
using OutLierBookStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OutLierBookStore.Repository
{
    public class LanguageRepository
    {
        private readonly BookStoreContext _context;
        public LanguageRepository(BookStoreContext context)
        {
            _context = context;
        }

        public async Task<List<LanguageModel>> GetLanguage()
        {
            return await _context.Languages.Select(x => 
                  
                  new LanguageModel()
                  {
                      Id = x.Id,
                      Description = x.Description,
                      Name = x.Name
                  }).ToListAsync();
        }
    }
}
