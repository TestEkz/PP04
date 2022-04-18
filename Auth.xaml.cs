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

namespace PP04
{
    /// <summary>
    /// Логика взаимодействия для Auth.xaml
    /// </summary>
    public partial class Auth : Window
    {
        public Auth()
        {
            InitializeComponent();
        }
        public int flag;
        private void BtnAuth_Click(object sender, RoutedEventArgs e)
        {
            var user = Manager.GetContext().users.ToList();
            var currentUser = user.Where(p => p.login == LoginBox.Text && p.password == PassBox.Password);
            var main = currentUser.FirstOrDefault();

            if (currentUser.Count() != 0 && main.login == "kassir")
            {
                MessageBox.Show("Вы зашли как кассир!");
                MainWindow mainWin = new MainWindow(1);
                mainWin.Show();
                this.Hide();
            }
            else if (currentUser.Count() != 0 && main.password == "client")
            {
                MessageBox.Show("Вы зашли как покупатель!");
                MainWindow mainWin = new MainWindow(2);
                mainWin.Show();
                this.Hide();
            }
        }
    }
}
