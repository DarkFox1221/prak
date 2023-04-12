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
    /// Логика взаимодействия для AuthPage.xaml
    /// </summary>
    public partial class AuthPage : Page
    {
        public AuthPage()
        {
            InitializeComponent();
        }

        private void BTNlog_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(TBlogin.Text) || string.IsNullOrEmpty(PassBox.Password))
            {
                MessageBox.Show("Введите логин и пароль", "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }

            if (TBlogin.Text != "1" || PassBox.Password != "1")
            {
                MessageBox.Show("Пользователь с такими данными не найден!", "Ошибка", MessageBoxButton.OKCancel);
            }
            else
            {
                MessageBox.Show("Пользователь успешно найден!");
                NavigationService?.Navigate(new AdminPage());
            }
        }

        private void BTNexit_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult ChoiceButton = MessageBox.Show("Выйти из программы?", "Выход", MessageBoxButton.YesNo, MessageBoxImage.Warning, MessageBoxResult.Yes);
            if (ChoiceButton == MessageBoxResult.Yes)
                Application.Current.Shutdown();
        }
    }
}