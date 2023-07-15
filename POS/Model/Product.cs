using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Model
{
    public partial class Product : ObservableObject
    {
        [Key]
        public int Id { get; set; }
        public string ProductName { get; set; }
        public string Supplier { get; set; }
        public decimal Price { get; set; }

        [ObservableProperty]
        public int quantity;


        public Product() { }
    }
}
