using AspNetWithMongo.Models;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetWithMongo.Repository
{
    public interface IShipwreckRepository
    {
        IEnumerable<Shipwreck> GetShipwrecks();
        void AddShipwreck(Shipwreck shipwreck);
        bool UpdateShipwreck(Shipwreck shipwreck);
        bool DeleteShipwreck(string id);
        Shipwreck GetShipwreckById(string id);
    }
}
