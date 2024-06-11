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
using Trivia.model;

namespace Trivia.View
{
    /// <summary>
    /// Interaction logic for AdminPage.xaml
    /// </summary>
    public partial class AdminPage : Page
    {
        private UsersList employeeDAL;

        public AdminPage()
        {
            InitializeComponent();
            employeeDAL = new UsersList();
            PopulateDataGrid();
        }

        private void PopulateDataGrid()
        {
            List<User> employees = employeeDAL.GetEmployees();
            listViewEmployees.ItemsSource = employees;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
            Application.Current.Windows[0].Height = 530;
            Application.Current.Windows[0].Width = 500;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (!AreAllValuesFilled())
            {
                MessageBox.Show("all boxes have to be filled", "");
                return;
            }
            
            int Parent = Find_Max_Parent() + 1 ;
            string Answer = answer.Text;
            string Option1 = option1.Text;
            string Option2 = option2.Text;
            string Option3 = option3.Text;
            string Question = question.Text;

            string connectionString = @"Data Source=C:\Users\OZ\OneDrive\מסמכים\C# 2022\repose\Trivia\Trivia\DataBase.db;Version=3;";
            SQLiteConnection connection = new SQLiteConnection(connectionString);
            connection.Open();

            // create question in riddles
            string query = "INSERT INTO Riddles (Question, Difficulty) VALUES (@question , 1)";
            SQLiteCommand command = new SQLiteCommand(query, connection);
            command.Parameters.AddWithValue("@question", Question);
            command.ExecuteNonQuery();

            // create answer
            query = "INSERT INTO answers (parent, son, answerText, isCorrect) VALUES (@parent , 1, @text, 1)";
            command = new SQLiteCommand(query, connection);
            command.Parameters.AddWithValue("@parent", Parent);
            command.Parameters.AddWithValue("@text", Answer);
            command.ExecuteNonQuery();

            // option 1
            query = "INSERT INTO answers (parent, son, answerText, isCorrect) VALUES (@parent , 2, @text, 0)";
            command = new SQLiteCommand(query, connection);
            command.Parameters.AddWithValue("@parent", Parent);
            command.Parameters.AddWithValue("@text", Option1);
            command.ExecuteNonQuery();

            //option 2
            query = "INSERT INTO answers (parent, son, answerText, isCorrect) VALUES (@parent , 3, @text, 0)";
            command = new SQLiteCommand(query, connection);
            command.Parameters.AddWithValue("@parent", Parent);
            command.Parameters.AddWithValue("@text", Option2);
            command.ExecuteNonQuery();

            //option 3
            query = "INSERT INTO answers (parent, son, answerText, isCorrect) VALUES (@parent , 4, @text, 0)";
            command = new SQLiteCommand(query, connection);
            command.Parameters.AddWithValue("@parent", Parent);
            command.Parameters.AddWithValue("@text", Option3);
            command.ExecuteNonQuery();

            MessageBox.Show("yup");

        }

        public bool AreAllValuesFilled()
        {
            if (string.IsNullOrEmpty(answer.Text) || string.IsNullOrEmpty(option1.Text) || string.IsNullOrEmpty(option2.Text)
                || string.IsNullOrEmpty(option3.Text) || string.IsNullOrEmpty(question.Text))
            {
                return false;
            }
            return true;
        }

        public int Find_Max_Parent()
        {
            string connectionString = @"Data Source=C:\Users\OZ\OneDrive\מסמכים\C# 2022\repose\Trivia\Trivia\DataBase.db;Version=3;";
            SQLiteConnection connection = new SQLiteConnection(connectionString);
            connection.Open();
            string query = "SELECT MAX(Id) FROM Riddles";
            SQLiteCommand command = new SQLiteCommand(query, connection);
            int result = Convert.ToInt32(command.ExecuteScalar());
            return result;
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("good job", "one pixel by the way", MessageBoxButton.YesNoCancel,MessageBoxImage.Hand,MessageBoxResult.OK);
        }
    }
}
