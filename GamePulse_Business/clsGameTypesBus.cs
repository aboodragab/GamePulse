using GamePulse_DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamePulse_Business
{
    public class clsGameTypesBus
    {
        public int GameTypeID { get; set; }
        public string GameTypeName { get; set; }

        private clsGameTypesBus(int GameTypeID, string GameTypeName)
        {
            this.GameTypeID = GameTypeID;
            this.GameTypeName = GameTypeName;
        }

        public static clsGameTypesBus Find(int GameTypeID)
        {
            string GameTypeName = "";

            if (clsGameTypesDataAcc.FindByID(GameTypeID, ref GameTypeName))
            {
                return new clsGameTypesBus(GameTypeID, GameTypeName);
            }
            return null;
        }
        public static DataTable GetAllGameTypes()
        {
            return clsGameTypesDataAcc.GetAllGameTypes();
        }
    }
}
