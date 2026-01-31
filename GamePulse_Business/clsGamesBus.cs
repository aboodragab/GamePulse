using GamePulse_DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamePulse_Business
{
    public class clsGamesBus
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;
        public int GameID { get; set; }
        public string GameName { get; set; }
        public decimal DefaultPrice { get; set; }
        public bool IsActive { get; set; }
        public int GameTypeID { get; set; }
        public clsGameTypesBus GameTypeInfo { get; set; }
        public clsGamesBus()
        {
            this.GameID = -1;
            this.GameName = "";
            this.DefaultPrice = 0;
            this.IsActive = true;
            this.GameTypeID = -1;
            this.GameTypeInfo = null; 
            this.Mode = enMode.AddNew;
        }
        private clsGamesBus(int GameID, string GameName, decimal DefaultPrice, bool IsActive, int GameTypeID)
        {
            this.GameID = GameID;
            this.GameName = GameName;
            this.DefaultPrice = DefaultPrice;
            this.IsActive = IsActive;
            this.GameTypeID = GameTypeID;
            this.GameTypeInfo = clsGameTypesBus.Find(GameTypeID);
            this.Mode = enMode.Update;
        }
        public static clsGamesBus Find(int GameID)
        {
            string GameName = "";
            decimal DefaultPrice = 0;
            bool IsActive = false;
            int GameTypeID = -1;
            if (clsGamesDataAcc.FindByID(GameID, ref GameName, ref DefaultPrice, ref IsActive, ref GameTypeID))
            {
                return new clsGamesBus(GameID, GameName, DefaultPrice, IsActive, GameTypeID);
            }
            return null;
        }
        private bool AddNew()
        {
            GameID = clsGamesDataAcc.AddNewGame(GameName, DefaultPrice, IsActive, GameTypeID);
            return GameID!=-1;
        }
        private bool Update()
        {
            return clsGamesDataAcc.UpdateGame(GameID,GameName,DefaultPrice, IsActive, GameTypeID);
        }
        public static bool Delete(int GameID)
        {
            return clsGamesDataAcc.DeleteGame(GameID);
        }
        public static DataTable GetAllGame()
        {
            return clsGamesDataAcc.GetAllGames();
        }
        public bool Save()
        {
            switch(Mode)
            {
                case enMode.AddNew:
                    if(AddNew())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    else
                        return false;
                case enMode.Update:
                    return Update();
            }
            return false;
        }
        public static bool ActiveGame(int GameID)
        {
            return clsGamesDataAcc.UpdateGameStatus(GameID, true);
        }
        public static bool BlockGame(int GameID)
        {
            return clsGamesDataAcc.UpdateGameStatus(GameID, false);
        }

    }
}
