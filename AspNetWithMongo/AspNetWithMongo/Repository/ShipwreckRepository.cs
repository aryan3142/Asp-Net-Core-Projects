using AspNetWithMongo.Data;
using AspNetWithMongo.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetWithMongo.Repository
{
    public class ShipwreckRepository : IShipwreckRepository
    {
        private readonly IShipwreckContext _shipwreckContext;

        public ShipwreckRepository(IShipwreckContext shipwreckContext)
        {
            _shipwreckContext = shipwreckContext;
        }
        public IEnumerable<Shipwreck> GetShipwrecks()
        {
            return _shipwreckContext.ShipWrecks.Find(x => x.FeatureType == "Wrecks - Visible").ToList();
        }
    }
}
