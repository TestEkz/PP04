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

namespace PP04
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow(int flag)
        {
            InitializeComponent();
            MainFrame.Navigate(new FlightsPage(flag));
            Manager.MainFrame = MainFrame;
        }
      
        private void SearchBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            
        }

        private void comboCity_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void comboSort_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void BtnCheck_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {

        }

        private void MainFrame_ContentRendered(object sender, EventArgs e)
        {

        }
    }
}
