using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testDb
{
    public class Program
    {
       
        
        static void Main(string[] args)
        {
           DOconnection();

            while (true)
            {
                Console.WriteLine("--------------------------");
                Console.WriteLine("1. Create");
                Console.WriteLine("2. Show");
                Console.WriteLine("3. edit");
                Console.WriteLine("4. delete");
                Console.WriteLine("-------------pilih nomor : -------------");


                int numb = Convert.ToInt32(Console.ReadLine());

                if (numb == 1)
                {
                    DoCreate();
                }
                else if (numb == 2)
                {
                    DoShow();
                }
                else if (numb == 3)
                {
                    DoUpdate();
                }
                else if (numb == 4)
                {
                    DoDelete();
                }
                else
                {
                    Console.WriteLine("Not found");
                }
              
                Console.ReadLine();
            }

          
        }


        public static void DOconnection()
        {
            var connection = new MySqlConnection("Server=localhost;Database=testcsharpdb;Uid=root;Pwd=;");
            connection.Open();
            if (connection.State == System.Data.ConnectionState.Open)
            {
                Console.WriteLine("Connection is opened");
            }

            connection.Close();
            Console.ReadLine();
           

        }

        public static void DoCreate()
        {

            var connection = new MySqlConnection("Server=localhost;Database=testcsharpdb;Uid=root;Pwd=;");
            connection.Open();

            Console.WriteLine("-- nama --");
            string namaku = Console.ReadLine();
            Console.WriteLine("-- nickname --");
            string nickname = Console.ReadLine();
            Console.WriteLine("-- email --");
            string emails = Console.ReadLine();

            var command = new MySqlCommand("INSERT INTO employe(name, username, email) values(@NAME, @USERNAME, @EMAIL)", connection);
            MySqlParameter paramName = new MySqlParameter();
            paramName.ParameterName = "@NAME";
            paramName.Value = namaku;
            MySqlParameter paramUsername = new MySqlParameter();
            paramUsername.ParameterName = "@USERNAME";
            paramUsername.Value = nickname;
            MySqlParameter paramEmail = new MySqlParameter();
            paramEmail.ParameterName = "@EMAIL";
            paramEmail.Value = emails;
            command.Parameters.Add(paramName);
            command.Parameters.Add(paramUsername);
            command.Parameters.Add(paramEmail);
            int count = command.ExecuteNonQuery();
            if (count > 0)
            {
                Console.WriteLine("{0} row/rows affected", count);
            }
            connection.Close();
            Console.ReadLine();
        }

        public static void DoShow()
        {
            var connection = new MySqlConnection("Server=localhost;Database=testcsharpdb;Uid=root;Pwd=;");
            connection.Open();

            var command = new MySqlCommand("SELECT * FROM employe", connection);
            var reader = command.ExecuteReader();
            while (reader.Read())
            {
               Console.WriteLine("Id:{0} Name:{1} Username:{2} Email:{3}",
               reader["id"], reader["name"], reader["username"], reader["email"]);
            }
           
        }

        public static void DoUpdate()
        {
            var connection = new MySqlConnection("Server=localhost;Database=testcsharpdb;Uid=root;Pwd=;");
            connection.Open();

            Console.WriteLine("Update data by");
            Console.WriteLine("-- nama --");
            string namaku = Console.ReadLine();
            Console.WriteLine("--ubah email ke--");
            string emails = Console.ReadLine();

            var command = new MySqlCommand("UPDATE employe SET email=@NEWEMAIL WHERE name = @NAME", connection);
            MySqlParameter paramName = new MySqlParameter();
            paramName.ParameterName = "@NAME";
            paramName.Value = namaku;
            MySqlParameter paramEmail = new MySqlParameter();
            paramEmail.ParameterName = "@NEWEMAIL";
            paramEmail.Value = emails;
            command.Parameters.Add(paramName);
            command.Parameters.Add(paramEmail);
            int count = command.ExecuteNonQuery();
            if (count > 0)
            {
                Console.WriteLine("{0} row/rows affected", count);
            }
            connection.Close();
            Console.ReadLine();
        }

        public static void DoDelete()
        {
            var connection = new MySqlConnection("Server=localhost;Database=testcsharpdb;Uid=root;Pwd=;");
            connection.Open();
            Console.WriteLine("hapus data");
            Console.WriteLine("-- nickname --");
            string nickname = Console.ReadLine();
           
            var command = new MySqlCommand("DELETE FROM employe WHERE username = @USERNAME", connection);
            MySqlParameter paramName = new MySqlParameter();
            paramName.ParameterName = "@USERNAME";
            paramName.Value = nickname ;
            command.Parameters.Add(paramName);
            int count = command.ExecuteNonQuery();
            if (count > 0)
            {
                Console.WriteLine("{0} row/rows affected", count);
            }
            connection.Close();
            Console.ReadLine();
        }

    }
}
