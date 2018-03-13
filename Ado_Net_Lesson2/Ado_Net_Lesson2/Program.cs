using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ado_Net_Lesson2
{
    class Program
    {

        static void Main(string[] args)
        {
            int line = 0;
            SqlConnection conn = null;
            string stringConnection = ConfigurationManager.ConnectionStrings["MyConnectionStringWhithWindows"].ConnectionString;
            conn = new SqlConnection();
            conn.ConnectionString = stringConnection;

            string sql = "getBookNumber";
            SqlCommand command = new SqlCommand();
            command.CommandText = sql;
            command.Connection = conn;
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.Add("@authorid", SqlDbType.Int).Value = 1;

            SqlParameter output = new SqlParameter("@bookcount", SqlDbType.Int);
            output.Direction = ParameterDirection.Output;
            command.Parameters.Add(output);

            conn.Open();
            command.ExecuteNonQuery();
            Console.WriteLine(command.Parameters["@bookcount"].Value.ToString());
            conn.Close();
            Console.ReadKey();
        }

      
    }
}
