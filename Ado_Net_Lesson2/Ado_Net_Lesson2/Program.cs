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

            string sql = "select * from Authors where lastname = @p1";
            SqlCommand command = new SqlCommand();
            command.CommandText = sql;
            command.Connection = conn;
            SqlParameter param1 = new SqlParameter();
            //param1.ParameterName = "@p1";
            //param1.SqlDbType = SqlDbType.VarChar;
            //param1.Value = "Messi";
            //command.Parameters.Add(param1);

            //or

            command.Parameters.Add("@p1", SqlDbType.VarChar).Value = "Messi";

            //or

            //command.Parameters.AddWithValue("@p1", "Messi");


            conn.Open();
            SqlDataReader reader = command.ExecuteReader();
            do
            {
                while (reader.Read())
                {
                    if (line == 0)
                    {
                        for (int i = 0; i < reader.FieldCount; i++)
                        {
                            Console.Write(reader.GetName(i) + " ");
                        }
                        Console.WriteLine();

                    }

                    line++;
                    Console.WriteLine(reader[0] + "\t" + reader[1] + "\t" + reader[2] + "\t");
                }

            } while (reader.NextResult());
           

            Console.ReadKey();
        }
    }
}
