using OutlierBookStorePhase2.Context;
using OutlierBookStorePhase2.Models;
using OutlierBookStorePhase2.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OutlierBookStorePhase2.Repository
{
    public class LanguageOperations : ILanguageOperations
    {
        private readonly ApplicationDbContext _context;
        public LanguageOperations(ApplicationDbContext context)
        {
            _context = context;
        }
        public ICollection<Language> GetAllLanguages()
        {
            var languages = _context.Languages.ToList();
            return languages == null ? null : languages;
        }
    }
}
