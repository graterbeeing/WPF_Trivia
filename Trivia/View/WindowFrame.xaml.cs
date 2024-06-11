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
using System.Windows.Shapes;

namespace Trivia.View
{
    /// <summary>
    /// Interaction logic for WindowFrame.xaml
    /// </summary>
    public partial class WindowFrame : Window
    {
        public WindowFrame()
        {
            InitializeComponent();
            mainFrame.Navigate(new LogIn());
            Application.Current.Windows[0].Height = 530;
            Application.Current.Windows[0].Width = 500;
        }

        private void exitMenu_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
            this.Close();
        }
    }
}
