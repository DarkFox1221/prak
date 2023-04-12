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

namespace PRAKTIKA
{
    /// <summary>
    /// Логика взаимодействия для StBuyerAddEditPage.xaml
    /// </summary>
    public partial class StBuyerAddEditPage : Page
    {
        private Stock_buyer _current = new Stock_buyer();
        public StBuyerAddEditPage(Stock_buyer selected)
        {
            InitializeComponent();
            if (selected != null)
                _current = selected;
            DataContext = _current;
            CBXBuyer.ItemsSource = ПрактикаEntities.GetContext().Buyer.ToList();
            CBXStock.ItemsSource = ПрактикаEntities.GetContext().Stock.ToList();
        }

        private void BTNsave_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();
            if (_current.Stock == null)
            {
                errors.AppendLine("Выберите склад");
            }
            if (_current.Buyer == null)
            {
                errors.AppendLine("Выберите покупателья");
            }

            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }

            if (_current.ID_Stock == 0)
            {
                ПрактикаEntities.GetContext().Stock_buyer.Add(_current);
            }

            try
            {
                ПрактикаEntities.GetContext().SaveChanges();
                MessageBox.Show("Информация сохранена");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
    }
}