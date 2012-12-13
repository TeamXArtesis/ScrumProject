using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            SqlConnection connection = new SqlConnection(@"Network Library=Timetable;Data Source=DB2-PC;Initial Catalog=Timetable;Persist Security Info=True;User ID=sa;Password=sa");

            try { 
                connection.Open();
                SqlCommand command = connection.CreateCommand();
                Console.WriteLine("Test succesfull");
                
            }
            catch (SqlException e)
            {
                Console.WriteLine("not succesfull");
            }
            finally
            {
                    connection.Close();
            }
        }
        }
    }
}
