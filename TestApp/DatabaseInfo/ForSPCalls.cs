using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Configuration;
using System.Data;

namespace TestApp.DatabaseInfo
{
    public class ForSPCalls
    {

        public SqlConnection sqlCon;
        public ForSPCalls()
        {
        }
        public bool GetvalueFromSP(int inputvalue)
        {
            bool retunValue=false;
            String SqlconString = "Server=(local);Database=Weather;Integrated Security=True;TrustServerCertificate=True ";// _config.GetConnectionString("ConnectionStrings");
            using (sqlCon = new SqlConnection(SqlconString))
            {
                sqlCon.Open();
                SqlCommand sql_cmnd = new SqlCommand("sp_ReturnTrueOnPostiveValue", sqlCon);
                sql_cmnd.CommandType = CommandType.StoredProcedure;
                sql_cmnd.Parameters.AddWithValue("@inputValue", SqlDbType.Int).Value = inputvalue;
                var rdr=sql_cmnd.ExecuteReader();
                while(rdr.Read())
                {
                    retunValue = rdr.GetBoolean(0);
                }
                sqlCon.Close();
            }
            return retunValue;

        }
    }
}
