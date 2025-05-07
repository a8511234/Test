using Microsoft.Data.SqlClient;
using System.Data;

namespace ForTest.Utility
{
    public class SQLUtility
    {
        public bool QuerySP(Object data)
        {
            string connectionString = "Server=your_server;Database=your_db;User Id=your_user;Password=your_password;";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("YourStoredProcedureName", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    // 範例參數（請依照實際的 SP 參數名稱與型別修改）
                    cmd.Parameters.AddWithValue("@Param1", 123);
                    cmd.Parameters.AddWithValue("@Param2", "Test");

                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            return true;
        }

        public object QuerySPWithRes(Object data)
        {
            string connectionString = "Server=your_server;Database=your_db;User Id=your_user;Password=your_password;";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("YourStoredProcedureName", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@SearchId", 456);

                    conn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Console.WriteLine("Column1: " + reader["Column1"]);
                            // 讀取其他欄位...
                        }
                    }
                }
            }
            return new object();
        }
    }
}
