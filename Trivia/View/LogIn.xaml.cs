using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.Data.SqlTypes;
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
    /// Interaction logic for LogIn.xaml
    /// </summary>
    public partial class LogIn : Page
    {
        public LogIn()
        {
            InitializeComponent();
        }

        private void UsrTxtBox_GotFocus(object sender, RoutedEventArgs e)
        {
            // Clear the text when the TextBox gets focus
            UsrTxtBox.Text = "";
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // the login button
            try
            {
                // Get the entered email and password
                string enteredEmail = UsrTxtBox.Text;
                string enteredPassword = PwdBox.Password;

                // Updated connection string with your database path
                string connectionString = @"Data Source=C:\Users\OZ\OneDrive\מסמכים\C# 2022\repose\Trivia\Trivia\DataBase.db;Version=3;";
            
                bool userFound = false; // Flag to indicate if user was found
                bool adminFound = false; // Flag admin

                using (var connection = new System.Data.SQLite.SQLiteConnection(connectionString))
                {
                    connection.Open();

                    // serch admin
                    string sql = "SELECT * FROM Users WHERE Email = @Email AND Password = @Password AND IsAdmin = 1 LIMIT 1";
                    using (var command = new System.Data.SQLite.SQLiteCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@Email", enteredEmail);
                        command.Parameters.AddWithValue("@Password", enteredPassword);

                        using (var reader = command.ExecuteReader())
                        {
                            if (reader.Read()) // If a user is found
                            {
                                adminFound = true; // Set the flag to true
                            }
                        }
                    }


                    // SQL command to search for user
                    sql = "SELECT * FROM Users WHERE Email = @Email AND Password = @Password LIMIT 1";
                    using (var command = new System.Data.SQLite.SQLiteCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@Email", enteredEmail);
                        command.Parameters.AddWithValue("@Password", enteredPassword);

                        using (var reader = command.ExecuteReader())
                        {
                            if (reader.Read()) // If a user is found
                            {
                                userFound = true; // Set the flag to true
                                
                            }
                        }
                    }

                    
                }

                // Check if a match was found and load the main page
                if(adminFound)
                {
                    NavigationService.Navigate(new AdminPage());
                    Application.Current.Windows[0].Height = 700;
                    Application.Current.Windows[0].Width = 1600;
                }
                else if (userFound)
                {
                    // User found, navigate to the MainPage
                    MainPage mainPage = new MainPage();
                    NavigationService.Navigate(mainPage);
                    Application.Current.Windows[0].Height = 600;
                    Application.Current.Windows[0].Width = 700;
                }
                else
                {
                    // No match found, display an error message
                    MessageBox.Show("Invalid email or password. Please try again." + enteredEmail);
                }

                



            }
            catch (Exception ex)
            {
                // Handle any exceptions that may occur
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
        }

        private void Register_Click(object sender, RoutedEventArgs e)
        {
            Register register = new Register(this);
            NavigationService.Navigate(register);
        }
    }
}
