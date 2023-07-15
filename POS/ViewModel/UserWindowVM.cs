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

namespace POS.ViewModel
{
    public partial class UserWindowVM : ObservableObject
    {
        [ObservableProperty]
        ObservableCollection<Product> products;
        [ObservableProperty]
        ObservableCollection<Product> productBucket;
        [ObservableProperty]
        public Product selectedProduct;
        [ObservableProperty]
        public DateTime date;
        [ObservableProperty]
        public List<Product> orderItems;
        [ObservableProperty]
        public decimal totalAmount;

        public Action CloseAction { get; set; }
        public UserWindowVM()
        {
            LoadProducts();
            ProductBucket = new ObservableCollection<Product>();
        }

        [RelayCommand]
        public void AddToCart()
        {
            if (SelectedProduct != null)
            {
                var existingProduct = ProductBucket.FirstOrDefault(p => p.Id == SelectedProduct.Id);
                if (existingProduct != null)
                {
                    existingProduct.Quantity++;
                }
                else
                {
                    var newProduct = new Product
                    {
                        Id = SelectedProduct.Id,
                        ProductName = SelectedProduct.ProductName,
                        Price = SelectedProduct.Price,
                        Quantity = 1
                    };
                    ProductBucket.Add(newProduct);
                }
            }
        }

        [RelayCommand]
        public void RemoveFromCart(Product product)
        {
            if (product != null)
            {
                if (product.Quantity > 1)
                {
                    product.Quantity--;
                }
                else
                {
                    ProductBucket.Remove(product);
                }
            }
        }

        [RelayCommand]
        public void Pay()
        {
            var total = 0;
            if (ProductBucket.Count > 0)
            {
                using (var db = new userContext())
                {
                    // Create a new order
                    var order = new Order
                    {
                        Date = DateTime.Now,
                        Total = GetTotal(),
                    };
                    db.Orders.Add(order);


                    // Add order items
                    foreach (var bucketProduct in ProductBucket)
                    {
                        var orderItem = new OrderItem
                        {
                            Order = order,
                            ProductId = bucketProduct.Id,
                            Quantity = bucketProduct.Quantity,
                            Price = bucketProduct.Price
                        };
                        db.OrderItems.Add(orderItem);

                        // Update product quantity in the database
                        var product = db.Products.Find(bucketProduct.Id);
                        product.Quantity -= bucketProduct.Quantity;
                    }
                    TotalAmount = order.Total;
                    // Save changes to the database
                    db.SaveChanges();

                    MessageBox.Show($"Total Price : {TotalAmount}\nOrder completed Successfully !! ");
                    ProductBucket.Clear();
                    TotalAmount = 0;
                }
            }
            else
            {
                MessageBox.Show("Cart is empty.");
            }
        }
        [RelayCommand]
        public void CloseWindow()
        {
            var window = new MainWindow();
            window.Show();
            this.CloseAction();
            //CloseAction();
        }

        public void LoadProducts()
        {
            using (var db = new userContext())
            {
                List<Product> list = db.Products.ToList();
                Products = new ObservableCollection<Product>(list);
            }
        }

        public decimal GetTotal()
        {
           return ProductBucket.Sum(p => p.Price * p.Quantity);
        }
    }
}
