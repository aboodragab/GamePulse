using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace GamePulse_DataAccess
{
    public class clsGamesDataAcc
    {
        public static bool FindByID(int GameID, ref string GameName, ref decimal DefaultPrice,
                                    ref bool isActive, ref int GameTypeID)
        {
            bool isFound = false;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString);
            string sql = "SELECT * FROM Games WHERE GameID = @GameID";
            SqlCommand command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@GameID", GameID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    isFound = true;
                    GameName = (string)reader["GameName"];
                    DefaultPrice = (decimal)reader["DefaultPrice"];
                    isActive = (bool)reader["isActive"];
                    GameTypeID = (int)reader["GameTypeID"];
                }
                reader.Close();
            }
            catch (Exception ex) { }
            finally { connection.Close(); }

            return isFound;
        }
        public static int AddNewGame(string GameName, decimal DefaultPrice, bool isActive, int GameTypeID)
        {
            int GameID = -1;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString);
            string sql = @"INSERT INTO Games (GameName, DefaultPrice, isActive, GameTypeID)
                           VALUES (@GameName, @DefaultPrice, @isActive, @GameTypeID);
                           SELECT SCOPE_IDENTITY();";

            SqlCommand command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@GameName", GameName);
            command.Parameters.AddWithValue("@DefaultPrice", DefaultPrice);
            command.Parameters.AddWithValue("@isActive", isActive);
            command.Parameters.AddWithValue("@GameTypeID", GameTypeID);

            try
            {
                connection.Open();
                object result = command.ExecuteScalar();
                if (result != null && int.TryParse(result.ToString(), out int insertedID))
                {
                    GameID = insertedID;
                }
            }
            catch (Exception ex) { }
            finally { connection.Close(); }

            return GameID;
        }

        public static bool UpdateGame(int GameID, string GameName, decimal DefaultPrice, bool isActive, int GameTypeID)
        {
            int rowsAffected = 0;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString);
            string sql = @"UPDATE Games SET GameName = @GameName, DefaultPrice = @DefaultPrice, 
                           isActive = @isActive, GameTypeID = @GameTypeID 
                           WHERE GameID = @GameID";

            SqlCommand command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@GameID", GameID);
            command.Parameters.AddWithValue("@GameName", GameName);
            command.Parameters.AddWithValue("@DefaultPrice", DefaultPrice);
            command.Parameters.AddWithValue("@isActive", isActive);
            command.Parameters.AddWithValue("@GameTypeID", GameTypeID);

            try
            {
                connection.Open();
                rowsAffected = command.ExecuteNonQuery();
            }
            catch (Exception ex) { }
            finally { connection.Close(); }

            return rowsAffected > 0;
        }

        public static bool DeleteGame(int GameID)
        {
            int rowsAffected = 0;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString);
            string sql = "DELETE FROM Games WHERE GameID = @GameID";
            SqlCommand command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@GameID", GameID);

            try
            {
                connection.Open();
                rowsAffected = command.ExecuteNonQuery();
            }
            catch (Exception ex) { }
            finally { connection.Close(); }

            return rowsAffected > 0;
        }

        public static DataTable GetAllGames()
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString);
            string sql = "SELECT * FROM vGamesDetails";
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
    }
}