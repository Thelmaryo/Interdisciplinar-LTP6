using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterdisciplinarLTP6.Infra.DataSource
{
    public interface IDB : IDisposable
    {
        IDbConnection GetConnection();
    }
}
