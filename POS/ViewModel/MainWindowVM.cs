using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using POS.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using static System.Net.Mime.MediaTypeNames;

namespace POS.ViewModel
{
    public partial class MainWindowVM: ObservableObject
    {
        [ObservableProperty]
        public string userName;
        [ObservableProperty]
        public string password;

        public Action CloseAction { get; set; }

        [ObservableProperty]
        public string adminName;
        [ObservableProperty]
        public string adminPassword;

        public Action closeWindow { get; set; }

        public MainWindowVM() { }

        [RelayCommand]
        public void userLogin()
        {
            var username = UserName;
            var password = Password;


            using (userContext context = new userContext())
            {
                bool findUser = context.Users.Any(user => user.Name == userName && user.Password == password);

                if (findUser)
                {
                    var window = new userWindow();
                    window.Show();
                    this.closeWindow();
                }
                else
                {
                    MessageBox.Show("Invalid Username or Password");
                }
            }
        }
        [RelayCommand]
        public void adminLogin()
        {
            var Password = AdminPassword;

            using (userContext context = new userContext())
            {
                bool findAdmin = context.Admins.Any(admin => admin.AdminPassword == Password);

                Window window;
                if (findAdmin)
                {
                    window = new adminWindow();
                    window.Show();
                    this.closeWindow();
                }
                else
                {
                    MessageBox.Show("Invalid Password");
                }
                
            }
        }
    }
}
