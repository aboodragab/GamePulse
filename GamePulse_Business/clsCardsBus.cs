using GamePulse_DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamePulse_Business
{
    public class clsCardsBus
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;

        public int CardID { get; set; }
        public string CardUID { get; set; }
        public decimal Balance { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool IsActive { get; set; }
        public int CreatedByUserID { get; set; }
        public clsUsersBus CreatedByUserInfo { get; set; }

        public clsCardsBus()
        {
            this.CardID = -1;
            this.CardUID = "";
            this.Balance = 0;
            this.CreatedDate = DateTime.Now;
            this.IsActive = true;
            this.CreatedByUserID = -1;
            this.CreatedByUserInfo = null; 
            this.Mode = enMode.AddNew;
        }
        private clsCardsBus(int CardID, string CardUID, decimal Balance,
                        DateTime CreatedDate, bool IsActive, int CreatedByUserID)
        {
            this.CardID = CardID;
            this.CardUID = CardUID;
            this.Balance = Balance;
            this.CreatedDate = CreatedDate;
            this.IsActive = IsActive;
            this.CreatedByUserID = CreatedByUserID;
            this.CreatedByUserInfo = clsUsersBus.FindByID(CreatedByUserID);
            this.Mode = enMode.Update;
        }
        private bool AddCard()
        {
            CardID = clsCardsDataAcc.AddNewCard(CardUID, Balance, CreatedByUserID);
            return (CardID!=-1);
        }
        private bool UpdateCard()
        {
            return clsCardsDataAcc.UpdateCard(CardID, CardUID, IsActive);
        }
        public static bool DeleteCard(int CardID)
        {
            return clsCardsDataAcc.DeleteCard(CardID);
        }
        public bool Recharge(decimal Amount)
        {
            if (Amount <= 0) return false;

            this.Balance += Amount;
            return clsCardsDataAcc.RechargeBalance(this.CardID, this.Balance);
        }
        public bool Withdraw(decimal Amount)
        {
            if(Amount <= 0 || Amount > this.Balance) 
                return false;

            this.Balance -= Amount;
            return clsCardsDataAcc.WithdrawBalance(this.CardID, this.Balance);
        }
        public static clsCardsBus FindByID(int CardID)
        {
            string CardUID = ""; decimal Balance = 0;
            DateTime CreatedDate = DateTime.Now; bool IsActive = false; int CreatedByUserID = -1;

            if (clsCardsDataAcc.FindByID(CardID, ref CardUID, ref Balance, ref CreatedDate, ref IsActive, ref CreatedByUserID))
                return new clsCardsBus(CardID, CardUID, Balance, CreatedDate, IsActive, CreatedByUserID);
            else
                return null;
        }
        public static clsCardsBus FindByUID(string CardUID)
        {
            int CardID = -1; decimal Balance = 0;
            DateTime CreatedDate = DateTime.Now; bool IsActive = false; int CreatedByUserID = -1;

            if (clsCardsDataAcc.FindByUID(CardUID, ref CardID, ref Balance, ref CreatedDate, ref IsActive, ref CreatedByUserID))
                return new clsCardsBus(CardID, CardUID, Balance, CreatedDate, IsActive, CreatedByUserID);
            else
                return null;
        }
        public bool Save()
        {
            switch(Mode)
            {
                case enMode.AddNew:
                    if(AddCard())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false; 
                    }

                    case enMode.Update:
                    return UpdateCard();
            }   
            return false;
        }
        public static DataTable GetAllCard()
        {
            return clsCardsDataAcc.GetAllCards(); 
        }

    }
}
