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
    /// Логика взаимодействия для DataGridPage.xaml
    /// </summary>
    public partial class DataGridPage : Page
    {
        private flights currFlight = new flights();
        public DataGridPage(flights selFlight)
        {
            InitializeComponent();
            if (selFlight != null)
            {
                currFlight = selFlight;
            }
            DataContext = currFlight;
            comboCountry.ItemsSource = Manager.GetContext().countries.ToList();
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();
            if (comboCountry == null)
                errors.AppendLine("Вы не выбрали страну");
            if (string.IsNullOrWhiteSpace(txtCity.Text))
                errors.AppendLine("Вы не выбрали город");
            if (currFlight.TimeIn <= 0)
                errors.AppendLine("Выберите конкретное время");
            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }
            if (currFlight.ID == 0)
            {
                currFlight.Country = comboCountry.SelectedIndex;
                Manager.GetContext().flights.Add(currFlight);
            }
            try
            {
                Manager.GetContext().SaveChanges();
                MessageBox.Show("Готово");
                Manager.MainFrame.GoBack();
            }
            catch
            {
                MessageBox.Show("Ошибка");
            }
        }
    }
}
