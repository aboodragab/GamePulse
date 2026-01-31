using GamePulse_DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamePulse_Business
{
    public class clsOffersBus
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;

        public int OfferID { get; set; }
        public string OfferName { get; set; }
        public decimal RequiredAmount { get; set; }
        public decimal CreditAmount { get; set; } 
        public bool IsActive { get; set; }

        public clsOffersBus()
        {
            this.OfferID = -1;
            this.OfferName = "";
            this.RequiredAmount = 0;
            this.CreditAmount = 0;
            this.IsActive = true;
            this.Mode = enMode.AddNew;
        }
        private clsOffersBus(int OfferID, string OfferName, decimal RequiredAmount, decimal CreditAmount, bool IsActive)
        {
            this.OfferID = OfferID;
            this.OfferName = OfferName;
            this.RequiredAmount = RequiredAmount;
            this.CreditAmount = CreditAmount;
            this.IsActive = IsActive;
            this.Mode = enMode.Update;
        }

        public static clsOffersBus Find(int OfferID)
        {
            string OfferName = "";
            decimal RequiredAmount = 0;
            decimal CreditAmount = 0;
            bool IsActive = false;

            if (clsOffersDataAcc.FindByID(OfferID, ref OfferName, ref RequiredAmount, ref CreditAmount, ref IsActive))
            {
                return new clsOffersBus(OfferID, OfferName, RequiredAmount, CreditAmount, IsActive);
            }
            return null;
        }
        private bool AddNew()
        {
            OfferID = clsOffersDataAcc.AddNewOffer(OfferName, RequiredAmount, CreditAmount, IsActive);
            return OfferID != -1;
        }
        private bool Update()
        {
            return clsOffersDataAcc.UpdateOffer(OfferID, OfferName, RequiredAmount, CreditAmount, IsActive);
        }
        public static bool Delete(int OfferID)
        {
            return clsOffersDataAcc.DeleteOffer(OfferID);
        }
        public static DataTable GetAllOffer()
        {
            return clsOffersDataAcc.GetAllOffers();
        }
        public bool Save()
        {
            switch(Mode)
            {
                case enMode.AddNew:
                    {
                        if (AddNew())
                        {
                            Mode = enMode.Update;
                            return true;
                        }
                        else
                            return false;
                    }
                case enMode.Update:
                    return Update();
            }
            return false;
        }
        public static bool Active(int OfferID)
        {
            return clsOffersDataAcc.UpdateOfferStatus(OfferID, true);
        }
        public static bool Block(int OfferID)
        {
            return clsOffersDataAcc.UpdateOfferStatus(OfferID, false);
        }

    }

}

