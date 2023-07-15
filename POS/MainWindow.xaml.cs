using POS.ViewModel;
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

namespace POS
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            MainWindowVM vm = new MainWindowVM();
            DataContext = vm;
            vm.closeWindow = () => Close();
        }
        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            // Update the Password property of the view model when the password is changed
            if (DataContext is MainWindowVM vm)
            {
                vm.Password = ((PasswordBox)sender).Password;
            }
        }
        private void adminPasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            // Update the Password property of the view model when the password is changed
            if (DataContext is MainWindowVM vm)
            {
                vm.adminPassword = ((PasswordBox)sender).Password;
            }
        }
    }
}
