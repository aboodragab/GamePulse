using GamePulse_DataAccess;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string connectionString = clsDataAccessSettings.connectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    Console.WriteLine("1111");
                    connection.Open();

                    // إذا وصل هنا، يعني الاتصال نجح 100%
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("111");
                    Console.WriteLine("1 " + connection.DataSource);
                    Console.WriteLine("11 " + connection.Database);
                    Console.ResetColor();
                }
                catch (Exception ex)
                {
                    // هنا سيظهر لك السبب الحقيقي لعدم ظهور البيانات
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("333");
                    Console.WriteLine("3333 " + ex.Message);
                    Console.ResetColor();
                }
            }

            Console.WriteLine("\nاضغط أي مفتاح للإغلاق...");
            Console.ReadKey();
        }
    }
}
