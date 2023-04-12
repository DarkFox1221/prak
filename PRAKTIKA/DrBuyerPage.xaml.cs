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
    /// Логика взаимодействия для DrBuyerPage.xaml
    /// </summary>
    public partial class DrBuyerPage : Page
    {
        public DrBuyerPage()
        {
            InitializeComponent();
            DGrid.ItemsSource = ПрактикаEntities.GetContext().Driver_Buyer.ToList();
            Update();
        }

        private void Update()
        {
            var current = ПрактикаEntities.GetContext().Driver_Buyer.ToList();
            current = current.Where(p => p.ID_DR_BUY.ToString().ToLower().Contains(SearchTBX.Text.ToLower())).ToList();
            DGrid.ItemsSource = current.OrderBy(p => p.ID_DR_BUY.ToString()).ToList();

        }
        private void BTNedit_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new DrBuyerAddEditPage((sender as Button).DataContext as Driver_Buyer));
        }

        private void BTNdelete_Click(object sender, RoutedEventArgs e)
        {
            var ForRemoving = DGrid.SelectedItems.Cast<Driver_Buyer>().ToList();
            if (MessageBox.Show($"Вы точно хотите удалите следующие {ForRemoving.Count()} элементов?", "Внимание!", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    ПрактикаEntities.GetContext().Driver_Buyer.RemoveRange(ForRemoving);
                    ПрактикаEntities.GetContext().SaveChanges();
                    MessageBox.Show("Данные удалены!");

                    DGrid.ItemsSource = ПрактикаEntities.GetContext().Driver_Buyer.ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }

        private void BTNadd_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new DrBuyerAddEditPage(null));
        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                ПрактикаEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                DGrid.ItemsSource = ПрактикаEntities.GetContext().Driver_Buyer.ToList();
            }
        }

        private void SearchTBX_TextChanged(object sender, TextChangedEventArgs e)
        {
            Update();
        }
    }
}