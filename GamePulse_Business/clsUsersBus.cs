using GamePulse_DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamePulse_Business
{
    public class clsUsersBus
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;
        public enum enRoles { Admin = 1, Cashier = 2 };
        public enRoles Roles = enRoles.Admin;
        public int UserID { get; set; }
        public string FullName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool IsActive { get; set; }
        public byte RoleID { get; set; }
        public clsRolesBus RoleInfo { get; set; }

        public clsUsersBus()
        {
            this.UserID = -1;
            this.UserName = "";
            this.FullName = "";
            this.Password = "";
            this.IsActive = true;
            this.RoleID = 0;
            this.RoleInfo = new clsRolesBus(); 
            this.Mode = enMode.AddNew;
        }
        private clsUsersBus(int UserID,string FullName, string UserName, string Password, bool IsActive, byte RoleID)
        {
            this.UserID = UserID;
            this.FullName= FullName;
            this.UserName = UserName;
            this.Password = Password;
            this.IsActive = IsActive;
            this.RoleID = RoleID;
            this.RoleInfo = clsRolesBus.Find(RoleID);
            this.Mode = enMode.Update;
        }
       
        public static clsUsersBus FindByID(int ID)
        {
            string name = "";
            string  user= "";
            string pass = "";
            bool isActive= false;
            byte RoleID = 0;

            if(clsUsersDataAcc.FindByUserID(ID,ref name,ref user,ref pass,ref isActive,ref RoleID))
            {
                return new clsUsersBus(ID,name,user,pass,isActive,RoleID);
            }
            return null;
        }

        public static clsUsersBus FindByUserName(string UserName)
        {
            int id = 0;
            string name = "";
            string pass = "";
            bool isActive = false;
            byte RoleID = 0;

            if(clsUsersDataAcc.FindByUserName(UserName,ref id,ref name,ref pass,ref isActive,ref RoleID))
            {
                return new clsUsersBus(id,name,UserName,pass,isActive,RoleID);
            }
            return null;
        }

        public static clsUsersBus FindByUserNameAndPassword(string Username,string password)
        {
            int id = 0;
            string name = "";
            bool isActive = false;
            byte RoleID = 0;

            if (clsUsersDataAcc.FindByUserAndPassword(Username, password, ref id, ref name, ref isActive, ref RoleID))
                return new clsUsersBus(id, name, Username, password, isActive, RoleID);
            else
                return null;
        }

        private bool AddUser()
        {
            UserID=clsUsersDataAcc.AddUser(FullName,UserName,Password,IsActive,RoleID);

            return (UserID!=-1);
        }

        private bool UpdateUser()
        {
            return clsUsersDataAcc.UpdateUser(UserID, FullName, UserName, Password, IsActive, RoleID);
        }

        public static bool DeleteUser(int UserID)
        {
            return clsUsersDataAcc.DeleteUser(UserID);
        }

        public static bool ChangePassword(int  UserID,string Password)
        {
            return(clsUsersDataAcc.ChangePassword(UserID,Password));
        }

        public static bool DeactivateUser(int UserID)
        {
            return clsUsersDataAcc.DeactivateUser(UserID);
        }

        public static DataTable GetAllUser()
        {
            return clsUsersDataAcc.GetAllUsers();
        }

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (AddUser())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                case enMode.Update:
                    
                    return UpdateUser();  
            }
            return false;
        }
    }
}
