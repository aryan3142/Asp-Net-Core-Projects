using AspNetWithMongo.Models;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetWithMongo.Data
{
    public interface IShipwreckContext
    {
       public IMongoCollection<Shipwreck> ShipWrecks { get; }
    }
}
