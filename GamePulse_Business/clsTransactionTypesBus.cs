using GamePulse_DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamePulse_Business
{
    public class clsTransactionTypesBus
    {
        public int TransactionTypeID { get; set; }
        public string TransactionTypeName { get; set; }
        public bool IsActive { get; set; }

        private clsTransactionTypesBus(int TransactionTypeID, string TransactionTypeName, bool IsActive)
        {
            this.TransactionTypeID = TransactionTypeID;
            this.TransactionTypeName = TransactionTypeName;
            this.IsActive = IsActive;
        }
        public static clsTransactionTypesBus Find(int TransactionTypeID)
        {
            string TransactionTypeName = "";
            bool IsActive = false;

            if (clsTransactionTypesDataAcc.FindByID(TransactionTypeID, ref TransactionTypeName, ref IsActive))
            {
                return new clsTransactionTypesBus(TransactionTypeID, TransactionTypeName, IsActive);
            }
            return null;
        }
        public static DataTable GetAllTransactionTypes()
        {
            return clsTransactionTypesDataAcc.GetAllTransactionTypes();
        }
        public static DataTable GetAllActiveTransactionTypes()
        {
            return clsTransactionTypesDataAcc.GetAllActiveTransactionTypes();
        }

    }
}
