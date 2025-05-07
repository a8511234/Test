using Microsoft.Data.SqlClient;
using System.Data;

namespace ForTest.Utility
{
    public class SQLUtility(string conn)
    {
        string connectionString = conn;
        public string CreateQuerySP(string sp,string data)
        {
            string resultJson = null;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(sp, conn))
                {
                    Guid groupId = Guid.NewGuid();

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("JsonInput", data);
                    cmd.Parameters.AddWithValue("GroupID", groupId);
                    SqlParameter output = new SqlParameter("@ReturnJSON", SqlDbType.NVarChar, -1)
                    {
                        Direction = ParameterDirection.Output
                    };
                    cmd.Parameters.Add(output);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    resultJson = (string)output.Value;
                }
            }
            return resultJson;
        }

        public string QuerySP(string sp, string data)
        {
            string resultJson = null;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(sp, conn))
                {
                    Guid groupId = Guid.NewGuid();

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("SID", data);
                    cmd.Parameters.AddWithValue("GroupID", groupId);
                    SqlParameter output = new SqlParameter("@ReturnJSON", SqlDbType.NVarChar, -1)
                    {
                        Direction = ParameterDirection.Output
                    };
                    cmd.Parameters.Add(output);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    resultJson = (string)output.Value;
                }
            }
            return resultJson;
        }

        public string UpdateQuerySP(string sp,string sid, string data)
        {
            string resultJson = null;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(sp, conn))
                {
                    Guid groupId = Guid.NewGuid();

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("SID", sid);
                    cmd.Parameters.AddWithValue("JsonInput", data);
                    cmd.Parameters.AddWithValue("GroupID", groupId);
                    SqlParameter output = new SqlParameter("@ReturnJSON", SqlDbType.NVarChar, -1)
                    {
                        Direction = ParameterDirection.Output
                    };
                    cmd.Parameters.Add(output);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    resultJson = (string)output.Value;
                }
            }
            return resultJson;
        }
    }
}
