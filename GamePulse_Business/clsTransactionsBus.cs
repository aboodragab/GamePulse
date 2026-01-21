using GamePulse_DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamePulse_Business
{
    public class clsTransactionsBus
    {
        public int TransactionID { get; set; }
        public decimal ActualAmount { get; set; } 
        public DateTime? TransactionDate { get; set; }
        public decimal BalanceAmount { get; set; } 
        public decimal? GamePrice { get; set; } 
        public int? GameID { get; set; }
        public int CardID { get; set; }
        public int CreatedByUserID { get; set; }
        public int? OfferID { get; set; }
        public int TransactionTypeID { get; set; }


        public clsCardsBus CardInfo { get; set; }
        public clsUsersBus UserInfo { get; set; }
        public clsTransactionTypesBus TypeInfo { get; set; }
        public clsGamesBus GameInfo { get; set; } 
        public clsOffersBus OfferInfo { get; set; }

        private clsTransactionsBus(int TransactionID, decimal ActualAmount, DateTime? TransactionDate,
                                 decimal BalanceAmount, decimal? GamePrice, int? GameID,
                                 int CardID, int CreatedByUserID, int? OfferID, int TransactionTypeID)
        {
            this.TransactionID = TransactionID;
            this.ActualAmount = ActualAmount;
            this.TransactionDate = TransactionDate;
            this.BalanceAmount = BalanceAmount;
            this.GamePrice = GamePrice;
            this.GameID = GameID;
            this.CardID = CardID;
            this.CreatedByUserID = CreatedByUserID;
            this.OfferID = OfferID;
            this.TransactionTypeID = TransactionTypeID;

            this.CardInfo = clsCardsBus.FindByID(CardID);
            this.UserInfo = clsUsersBus.FindByID(CreatedByUserID);
            this.TypeInfo = clsTransactionTypesBus.Find(TransactionTypeID);

            this.GameInfo = (GameID != null) ? clsGamesBus.Find((int)GameID) : null;
            this.OfferInfo = (OfferID != null) ? clsOffersBus.Find((int)OfferID) : null;
        }

        public static bool RechargeCard(int CardID, decimal Amount, int UserID, object OfferID)
        {
            clsCardsBus Card = clsCardsBus.FindByID(CardID);
            if (Card == null || !Card.IsActive) return false;

            decimal NewBalance = Card.Balance + Amount;

            int TransactionID = clsTransactionsDataAcc.AddRechargeTransaction(Amount, NewBalance, CardID, UserID, OfferID, 1);

            if (TransactionID != -1)
            {
                Card.Balance = NewBalance;
                return true;
            }
            return false;
        }
        public static bool PlayCard(int CardID, decimal Amount, int UserID, int GameID)
        {
            clsCardsBus Card = clsCardsBus.FindByID(CardID);
            if (Card == null || !Card.IsActive) return false;

            if (Card.Balance < Amount)
            {
                return false;
            }
            
            decimal NewBalance = Card.Balance - Amount;

            int TransactionID = clsTransactionsDataAcc.AddPlayTransaction(
                NewBalance,
                Amount,     
                GameID,
                CardID,
                UserID,2);

            if (TransactionID != -1)
            {
                Card.Balance = NewBalance;
                return true;
            }
            return false;
        }
        public static bool AddRefund(int CardID, decimal RefundAmount, int UserID)
        {
            if (RefundAmount <= 0 || CardID <= 0) return false;
            clsCardsBus Card = clsCardsBus.FindByID(CardID);

            if (Card == null || !Card.IsActive) return false;
            decimal NewBalance = Card.Balance + RefundAmount;
            
            int TransactionID = clsTransactionsDataAcc.AddRefundTransaction(
                RefundAmount,
                NewBalance,
                CardID,
                UserID,
                3 
            );
            if (TransactionID != -1)
            {
                Card.Balance = NewBalance;
                return true;
            }
            return false;
        }
        public static bool CashOut(int CardID, decimal Amount, int UserID)
        {
            clsCardsBus Card = clsCardsBus.FindByID(CardID);
            if (Card == null || Card.Balance < Amount) return false;

            decimal NewBalance = Card.Balance - Amount; 

            
            int TransactionID = clsTransactionsDataAcc.AddRefundTransaction(
                Amount, NewBalance, CardID, UserID, 4); 
            if (TransactionID != -1)
            {
                Card.Balance = NewBalance;
                return true;
            }
            return false;
        }
        public static DataTable GetAllTransactions()
        {
            return clsTransactionsDataAcc.GetAllTransactionsList();
        }
        public static DataTable GetSalesInventory(DateTime FromDate, DateTime ToDate)
        {
            return clsTransactionsDataAcc.GetSalesInventoryReport(FromDate,ToDate);
        }
    }
}
