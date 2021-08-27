using AspNetWithMongo.Data;
using AspNetWithMongo.Models;
using MongoDB.Bson;
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

        public void AddShipwreck(Shipwreck shipwreck)
        {
            _shipwreckContext.ShipWrecks.InsertOne(shipwreck);
        }

        public bool UpdateShipwreck(Shipwreck shipwreck)
        {
            var updatedResult = _shipwreckContext.ShipWrecks.ReplaceOne(filter: x => x.Id == shipwreck.Id, replacement: shipwreck);
            return updatedResult.IsAcknowledged && updatedResult.ModifiedCount > 0;
        }

        public bool DeleteShipwreck(string id)
        {
            DeleteResult deleteResult = _shipwreckContext.ShipWrecks.DeleteOne(filter: x => x.Id == id);
            return deleteResult.IsAcknowledged && deleteResult.DeletedCount > 0;

        }

        public Shipwreck GetShipwreckById(string id)
        {
            return _shipwreckContext.ShipWrecks.Find(x => x.Id == id).FirstOrDefault();
        }
    }
}
