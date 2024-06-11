using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using Trivia.View;

namespace Trivia.model
{
    internal class GenerateQuestions
    {
        private string question;
        private string answer;
        private int answerIndex;
        private string option1;
        private string option2;
        private string option3;
        private int orientation;
        private int NOQuestions;

        MainPage mainPage;
        Random random = new Random();
        private string connectionString = @"Data Source=C:\Users\OZ\OneDrive\מסמכים\C# 2022\repose\Trivia\Trivia\DataBase.db;Version=3;";
        

        public GenerateQuestions(MainPage mainPage)
        {
            this.mainPage = mainPage;
            this.NOQuestions = Find_Num_Answers();
            FindQuestion();
            RandomAnswer();
            mainPage.question.Content = question;
            

        }

        public void FindQuestion()
        {
            int id = random.Next(1,NOQuestions+1);
            SQLiteConnection connection = new SQLiteConnection(connectionString);
            connection.Open();
            string QSQL = "SELECT Question FROM riddles WHERE id = @id";
            SQLiteCommand command = new SQLiteCommand(QSQL, connection);
            command.Parameters.AddWithValue("@id", id);
            this.question = command.ExecuteScalar().ToString();

            QSQL = "SELECT answerText FROM answers WHERE parent = @id AND son = 1";
            command = new SQLiteCommand(QSQL, connection);
            command.Parameters.AddWithValue("@id", id);
            this.answer = command.ExecuteScalar().ToString();

            QSQL = "SELECT answerText FROM answers WHERE parent = @id AND son = 2";
            command = new SQLiteCommand(QSQL, connection);
            command.Parameters.AddWithValue("@id", id);
            this.option1 = command.ExecuteScalar().ToString();

            QSQL = "SELECT answerText FROM answers WHERE parent = @id AND son = 3";
            command = new SQLiteCommand(QSQL, connection);
            command.Parameters.AddWithValue("@id", id);
            this.option2 = command.ExecuteScalar().ToString();

            QSQL = "SELECT answerText FROM answers WHERE parent = @id AND son = 4";
            command = new SQLiteCommand(QSQL, connection);
            command.Parameters.AddWithValue("@id", id);
            this.option3 = command.ExecuteScalar().ToString();

        }

        public void RandomAnswer()
        {
            orientation = random.Next(1, 5);
            answerIndex = orientation;

            if (orientation == 1 )
            {
                mainPage.button1.Content = answer;
                mainPage.button2.Content = option1;
                mainPage.button3.Content = option2;
                mainPage.button4.Content = option3;
            }
            else if (orientation == 2 )
            {
                mainPage.button1.Content = option1;
                mainPage.button2.Content = answer;
                mainPage.button3.Content = option3;
                mainPage.button4.Content = option2;
                //answer
            }
            else if (orientation == 3)
            {
                mainPage.button1.Content = option3;
                mainPage.button2.Content = option1;
                mainPage.button3.Content = answer;
                mainPage.button4.Content = option2;
                //answer
            }
            else if (orientation == 4)
            {
                mainPage.button1.Content = option1;
                mainPage.button2.Content = option3;
                mainPage.button3.Content = option2;
                mainPage.button4.Content = answer;
                //answer
            }
            //answerIndex = 1;
        }

        public int GetAnswerIndex()
        {
            return answerIndex;
        }

        public int Find_Num_Answers()
        {
            SQLiteConnection connection = new SQLiteConnection(connectionString);
            connection.Open();
            string query = "SELECT MAX(Id) FROM Riddles";
            SQLiteCommand command = new SQLiteCommand(query, connection);
            int result = Convert.ToInt32(command.ExecuteScalar());
            return result;
        }

    }
}
