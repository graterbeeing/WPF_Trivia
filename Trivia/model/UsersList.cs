using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trivia.model
{ //UsersList
    using System.Collections.Generic;
    using System.Data.SQLite;
    using System.Xml.Linq;

    public class UsersList
    {
        private string connectionString = @"Data Source=C:\Users\OZ\OneDrive\מסמכים\C# 2022\repose\Trivia\Trivia\DataBase.db;Version=3;";

        public List<User> GetEmployees()
        {
            List<User> employees = new List<User>();

            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                string sql = "SELECT * FROM Users";
                using (SQLiteCommand command = new SQLiteCommand(sql, connection))
                {
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            employees.Add(new User(Convert.ToInt32(reader["Id"]), reader["Name"].ToString(), reader["Email"].ToString(), reader["Password"].ToString(), Convert.ToInt32(reader["IsAdmin"])));
                        }
                    }
                }
            }

            return employees;
        }
    }

}
