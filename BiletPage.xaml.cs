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
    /// Логика взаимодействия для BiletPage.xaml
    /// </summary>
    public partial class BiletPage : Page
    {
        public BiletPage()
        {
            InitializeComponent();
            comboCity.ItemsSource = Manager.GetContext().flights.ToList();
        }
        string CityName;
        private void comboCity_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var city = Manager.GetContext().flights.ToList();
            var currentCity = city.Where(p => p.City.Contains((comboCity.SelectedItem as flights).City)).ToList();
            var main = currentCity.FirstOrDefault();
            CityName = main.City;
        }
        private void repword(string stupRp, string text, Word.Document wrorddocc)
        {
            var range = wrorddocc.Content;
            range.Find.ClearFormatting();
            range.Find.Execute(FindText: stupRp, ReplaceWith: text);
        }
        private void BtnCheck_Click(object sender, RoutedEventArgs e)
        {
            var wordApp = new Word.Application();
            wordApp.Visible = false;
            try
            {
                var wordDoc = wordApp.Documents.Open(AppDomain.CurrentDomain.BaseDirectory + "ticket.docx");
                repword("{LName}", LNameTxt.Text, wordDoc);
                repword("{FName}", FNameTxt.Text, wordDoc);
                repword("{MName}", MNameTxt.Text, wordDoc);
                repword("{Passport}", PassportTxt.Text, wordDoc);
                repword("{Phone}", PhoneTxt.Text, wordDoc);
                repword("{City}", CityName, wordDoc);
                repword("{Ryad}", RyadTxt.Text, wordDoc);
                repword("{Mesto}", MestoTxt.Text, wordDoc);
                wordDoc.SaveAs(AppDomain.CurrentDomain.BaseDirectory + "ticketFinal.docx");
                wordApp.Visible = true;
                RegistryKey currentUserKey = Registry.CurrentUser;
                RegistryKey helloKey = currentUserKey.CreateSubKey(LNameTxt.Text);
                helloKey.SetValue("City", CityName);
                helloKey.Close();
            }
            catch
            {
                MessageBox.Show("Не удалось сформировать чек!");
            }
        }
    }
}
