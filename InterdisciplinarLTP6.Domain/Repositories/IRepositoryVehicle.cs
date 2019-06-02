using InterdisciplinarLTP6.Domain.Entities;
using System;
using System.Threading.Tasks;

namespace InterdisciplinarLTP6.Domain.Repositories
{
    public interface IRepositoryVehicle
    {
        Task<Vehicle> GetByPlate(string Plate);
    }
}
