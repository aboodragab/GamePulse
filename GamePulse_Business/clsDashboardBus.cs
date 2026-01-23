using GamePulse_DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamePulse_Business
{
    public class clsDashboardBus
    {
        public float TotalRevenue { get; set; }
        public int ActiveCards { get; set; }
        public int TodayPlays { get; set; }

        public static clsDashboardBus GetStats()
        {
            DataRow row = clsDashboardDataAcc.GetDashboardStatistics();
            if (row != null)
            {
                return new clsDashboardBus()
                {
                    TotalRevenue = Convert.ToSingle(row["TotalRevenue"]),
                    ActiveCards = Convert.ToInt32(row["ActiveCards"]),
                    TodayPlays = Convert.ToInt32(row["TodayPlays"])
                };
            }
            return null;
        }
        public static DataTable GetTop50()
        {
            return clsDashboardDataAcc.GetLast50();
        }
    }
}
