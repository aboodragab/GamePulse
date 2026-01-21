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
        public enum enTransactionType
        {
            Recharge = 1,
            Play = 2,
            Refund = 3,
            CashOut = 4
        }
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

        private clsTransactionsBus(
            int transactionID,
            decimal actualAmount,
            DateTime? transactionDate,
            decimal balanceAmount,
            decimal? gamePrice,
            int? gameID,
            int cardID,
            int createdByUserID,
            int? offerID,
            int transactionTypeID)
        {
            TransactionID = transactionID;
            ActualAmount = actualAmount;
            TransactionDate = transactionDate;
            BalanceAmount = balanceAmount;
            GamePrice = gamePrice;
            GameID = gameID;
            CardID = cardID;
            CreatedByUserID = createdByUserID;
            OfferID = offerID;
            TransactionTypeID = transactionTypeID;

            CardInfo = clsCardsBus.FindByID(cardID);
            UserInfo = clsUsersBus.FindByID(createdByUserID);
            TypeInfo = clsTransactionTypesBus.Find(transactionTypeID);
            GameInfo = gameID.HasValue ? clsGamesBus.Find(gameID.Value) : null;
            OfferInfo = offerID.HasValue ? clsOffersBus.Find(offerID.Value) : null;
        }


        private static bool UpdateCardBalance(clsCardsBus card, decimal newBalance)
        {
            card.Balance = newBalance;
            return card.Save();
        }
        public static bool RechargeCard(int CardID, decimal Amount, int UserID, int? OfferID)
        {
            if (Amount <= 0) return false;

            clsCardsBus Card = clsCardsBus.FindByID(CardID);
            
            if (Card == null || !Card.IsActive) return false;

            decimal TotalToBenefit = Amount;

            if (OfferID.HasValue)
            {
                clsOffersBus offer = clsOffersBus.Find(OfferID.Value);

                if (offer != null && offer.IsActive)
                {
                    TotalToBenefit = Amount + offer.CreditAmount;
                }
            }

            decimal NewBalance = Card.Balance + TotalToBenefit;
            int TransactionID = clsTransactionsDataAcc.AddRechargeTransaction(Amount, NewBalance, CardID, UserID, OfferID,(int)enTransactionType.Recharge);

            if (TransactionID == -1)
            {
               return false;
            }

            return UpdateCardBalance(Card, NewBalance);
            
        }
        public static bool PlayCard(int CardID, decimal Amount, int UserID, int GameID)
        {
            if (Amount <= 0) return false;
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
                UserID,
                (int)enTransactionType.Play);

            if (TransactionID == -1)
            {
                return false;
            }

            return UpdateCardBalance(Card, NewBalance);
        }
        public static bool Refund(int CardID, decimal RefundAmount, int UserID)
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
                (int)enTransactionType.Refund
            );
            if (TransactionID == -1)
            {
                return false;
            }

            return UpdateCardBalance(Card, NewBalance);
        }
        public static bool CashOut(int CardID, decimal Amount, int UserID)
        {
            if (Amount <= 0) return false;
            clsCardsBus Card = clsCardsBus.FindByID(CardID);
            if (Card == null || !Card.IsActive || Card.Balance < Amount) return false;

            decimal NewBalance = Card.Balance - Amount; 

            
            int TransactionID = clsTransactionsDataAcc.AddRefundTransaction(
                Amount, NewBalance, CardID, UserID, (int)enTransactionType.CashOut);
            if (TransactionID == -1)
            {
                return false;
            }

            return UpdateCardBalance(Card, NewBalance);
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
