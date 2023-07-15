using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using POS.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace POS.ViewModel
{
    public partial class AdminWindowVM : ObservableObject
    {
        [ObservableProperty]
        public string name;
        [ObservableProperty]
        public string password;

        [ObservableProperty]
        ObservableCollection<User> users;

        public Action CloseAction { get; set; }


        private User selected;

        public User Selected
        {
            get { return selected; }
            set
            {
                selected = value;
                Name = selected?.Name;
                Password = selected?.Password;
            }
        }

        [ObservableProperty]
        public string productName;
        [ObservableProperty]
        public string supplier;
        [ObservableProperty]
        public decimal price;
        [ObservableProperty]
        public int quantity;

        [ObservableProperty]
        ObservableCollection<Product> products;

        [ObservableProperty]
        ObservableCollection<Order> orders;


        private Product selectedProduct;

        public Product SelectedProduct
        {
            get { return selectedProduct; }
            set
            {
                selectedProduct = value;
                ProductName = selectedProduct?.ProductName;
                Supplier = selectedProduct?.Supplier;
                Price = selectedProduct?.Price ?? 0;
                Quantity = selectedProduct?.Quantity ?? 0;
            }
        }

        [RelayCommand]
        public void AddUser()
        {
            if (string.IsNullOrEmpty(Name) || string.IsNullOrEmpty(Password))
            {
                // show an error message or throw an exception
                return;
            }

            User u = new User()
            {
                Name = Name,
                Password = Password
            };

            using (var db = new userContext())
            {
                db.Users.Add(u);
                db.SaveChanges();
            }

            LoadUser();

            //Clear the inputs
            Name = "";
            Password = "";
        }

        public void LoadUser()
        {
            using (var db = new userContext())
            {
                List<User> list = db.Users.ToList();
                Users = new ObservableCollection<User>(list);
            }
        }

        [RelayCommand]
        public void EditUser(User editUser)
        {
            if (selected == null)
            {
                MessageBox.Show("Please select an user to edit.", "Error");
                return;
            }

            if (!string.IsNullOrEmpty(Name) && !string.IsNullOrEmpty(Password))
            {
                if (editUser != null)
                {
                    editUser.Name = name;
                    editUser.Password = password;

                    using (var db = new userContext())
                    {
                        db.Users.Update(editUser);
                        db.SaveChanges();
                    }
                    LoadUser();
                }
            }
        }

        [RelayCommand]
        public void DeleteUser()
        {
            if (selected != null)
            {
                using (var db = new userContext())
                {
                    db.Users.Remove(selected);
                    db.SaveChanges();
                }
                LoadUser();
            }
            else
            {
                MessageBox.Show("Please Select an User.", "ERROR!");
            }
            LoadUser();
        }

        [RelayCommand]
        public void AddProduct()
        {
            if (string.IsNullOrEmpty(ProductName) || string.IsNullOrEmpty(Supplier))
            {
                // show an error message or throw an exception
                return;
            }

            Product p = new Product()
            {
                ProductName = ProductName,
                Supplier = Supplier,
                Price = Price,
                Quantity = Quantity

            };

            using (var db = new userContext())
            {
                db.Products.Add(p);
                db.SaveChanges();
            }

            LoadProduct();

            //Clear the inputs
            ProductName = "";
            Supplier = "";
            Price = 0;
            Quantity = 0;

        }

        public void LoadProduct()
        {
            using (var db = new userContext())
            {
                List<Product> list = db.Products.ToList();
                Products = new ObservableCollection<Product>(list);
            }
        }

        public void LoadOrder()
        {
            using (var db = new userContext())
            {
                List<Order> list = db.Orders.ToList();
                Orders = new ObservableCollection<Order>(list);
            }
        }

        [RelayCommand]
        public void EditProduct(Product selectedProduct)
        {
            if (selectedProduct == null)
            {
                MessageBox.Show("Please select a product to edit.", "Error");
                return;
            }

            if (string.IsNullOrEmpty(ProductName) || string.IsNullOrEmpty(Supplier) || Price <= 0 || Quantity <= 0)
            {
                MessageBox.Show("Please provide valid values for all fields.", "Error");
                return;
            }

            selectedProduct.ProductName = ProductName;
            selectedProduct.Supplier = Supplier;
            selectedProduct.Price = Price;
            selectedProduct.Quantity = Quantity;

            using (var db = new userContext())
            {
                db.Products.Update(selectedProduct);
                db.SaveChanges();
            }

            LoadProduct();

            // Clear the inputs
            ProductName = string.Empty;
            Supplier = string.Empty;
            Price = 0;
            Quantity = 0;
        }

        [RelayCommand]
        public void DeleteProduct()
        {
            if (SelectedProduct != null)
            {
                using (var db = new userContext())
                {
                    db.Products.Remove(SelectedProduct);
                    db.SaveChanges();
                }
            }
            else
            {
                MessageBox.Show("Please Select a Product.", "ERROR!");
            }
            LoadProduct();
        }

        [RelayCommand]
        public void CloseWindow()
        {
            var window = new MainWindow();
            window.Show();
            this.CloseAction();
            //CloseAction();
        }

        public AdminWindowVM()
        {
            LoadUser();
            LoadProduct();
            LoadOrder();
        }
    }
}

