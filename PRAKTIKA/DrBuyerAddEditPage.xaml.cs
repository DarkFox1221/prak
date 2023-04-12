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
    /// Логика взаимодействия для DrBuyerAddEditPage.xaml
    /// </summary>
    public partial class DrBuyerAddEditPage : Page
    {
        private Driver_Buyer _current = new Driver_Buyer();
        public DrBuyerAddEditPage(Driver_Buyer selected)
        {
            InitializeComponent();
            if (selected != null)
                _current = selected;
            DataContext = _current;
            CBXbuyer.ItemsSource = ПрактикаEntities.GetContext().Buyer.ToList();
            CBXDriver.ItemsSource = ПрактикаEntities.GetContext().Driver.ToList();
        }

        private void BTNsave_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();
            if (_current.Buyer == null)
            {
                errors.AppendLine("Выберите покуптаелья");
            }
            if (_current.Driver == null)
            {
                errors.AppendLine("Выберите водителя");
            }

            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }

            if (_current.ID_Buyer == 0)
            {
                ПрактикаEntities.GetContext().Driver_Buyer.Add(_current);
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