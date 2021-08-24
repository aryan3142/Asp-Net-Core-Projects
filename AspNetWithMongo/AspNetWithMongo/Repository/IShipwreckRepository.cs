using AspNetWithMongo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetWithMongo.Repository
{
    public interface IShipwreckRepository
    {
        Task<IEnumerable<Shipwreck>> GetShipwrecks();
    }
}
