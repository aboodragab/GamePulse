using System;
using System.Data;
using System.Data.SqlClient;

namespace GamePulse_DataAccess
{
    public class clsTransactionTypesDataAcc
    {
        public static DataTable GetAllTransactionTypes()
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString);
            string sql = "SELECT * FROM TransactionTypes";
            SqlCommand command = new SqlCommand(sql, connection);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows) dt.Load(reader);
                reader.Close();
            }
            catch { }
            finally { connection.Close(); }

            return dt;
        }

        public static DataTable GetAllActiveTransactionTypes()
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString);
            string sql = "SELECT * FROM TransactionTypes WHERE isActive = 1";
            SqlCommand command = new SqlCommand(sql, connection);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows) dt.Load(reader);
                reader.Close();
            }
            catch { }
            finally { connection.Close(); }

            return dt;
        }

        public static bool FindByID(int TransactionTypeID, ref string TransactionTypeName, ref bool isActive)
        {
            bool isFound = false;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString);
            string sql = "SELECT * FROM TransactionTypes WHERE TransactionTypeID = @TransactionTypeID";
            SqlCommand command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@TransactionTypeID", TransactionTypeID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    isFound = true;
                    TransactionTypeName = (string)reader["TransactionTypeName"];
                    isActive = (bool)reader["isActive"];
                }
                reader.Close();
            }
            catch { }
            finally { connection.Close(); }

            return isFound;
        }
    }
}