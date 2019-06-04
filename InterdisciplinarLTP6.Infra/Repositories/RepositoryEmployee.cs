using Dapper;
using InterdisciplinarLTP6.Domain.Entities;
using InterdisciplinarLTP6.Domain.Repositories;
using InterdisciplinarLTP6.Infra.DataSource;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterdisciplinarLTP6.Infra.Repositories
{
    public class RepositoryEmployee : IRepositoryEmployee
    {
        private readonly IDB _db;

        public RepositoryEmployee(IDB db)
        {
            _db = db;
        }

        public async Task Create(Employee employee)
        {
            using(var db = _db.GetConnection())
            {
                await db.ExecuteAsync("INSERT INTO Employee (Id,Name, LastName, CPF, VehicleId) VALUES(@ID, @Name, @LastName, @CPF, @VehicleId)", new
                {
                    employee.ID,
                    employee.Name,
                    employee.LastName,
                    employee.CPF,
                    VehicleId = employee.Vehicle.ID
                });
            }
        }

        public async Task<IEnumerable<Employee>> List()
        {
            using (var db = _db.GetConnection())
            {
                var sql = "SELECT * FROM Employee INNER JOIN Vehicle ON (Employee.VehicleId = Vehicle.Id)";
                return await db.QueryAsync<Employee, Vehicle, Employee>(sql, 
                (employee, vehicle) => {
                    employee.AddVehicle(vehicle);
                    return employee;
                }, splitOn: "Id");
                
            }
        }

        public async Task<int> Quantity()
        {
            using (var db = _db.GetConnection())
            {
                var sql = "SELECT COUNT(*) FROM Employee";
                return await db.QuerySingleOrDefaultAsync<int>(sql);

            }
        }
    }
}
