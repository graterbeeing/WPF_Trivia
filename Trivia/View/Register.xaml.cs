using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Trivia.View
{
    /// <summary>
    /// Interaction logic for Register.xaml
    /// </summary>
    public partial class Register : Page
    {
        LogIn logIn = new LogIn();

        public Register(LogIn logIn)
        {
            InitializeComponent();
            this.logIn = logIn;
        }

        public void NameOnfoucus(object sender, EventArgs e)
        {
            Name.Text = "";
        }

        private void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            Password.Text = "";
        }

        private void TextBox_GotFocus_1(object sender, RoutedEventArgs e)
        {
            Email.Text = "";
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (!AreAllValuesFilled())
            {
                MessageBox.Show("Please fill all the fields & make sure passwords are equal");
                return;
            }
            else
            {
                // Write to users table with the data
                string email = Email.Text;
                string name = Name.Text;
                string password = Password.Text;

                // TODO: Write code to insert the data into the users table
                string connectionString = @"Data Source=C:\Users\OZ\OneDrive\מסמכים\C# 2022\repose\Trivia\Trivia\DataBase.db;Version=3;";

                using (SQLiteConnection connection = new SQLiteConnection(connectionString))
                {
                    connection.Open();
                    string query = "INSERT INTO Users (Name, Password, Email, IsAdmin) VALUES (@name , @password, @email, 0)";
                    using (SQLiteCommand command = new SQLiteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@email", email);
                        command.Parameters.AddWithValue("@name", name);
                        command.Parameters.AddWithValue("@password",password);
                        command.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("User registered successfully!");
                NavigationService.Navigate(logIn);
            }
        }

        public bool AreAllValuesFilled()
        {
            if (string.IsNullOrEmpty(Name.Text) || string.IsNullOrEmpty(Password.Text) || string.IsNullOrEmpty(Email.Text))
            {
                return false;
            }
            return true;
        }

    }
}
