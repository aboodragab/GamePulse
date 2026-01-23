using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamePulse_DataAccess
{
    public class clsDashboardDataAcc
    {
        public static DataRow GetDashboardStatistics()
        {
            DataTable dt = new DataTable();
            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString)) 
            {
                string query = @"SELECT 
            (SELECT ISNULL(SUM(ActualAmount), 0) FROM Transactions WHERE CAST(TransactionDate AS DATE) = CAST(GETDATE() AS DATE)) AS TotalRevenue,
            (SELECT COUNT(*) FROM Cards WHERE IsActive = 1) AS ActiveCards,
            (SELECT COUNT(*) FROM Transactions WHERE TransactionTypeID = 2 AND CAST(TransactionDate AS DATE) = CAST(GETDATE() AS DATE)) AS TodayPlays;";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    try
                    {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                dt.Load(reader);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                    }
                }
            }
            return (dt.Rows.Count > 0) ? dt.Rows[0] : null;
        }

        public static DataTable GetLast50()
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString);

            string sql = "SELECT TOP 50 * FROM vTransactionHistory ORDER BY TransactionDate DESC;";

            SqlCommand command = new SqlCommand(sql, connection);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if(reader.HasRows)
                {
                    dt.Load(reader);
                }
                reader.Close();
            }
            catch(Exception ex)
            {

            }
            finally
            {
                connection.Close();
            }
            return dt;
        }
    }
}
