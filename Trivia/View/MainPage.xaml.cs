using System;
using System.Collections.Generic;
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
    /// Interaction logic for MainPage.xaml....Control@gmail.com
    /// </summary>
    public partial class MainPage : Page
    {

        private int AnswerIndex;
        GenerateQuestions generateQuestions;

        public MainPage()
        {
            InitializeComponent();
            generateQuestions = new GenerateQuestions(this);
            AnswerIndex = generateQuestions.GetAnswerIndex();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            if(AnswerIndex == 1)
            {
                MessageBox.Show("yay", "right");
            }
            generateQuestions = new GenerateQuestions(this);
            AnswerIndex = generateQuestions.GetAnswerIndex();
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            if (AnswerIndex == 2)
            {
                MessageBox.Show("yay", "right");
            }
            generateQuestions = new GenerateQuestions(this);
            AnswerIndex = generateQuestions.GetAnswerIndex();
        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {
            if (AnswerIndex == 3)
            {
                MessageBox.Show("yay", "right");
            }
            generateQuestions = new GenerateQuestions(this);
            AnswerIndex = generateQuestions.GetAnswerIndex();
        }

        private void button4_Click(object sender, RoutedEventArgs e)
        {
            if (AnswerIndex == 4)
            {
                MessageBox.Show("yay", "right");
            }
            generateQuestions = new GenerateQuestions(this);
            AnswerIndex = generateQuestions.GetAnswerIndex();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            LogIn logIn = new LogIn();
            NavigationService.Navigate(logIn);
        }
    }
}
