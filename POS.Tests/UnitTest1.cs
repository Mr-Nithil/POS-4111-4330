using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using POS.Model;
using POS.ViewModel;
using System.Collections.ObjectModel;

namespace POS.Tests
{
    public class PaymentTests
    {
        [Fact]
        public void GetTotal_ShouldCalculateCorrectTotalPrice()
        {
            // Arrange
            var vm = new UserWindowVM();
            vm.ProductBucket.Add(new Product { Price = 10, Quantity = 2 });
            vm.ProductBucket.Add(new Product { Price = 8, Quantity = 1 });
            vm.ProductBucket.Add(new Product { Price = 11, Quantity = 3 });
            vm.ProductBucket.Add(new Product { Price = 12, Quantity = 2 });

            var expectedTotal = 85;

            // Act
            vm.TotalAmount = vm.GetTotal();
            var actualTotal = vm.TotalAmount;

            // Assert
            actualTotal.Should().Be(expectedTotal);
        }
    }
}