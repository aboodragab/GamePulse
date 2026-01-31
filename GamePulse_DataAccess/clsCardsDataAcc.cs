using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamePulse_DataAccess
{
    public class clsCardsDataAcc
    {
        public static int AddNewCard(string CardUID, decimal Balance, int CreatedByUserID)
        {
            int CardID = -1;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString);
            string sql = @"INSERT INTO Cards (CardUID, Balance, CreatedDate, isActive, CreatedByUserID)
                       VALUES (@CardUID, @Balance, GETDATE(), 1, @CreatedByUserID);
                       SELECT SCOPE_IDENTITY();";

            SqlCommand command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@CardUID", CardUID);
            command.Parameters.AddWithValue("@Balance", Balance);
            command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);

            try
            {
                connection.Open();
                object result = command.ExecuteScalar();
                if (result != null && int.TryParse(result.ToString(), out int insertedID))
                {
                    CardID = insertedID;
                }
            }
            catch { }
            finally { connection.Close(); }

            return CardID;
        }

        public static bool UpdateCard(int CardID, string CardUID, bool isActive)
        {
            int rowsAffected = 0;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString);
            string sql = @"UPDATE Cards SET CardUID = @CardUID, isActive = @isActive 
                       WHERE CardID = @CardID";

            SqlCommand command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@CardID", CardID);
            command.Parameters.AddWithValue("@CardUID", CardUID);
            command.Parameters.AddWithValue("@isActive", isActive);

            try
            {
                connection.Open();
                rowsAffected = command.ExecuteNonQuery();
            }
            catch { }
            finally { connection.Close(); }

            return rowsAffected > 0;
        }

        public static bool RechargeBalance(int CardID, decimal NewBalance)
        {
            int rowsAffected = 0;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString);
            string sql = @"UPDATE Cards SET Balance = @NewBalance WHERE CardID = @CardID";

            SqlCommand command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@CardID", CardID);
            command.Parameters.AddWithValue("@NewBalance", NewBalance);

            try
            {
                connection.Open();
                rowsAffected = command.ExecuteNonQuery();
            }
            catch { }
            finally { connection.Close(); }

            return rowsAffected > 0;
        }

        public static bool WithdrawBalance(int CardID, decimal NewBalance)
        {
            int rowsAffected = 0;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString);
            string sql = @"UPDATE Cards SET Balance = @NewBalance WHERE CardID = @CardID";

            SqlCommand command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@CardID", CardID);
            command.Parameters.AddWithValue("@NewBalance", NewBalance);

            try
            {
                connection.Open();
                rowsAffected = command.ExecuteNonQuery();
            }
            catch (Exception ex) { }
            finally { connection.Close(); }

            return rowsAffected > 0;
        }

        public static bool FindByID(int CardID, ref string CardUID, ref decimal Balance,
                                    ref DateTime CreatedDate, ref bool isActive, ref int CreatedByUserID)
        {
            bool isFound = false;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString);
            string sql = "SELECT * FROM Cards WHERE CardID = @CardID";
            SqlCommand command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@CardID", CardID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    isFound = true;
                    CardUID = (string)reader["CardUID"];
                    Balance = (decimal)reader["Balance"];
                    CreatedDate = (DateTime)reader["CreatedDate"];
                    isActive = (bool)reader["isActive"];
                    CreatedByUserID = (int)reader["CreatedByUserID"];
                }
                reader.Close();
            }
            catch { }
            finally { connection.Close(); }

            return isFound;
        }

        public static bool FindByUID(string CardUID, ref int CardID, ref decimal Balance,
                                     ref DateTime CreatedDate, ref bool isActive, ref int CreatedByUserID)
        {
            bool isFound = false;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString);
            string sql = "SELECT * FROM Cards WHERE CardUID = @CardUID";
            SqlCommand command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@CardUID", CardUID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    isFound = true;
                    CardID = (int)reader["CardID"];
                    Balance = (decimal)reader["Balance"];
                    CreatedDate = (DateTime)reader["CreatedDate"];
                    isActive = (bool)reader["isActive"];
                    CreatedByUserID = (int)reader["CreatedByUserID"];
                }
                reader.Close();
            }
            catch { }
            finally { connection.Close(); }

            return isFound;
        }

        public static bool DeleteCard(int CardID)
        {
            int rowsAffected = 0;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString);
            string sql = "DELETE FROM Cards WHERE CardID = @CardID";
            SqlCommand command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@CardID", CardID);

            try
            {
                connection.Open();
                rowsAffected = command.ExecuteNonQuery();
            }
            catch { }
            finally { connection.Close(); }

            return rowsAffected > 0;
        }

        public static DataTable GetAllCards()
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString);

            string sql = "SELECT * FROM vCardDetails";
            SqlCommand command = new SqlCommand(sql, connection);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    dt.Load(reader);
                }

                reader.Close();
            }
            catch (Exception ex)
            {
            }
            finally
            {
                connection.Close();
            }

            return dt;
        }

        public static bool UpdateActiveStatus(int CardID, bool isActive)
        {
            int rowsAffected = 0;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString);
            string sql = @"UPDATE Cards SET isActive = @isActive WHERE CardID = @CardID";

            SqlCommand command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@CardID", CardID);
            command.Parameters.AddWithValue("@isActive", isActive);

            try
            {
                connection.Open();
                rowsAffected = command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
            }
            finally
            {
                connection.Close();
            }

            return rowsAffected > 0;
        }
    }
}
