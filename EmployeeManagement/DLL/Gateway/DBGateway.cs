using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.SqlClient;

namespace EmployeeManagement.DLL.Gateway
{
    class DBGateway
    {
        private SqlConnection connectionObj;
        private SqlCommand commandObj;

        public DBGateway()
        {
            connectionObj = new SqlConnection(@"server=.\sqlexpress;Initial Catalog=EmployeeManagementDB;Integrated Security=true");
            commandObj = new SqlCommand();
        }

        public SqlConnection SqlConnectionObj
        {
            get { return connectionObj; }
        }
        public SqlCommand SqlCommandObj
        {
            get
            {
                commandObj.Connection = connectionObj;
                return commandObj;
            }
        }
    }
}
