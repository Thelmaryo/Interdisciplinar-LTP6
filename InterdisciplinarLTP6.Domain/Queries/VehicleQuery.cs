using InterdisciplinarLTP6.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterdisciplinarLTP6.Domain.Queries
{
    public class VehicleQuery
    {
        private readonly IRepositoryVehicle _VREP;

        public VehicleQuery(IRepositoryVehicle VREP)
        {
            _VREP = VREP;
        }

        public async Task<int> GetVehiclesQuantity()
        {
            return await _VREP.Quantity();
        }
    }
}
