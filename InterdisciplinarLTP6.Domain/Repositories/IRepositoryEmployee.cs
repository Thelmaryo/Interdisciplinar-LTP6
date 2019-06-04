using InterdisciplinarLTP6.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InterdisciplinarLTP6.Domain.Repositories
{
    public interface IRepositoryEmployee
    {
        Task Create(Employee employee);
        Task<IEnumerable<Employee>> List();

        Task<int> Quantity();
    }
}
