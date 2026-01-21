using System;
using System.Data;
using System.Data.SqlClient;

namespace GamePulse_DataAccess
{
    public class clsGameTypesDataAcc
    {
        public static DataTable GetAllGameTypes()
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString);
            string sql = "SELECT * FROM GameTypes";
            SqlCommand command = new SqlCommand(sql, connection);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows) dt.Load(reader);
                reader.Close();
            }
            catch (Exception ex) { }
            finally { connection.Close(); }

            return dt;
        }

        public static bool FindByID(int GameTypeID, ref string GameTypeName)
        {
            bool isFound = false;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString);
            string sql = "SELECT * FROM GameTypes WHERE GameTypeID = @GameTypeID";
            SqlCommand command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@GameTypeID", GameTypeID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    isFound = true;
                    GameTypeName = (string)reader["GameTypeName"];
                }
                reader.Close();
            }
            catch (Exception ex) { }
            finally { connection.Close(); }

            return isFound;
        }
    }
}