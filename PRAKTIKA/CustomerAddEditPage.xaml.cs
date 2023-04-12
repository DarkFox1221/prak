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
    /// Логика взаимодействия для CustomerAddEditPage.xaml
    /// </summary>
    public partial class CustomerAddEditPage : Page
    {
        private Customer _current = new Customer();
        public CustomerAddEditPage(Customer selected)
        {
            InitializeComponent();
            if (selected != null)
                _current = selected;
            DataContext = _current;
        }

        private void BTNsave_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();
            if (string.IsNullOrWhiteSpace(_current.customer_adress))
            {
                errors.AppendLine("Укажите адрес");
            }
            if (string.IsNullOrWhiteSpace(_current.Production_type))
            {
                errors.AppendLine("Укажите тип продукции");
            }
            if (_current.Treaty_number == 0)
            {
                errors.AppendLine("Укажите номер договора");
            }


            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }

            if (_current.ID_Customer == 0)
            {
                ПрактикаEntities.GetContext().Customer.Add(_current);
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
