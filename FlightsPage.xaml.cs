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
using Word = Microsoft.Office.Interop.Word;

namespace PP04
{
    /// <summary>
    /// Логика взаимодействия для FlightsPage.xaml
    /// </summary>
    public partial class FlightsPage : Page
    {
        public FlightsPage(int flag)
        {
            InitializeComponent();
            var allCity = Manager.GetContext().countries.ToList();
            allCity.Insert(0, new countries
            {
                Name = "Все страны"
            });
            if (flag == 2)
            {
                BtnAdd.Visibility = Visibility.Hidden;
                BtnEdit.Visibility = Visibility.Hidden;
                BtnCheck.Visibility = Visibility.Hidden;
            }
            comboSort.SelectedIndex = 0;
            comboCity.ItemsSource = allCity;
            comboCity.SelectedIndex = 0;
            Update();
        }
        public void Update()
        {
            var currFlight = Manager.GetContext().flights.ToList();
            currFlight = currFlight.Where(p => p.City.ToLower().Contains(SearchBox.Text.ToLower())).ToList();

            if (comboCity.SelectedIndex > 0)
                currFlight = currFlight.Where(p => p.countries.Name.Contains((comboCity.SelectedItem as countries).Name)).ToList();
            switch (comboSort.SelectedIndex)
            {
                case 0:
                    DGridFlight.ItemsSource = currFlight;
                    break;
                case 1:
                    DGridFlight.ItemsSource = currFlight.OrderBy(p => p.City).ToList();
                    break;
                case 2:
                    DGridFlight.ItemsSource = currFlight.OrderByDescending(p => p.City).ToList();
                    break;
            }

        }
        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new DataGridPage(DGridFlight.SelectedItem as flights));
        }

        private void BtnCheck_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new BiletPage());
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new DataGridPage(null));
        }

        private void comboSort_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Update();
        }

        private void comboCity_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Update();
        }

        private void SearchBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            Update();
        }
    }
}
