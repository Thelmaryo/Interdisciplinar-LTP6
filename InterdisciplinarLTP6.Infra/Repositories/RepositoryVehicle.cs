using InterdisciplinarLTP6.Domain.Entities;
using InterdisciplinarLTP6.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using InterdisciplinarLTP6.Infra.DataSource;

namespace InterdisciplinarLTP6.Infra.Repositories
{
    public class RepositoryVehicle : IRepositoryVehicle
    {
        private readonly IDB _db;

        public RepositoryVehicle(IDB db)
        {
            _db = db;
        }

        public async Task<Vehicle> GetByPlate(string Plate)
        {
            using (var db = _db.GetConnection())
            {
                return await db.QueryFirstOrDefaultAsync<Vehicle>("SELECT * FROM Vehicle WHERE Plate = @Plate", new { Plate });
            }
        }
    }
}
