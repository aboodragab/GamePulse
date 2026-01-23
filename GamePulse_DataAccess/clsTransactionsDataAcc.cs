using System;
using System.Data;
using System.Data.SqlClient;

namespace GamePulse_DataAccess
{
    public class clsTransactionsDataAcc
    {
        private static int _AddNewTransaction(decimal ActualAmount, decimal BalanceAmount, object GamePrice,
                                             object GameID, int CardID, int CreatedByUserID,
                                             object OfferID, int TransactionTypeID)
        {
            int TransactionID = -1;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString);
            string sql = @"INSERT INTO Transactions (ActualAmount, BalanceAmount, GamePrice, GameID, 
                                                    CardID, CreatedByUserID, OfferID, TransactionTypeID)
                           VALUES (@ActualAmount, @BalanceAmount, @GamePrice, @GameID, 
                                   @CardID, @CreatedByUserID, @OfferID, @TransactionTypeID);
                           SELECT SCOPE_IDENTITY();";

            SqlCommand command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@ActualAmount", ActualAmount);
            command.Parameters.AddWithValue("@BalanceAmount", BalanceAmount);
            command.Parameters.AddWithValue("@GamePrice", GamePrice ?? DBNull.Value);
            command.Parameters.AddWithValue("@GameID", GameID ?? DBNull.Value);
            command.Parameters.AddWithValue("@CardID", CardID);
            command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
            command.Parameters.AddWithValue("@OfferID", OfferID ?? DBNull.Value);
            command.Parameters.AddWithValue("@TransactionTypeID", TransactionTypeID);

            try
            {
                connection.Open();
                object result = command.ExecuteScalar();
                if (result != null && int.TryParse(result.ToString(), out int insertedID))
                    TransactionID = insertedID;
            }
            catch { }
            finally { connection.Close(); }

            return TransactionID;
        }
        public static int AddRechargeTransaction(decimal ActualAmount, decimal BalanceAmount, int CardID,
                                                 int CreatedByUserID, object OfferID, int TransactionTypeID)
        {
            return _AddNewTransaction(ActualAmount, BalanceAmount, null, null, CardID, CreatedByUserID, OfferID, TransactionTypeID);
        }
        public static int AddPlayTransaction(decimal BalanceAmount, decimal GamePrice, int GameID, int CardID,
                                             int CreatedByUserID, int TransactionTypeID)
        {
            return _AddNewTransaction(0, BalanceAmount, GamePrice, GameID, CardID, CreatedByUserID, null, TransactionTypeID);
        }
        public static int AddRefundTransaction(decimal ActualAmount, decimal BalanceAmount, int CardID,
                                        int CreatedByUserID, int TransactionTypeID)
        {
            return _AddNewTransaction(ActualAmount, BalanceAmount, null, null, CardID, CreatedByUserID, null, TransactionTypeID);
        }
        public static DataTable GetAllTransactionsList()
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString);
            string sql = "SELECT * FROM vTransactionHistory ORDER BY TransactionDate DESC";
            SqlCommand command = new SqlCommand(sql, connection);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows) dt.Load(reader);
                reader.Close();
            }
            catch(Exception ex) { }
            finally { connection.Close(); }

            return dt;
        }
        public static DataTable GetSalesInventoryReport(DateTime FromDate, DateTime ToDate)
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString);
            string sql = @"SELECT * FROM vTransactionsDetails 
                           WHERE TransactionDate BETWEEN @FromDate AND @ToDate
                           ORDER BY TransactionDate DESC";

            SqlCommand command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@FromDate", FromDate);
            command.Parameters.AddWithValue("@ToDate", ToDate);

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
    }
}