using GamePulse_DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamePulse_Business
{
    public class clsRolesBus
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;

        public int RoleID { get; set; }
        public string RoleName { get; set; }

        public clsRolesBus()
        {
            this.RoleID = -1;
            this.RoleName = "";
            Mode = enMode.AddNew;
        }
        private clsRolesBus(int RoleID, string RoleName)
        {
            this.RoleID = RoleID;
            this.RoleName = RoleName;
            Mode = enMode.Update;
        }
        public static clsRolesBus Find(int id)
        {
            string RoleName = "";
            if(clsRolesDataAcc.FindByID(id,ref  RoleName))
            {
                return new clsRolesBus(id,RoleName);
            }
            return null;
        }
        public static DataTable GetAllRole()
        {
            return clsRolesDataAcc.GetAllRoles();
        }
    }
}
