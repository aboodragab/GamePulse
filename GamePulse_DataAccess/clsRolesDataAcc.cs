using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamePulse_DataAccess
{
    public class clsRolesDataAcc
    {
        public static DataTable GetAllRoles()
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString);
            string sql = "SELECT * FROM Roles";
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
        public static bool FindByID(int RoleID, ref string RoleName)
        {
            bool isFound = false;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString);
            string sql = "SELECT * FROM Roles WHERE RoleID = @RoleID";
            SqlCommand command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@RoleID", RoleID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    isFound = true;
                    RoleName = (string)reader["RoleName"];
                }
                reader.Close();
            }
            catch (Exception ex) { }
            finally { connection.Close(); }

            return isFound;
        }
    }
}
