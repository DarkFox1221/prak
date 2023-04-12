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
    /// Логика взаимодействия для StockAddEditPage.xaml
    /// </summary>
    public partial class StockAddEditPage : Page
    {
        private Stock _current = new Stock();
        public StockAddEditPage(Stock selected)
        {
            InitializeComponent();
            if (selected != null)
                _current = selected;
            DataContext = _current;
        }

        private void BTNsave_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();
            if (string.IsNullOrWhiteSpace(_current.Production_name))
            {
                errors.AppendLine("Укажите название продукции");
            }
            if (string.IsNullOrWhiteSpace(_current.production_number))
            {
                errors.AppendLine("Укажите номер продукции");
            }
            if (string.IsNullOrWhiteSpace(_current.Type_STO))
            {
                errors.AppendLine("Укажите тип СТО");
            }
            if (_current.quanity_of_bottles == 0)
            {
                errors.AppendLine("Укажите количество бутылки");
            }
            if (_current.quanity_of_pallets == 0)
            {
                errors.AppendLine("Укажите количество палет");
            }
            if (_current.production_rows == 0)
            {
                errors.AppendLine("Укажите рядность продукции");
            }



            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }

            if (_current.ID_Stock == 0)
            {
                ПрактикаEntities.GetContext().Stock.Add(_current);
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
