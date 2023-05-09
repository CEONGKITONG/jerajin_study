using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFMVVMLogin.Repositories
{
    public class RepositoryBase
    {
        private readonly string _connectString;
        public RepositoryBase()
        {
            _connectString = "Server=(local); Database=MVVMLoginDb; Integrated Security=true";
        }

        protected SqlConnection GetConnection()
        {
            return new SqlConnection(_connectString);
        }
    }
}
