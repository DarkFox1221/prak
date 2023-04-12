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
    /// Логика взаимодействия для StBuyerPage.xaml
    /// </summary>
    public partial class StBuyerPage : Page
    {
        public StBuyerPage()
        {
            InitializeComponent();
            DGrid.ItemsSource = ПрактикаEntities.GetContext().Stock_buyer.ToList();
            Update();
        }

        private void Update()
        {
            var current = ПрактикаEntities.GetContext().Stock_buyer.ToList();
            current = current.Where(p => p.ID_Stock.ToString().ToLower().Contains(SearchTBX.Text.ToLower())).ToList();
            DGrid.ItemsSource = current.OrderBy(p => p.ID_Stock.ToString()).ToList();

        }
        private void BTNedit_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new StBuyerAddEditPage((sender as Button).DataContext as Stock_buyer));
        }

        private void BTNdelete_Click(object sender, RoutedEventArgs e)
        {
            var ForRemoving = DGrid.SelectedItems.Cast<Stock_buyer>().ToList();
            if (MessageBox.Show($"Вы точно хотите удалите следующие {ForRemoving.Count()} элементов?", "Внимание!", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    ПрактикаEntities.GetContext().Stock_buyer.RemoveRange(ForRemoving);
                    ПрактикаEntities.GetContext().SaveChanges();
                    MessageBox.Show("Данные удалены!");

                    DGrid.ItemsSource = ПрактикаEntities.GetContext().Stock_buyer.ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }

        private void BTNadd_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new StBuyerAddEditPage(null));
        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                ПрактикаEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                DGrid.ItemsSource = ПрактикаEntities.GetContext().Stock_buyer.ToList();
            }
        }

        private void SearchTBX_TextChanged(object sender, TextChangedEventArgs e)
        {
            Update();
        }
    }
}
