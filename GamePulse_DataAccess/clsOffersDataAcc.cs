using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace GamePulse_DataAccess
{
    public class clsOffersDataAcc
    {
        public static int AddNewOffer(string OfferName, decimal RequiredAmount, decimal CreditAmount, bool isActive)
        {
            int OfferID = -1;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString);
            string sql = @"INSERT INTO Offers (OfferName, RequiredAmount, CreditAmount, isActive)
                           VALUES (@OfferName, @RequiredAmount, @CreditAmount, @isActive);
                           SELECT SCOPE_IDENTITY();";

            SqlCommand command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@OfferName", OfferName);
            command.Parameters.AddWithValue("@RequiredAmount", RequiredAmount);
            command.Parameters.AddWithValue("@CreditAmount", CreditAmount);
            command.Parameters.AddWithValue("@isActive", isActive);

            try
            {
                connection.Open();
                object result = command.ExecuteScalar();
                if (result != null && int.TryParse(result.ToString(), out int insertedID))
                {
                    OfferID = insertedID;
                }
            }
            catch (Exception ex) { }
            finally { connection.Close(); }

            return OfferID;
        }

        public static bool UpdateOffer(int OfferID, string OfferName, decimal RequiredAmount, decimal CreditAmount, bool isActive)
        {
            int rowsAffected = 0;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString);
            string sql = @"UPDATE Offers SET OfferName = @OfferName, RequiredAmount = @RequiredAmount, 
                           CreditAmount = @CreditAmount, isActive = @isActive 
                           WHERE OfferID = @OfferID";

            SqlCommand command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@OfferID", OfferID);
            command.Parameters.AddWithValue("@OfferName", OfferName);
            command.Parameters.AddWithValue("@RequiredAmount", RequiredAmount);
            command.Parameters.AddWithValue("@CreditAmount", CreditAmount);
            command.Parameters.AddWithValue("@isActive", isActive);

            try
            {
                connection.Open();
                rowsAffected = command.ExecuteNonQuery();
            }
            catch (Exception ex) { }
            finally { connection.Close(); }

            return rowsAffected > 0;
        }

        public static bool FindByID(int OfferID, ref string OfferName, ref decimal RequiredAmount,
                                    ref decimal CreditAmount, ref bool isActive)
        {
            bool isFound = false;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString);
            string sql = "SELECT * FROM Offers WHERE OfferID = @OfferID";
            SqlCommand command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@OfferID", OfferID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    isFound = true;
                    OfferName = (string)reader["OfferName"];
                    RequiredAmount = (decimal)reader["RequiredAmount"];
                    CreditAmount = (decimal)reader["CreditAmount"];
                    isActive = (bool)reader["isActive"];
                }
                reader.Close();
            }
            catch (Exception ex) { }
            finally { connection.Close(); }

            return isFound;
        }
        public static DataTable GetAllOffers()
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString);
            string sql = "select * from vOfferDetails";
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
        public static bool DeleteOffer(int OfferID)
        {
            int rowsAffected = 0;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString);
            string sql = "DELETE FROM Offers WHERE OfferID = @OfferID";
            SqlCommand command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@OfferID", OfferID);

            try
            {
                connection.Open();
                rowsAffected = command.ExecuteNonQuery();
            }
            catch (Exception ex) { }
            finally { connection.Close(); }

            return rowsAffected > 0;
        }

        public static bool UpdateOfferStatus(int OfferID, bool NewStatus)
        {
            int rowsAffected = 0;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString);
            string sql = @"UPDATE Offers SET isActive = @NewStatus WHERE OfferID = @OfferID";

            SqlCommand command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@OfferID", OfferID);
            command.Parameters.AddWithValue("@NewStatus", NewStatus);

            try
            {
                connection.Open();
                rowsAffected = command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                
            }
            finally { connection.Close(); }

            return rowsAffected > 0;
        }
    }
}