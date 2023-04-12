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
    /// Логика взаимодействия для DriverAddEditPage.xaml
    /// </summary>
    public partial class DriverAddEditPage : Page
    {
        private Driver _current = new Driver();
        public DriverAddEditPage(Driver selected)
        {
            InitializeComponent();
            if (selected != null)
                _current = selected;
            DataContext = _current;
        }

        private void BTNsave_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();
            if (string.IsNullOrWhiteSpace(_current.Driver_surname))
            {
                errors.AppendLine("Укажите фамилию");
            }
            if (string.IsNullOrWhiteSpace(_current.Driver_name))
            {
                errors.AppendLine("Укажите имя");
            }
            if (string.IsNullOrWhiteSpace(_current.Driver_LastName))
            {
                errors.AppendLine("Укажите отчество");
            }
            if (string.IsNullOrWhiteSpace(_current.Car_number))
            {
                errors.AppendLine("Укажите номер машины");
            }
            if (string.IsNullOrWhiteSpace(_current.Driver_data))
            {
                errors.AppendLine("Укажите паспорт");
            }



            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }

            if (_current.ID_Driver == 0)
            {
                ПрактикаEntities.GetContext().Driver.Add(_current);
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
