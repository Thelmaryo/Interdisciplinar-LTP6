using InterdisciplinarLTP6.Domain.Entities;
using InterdisciplinarLTP6.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterdisciplinarLTP6.Domain.Queries
{
    public class EmployeeQuery
    {
        private readonly IRepositoryEmployee _EREP;

        public EmployeeQuery(IRepositoryEmployee EREP)
        {
            _EREP = EREP;
        }

        public async Task<IEnumerable<Employee>> GetEmployees()
        {
            return await _EREP.List();
        }
    }
}
