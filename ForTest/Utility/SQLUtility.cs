using Microsoft.Data.SqlClient;
using System.Data;

namespace ForTest.Utility
{
    public class SQLUtility()
    {
        string connectionString = "Server=localhost;Database=ForTest;TrustServerCertificate=true;User Id=sa;Password=00000000";

        public string QuerySP(string sp, string sid, string data)
        {
            string resultJson = null;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(sp, conn))
                {
                    Guid groupId = Guid.NewGuid();

                    cmd.CommandType = CommandType.StoredProcedure;
                    if (!string.IsNullOrEmpty(sid))
                    {
                        cmd.Parameters.AddWithValue("SID", sid);
                    }
                    if (!string.IsNullOrEmpty(data))
                    {
                        cmd.Parameters.AddWithValue("JsonInput", data);
                    }
                    cmd.Parameters.AddWithValue("GroupID", groupId);
                    SqlParameter output = new SqlParameter("@ReturnJSON", SqlDbType.NVarChar, -1)
                    {
                        Direction = ParameterDirection.Output
                    };
                    cmd.Parameters.Add(output);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    resultJson = output.Value.ToString();
                }
            }
            return resultJson;
        }
    }
}
