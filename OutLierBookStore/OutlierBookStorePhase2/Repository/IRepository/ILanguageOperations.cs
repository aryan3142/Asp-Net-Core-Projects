using OutlierBookStorePhase2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OutlierBookStorePhase2.Repository.IRepository
{
     public interface ILanguageOperations
    {
        public ICollection<Language> GetAllLanguages(); 
    }
}
