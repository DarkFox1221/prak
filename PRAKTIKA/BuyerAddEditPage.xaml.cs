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
    /// Логика взаимодействия для BuyerAddEditPage.xaml
    /// </summary>
    public partial class BuyerAddEditPage : Page
    {
        private Buyer _current = new Buyer();
        public BuyerAddEditPage(Buyer selected)
        {
            InitializeComponent();
            if (selected != null)
                _current = selected;
            DataContext = _current;
        }

        private void BTNsave_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();
            if (string.IsNullOrWhiteSpace(_current.Buyer_adress))
            {
                errors.AppendLine("Укажите адрес");
            }
            if (string.IsNullOrWhiteSpace(_current.production_type_buyer))
            {
                errors.AppendLine("Укажите тип продукции");
            }
            if (_current.Cost == 0)
            {
                errors.AppendLine("Укажите цену");
            }




            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }

            if (_current.ID_Buyer == 0)
            {
                ПрактикаEntities.GetContext().Buyer.Add(_current);
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
