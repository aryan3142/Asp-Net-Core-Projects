using AspNetWithMongo.Data;
using AspNetWithMongo.Models;
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
        public async Task<IEnumerable<Shipwreck>> GetShipwrecks()
        {
            return await _shipwreckContext.ShipWrecks.FindAsync(x => x.FeatureType == "Wrecks - Visible").ToListAsync();
        }
    }
}
