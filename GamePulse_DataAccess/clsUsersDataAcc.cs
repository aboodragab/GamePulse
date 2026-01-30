using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamePulse_DataAccess
{
    public class clsUsersDataAcc
    {
        public static int AddUser(string FullName,string UserName,string Password, bool IsActive
            ,byte RoleID)
        {
            int UserId = -1;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString);
            string sql = @"INSERT INTO Users (FullName, UserName, Password, isActive, RoleID) 
                VALUES (@FullName, @UserName, @Password, @isActive, @RoleID)
                SELECT SCOPE_IDENTITY();";

            SqlCommand command = new SqlCommand(sql, connection);

            command.Parameters.AddWithValue("@FullName", FullName);
            command.Parameters.AddWithValue("@UserName", UserName);
            command.Parameters.AddWithValue ("@Password", Password);
            command.Parameters.AddWithValue("@isActive", IsActive);
            command.Parameters.AddWithValue("@RoleID", RoleID);

            try
            {
                 connection.Open();

                object result = command.ExecuteScalar();
                if (result != null && int.TryParse(result.ToString(), out int insertedID))
                {
                    UserId = insertedID;
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
                connection.Close();
            }
            return UserId;
        }

        public static bool UpdateUser(int UserID,string FullName, string UserName, string Password, bool IsActive
            , byte RoleID)
        {
            int row = 0;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString);
            string sql = @"UPDATE Users SET FullName = @FullName, 
                            UserName = @UserName,Password = @Password
                            ,isActive = @isActive, RoleID = @RoleID
                            WHERE UserID = @UserID";

            SqlCommand command = new SqlCommand(sql, connection);

            command.Parameters.AddWithValue("@UserID", UserID);
            command.Parameters.AddWithValue("@FullName", FullName);
            command.Parameters.AddWithValue("@UserName", UserName);
            command.Parameters.AddWithValue("@Password", Password);
            command.Parameters.AddWithValue("@isActive", IsActive);
            command.Parameters.AddWithValue("@RoleID", RoleID);

            try
            {
                connection.Open();
                row = command.ExecuteNonQuery();
            }
            catch(Exception ex)
            {

            }
            finally
            {
                connection.Close(); 
            }
            return row > 0;
        }

        public static bool DeleteUser(int UserID)
        {
            int row = 0;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString);
            string sql = @"DELETE FROM Users WHERE UserID = @UserID";

            SqlCommand command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@UserID", UserID);

            try
            {
                connection.Open();
                row = command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

            }
            finally
            {
                connection.Close();
            }
            return row > 0;
        }

        public static bool FindByUserID(int UserID, ref string FullName, ref string UserName,
                                ref string Password, ref bool IsActive, ref byte RoleID)
        {
            bool isFound = false;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString);
            string sql = "SELECT * FROM Users WHERE UserID = @UserID";
            SqlCommand command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@UserID", UserID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    isFound = true;
                    FullName = (string)reader["FullName"];
                    UserName = (string)reader["UserName"];
                    Password = (string)reader["Password"];
                    IsActive = (bool)reader["IsActive"];
                    RoleID = Convert.ToByte(reader["RoleID"]);
                }
                reader.Close();
            }
            catch (Exception ex) { isFound = false; }
            finally { connection.Close(); }

            return isFound;
        }

        public static bool FindByUserName(string UserName, ref int UserID, ref string FullName,
                                  ref string Password, ref bool IsActive, ref byte RoleID)
        {
            bool isFound = false;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString);
            string sql = "SELECT * FROM Users WHERE UserName = @UserName";
            SqlCommand command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@UserName", UserName);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    isFound = true;
                    UserID = (int)reader["UserID"];
                    FullName = (string)reader["FullName"];
                    Password = (string)reader["Password"];
                    IsActive = (bool)reader["IsActive"];
                    RoleID = Convert.ToByte(reader["RoleID"]);
                }
                reader.Close();
            }
            catch (Exception ex) 
            { isFound = false; }
            finally { connection.Close(); }

            return isFound;
        }

        public static bool FindByUserAndPassword(string UserName,string Password ,ref int UserID, ref string FullName,
             ref bool IsActive, ref byte RoleID)
        {
            bool isFound = false;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString);
            string sql = "SELECT * FROM Users WHERE UserName=@UserName and Password=@Password";

            SqlCommand command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@UserName", UserName);
            command.Parameters.AddWithValue("@Password", Password);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    isFound = true;
                    UserID = (int)reader["UserID"];
                    FullName = (string)reader["FullName"];
                    IsActive = (bool)reader["IsActive"];
                    RoleID = Convert.ToByte(reader["RoleID"]);
                }
                reader.Close();
            }
            catch(Exception ex) 
            { 
                isFound = false;
            }
            finally{ connection.Close(); }
            return isFound;
        }

        public static bool ChangePassword(int UserID, string NewPassword)
        {
            int row = 0;
            SqlConnection connection =
                new SqlConnection(clsDataAccessSettings.connectionString);

            string sql = @"UPDATE Users SET Password = @NewPassword WHERE UserID = @UserID";
            SqlCommand command = new SqlCommand(sql, connection);

            command.Parameters.AddWithValue("@UserID", UserID);
            command.Parameters.AddWithValue("@NewPassword", NewPassword);

            try
            {
                connection.Open();
                row = command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
            }
            finally
            {
                connection.Close();
            }

            return row > 0;
        }


        public static bool DeactivateUser(int UserID)
        {
            int row = 0;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString);
            string sql = @"UPDATE Users SET isActive = 0 WHERE UserID = @UserID";
            SqlCommand command = new SqlCommand(sql, connection);

            command.Parameters.AddWithValue("@UserID", UserID);

            try
            {
                connection.Open();
                row = command.ExecuteNonQuery();
            }
            catch (Exception ex) { }
            finally
            {
                connection.Close();
            }
            return row > 0;
        }

        public static DataTable GetAllUsers()
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString);

            string sql = "SELECT * FROM vUserDetails";
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

        public static bool IsUserExist(string UserName)
        {
            bool isFound = false;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString);
            string sql = "SELECT Found=1 FROM Users WHERE UserName = @UserName";
            SqlCommand command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@UserName", UserName);

            try
            {
                connection.Open();
                object result = command.ExecuteScalar();
                if (result != null)
                {
                    isFound = true;
                }
            }
            catch (Exception ex) { isFound = false; }
            finally { connection.Close(); }

            return isFound;
        }
    }
}
