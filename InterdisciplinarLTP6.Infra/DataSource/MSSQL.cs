using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterdisciplinarLTP6.Infra.DataSource
{
    public class MSSQL : IDB
    {
        private SqlConnection _con;
        public void Dispose()
        {
            _con.Close();
            _con.Dispose();
        }

        public IDbConnection GetConnection()
        {
            return _con = new SqlConnection("Server=DESKTOP-23IN36H; database = Interdiciplinar; user=sa; Password=123");
        }
    }
}
