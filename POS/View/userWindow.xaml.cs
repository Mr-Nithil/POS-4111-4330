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
using System.Windows.Shapes;

namespace POS.View
{
    /// <summary>
    /// Interaction logic for userWindow.xaml
    /// </summary>
    public partial class userWindow : Window
    {
        public userWindow()
        {
            InitializeComponent();
            UserWindowVM vm = new UserWindowVM();
            DataContext = vm;
            vm.CloseAction = () => Close();
        }
    }
}
