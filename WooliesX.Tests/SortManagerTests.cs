using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WooliesX.Application;
using WooliesX.Domain.Entities;

namespace WooliesX.Tests
{
    [TestFixture]
    public class SortManagerTests
    {
        [Test]
        public void WhenSortOptionIsLowProductsReturnedLowestPriceToHighestprice()
        {
            // Arrange
            var sortManager = new SortManager();
            ICollection<IProduct> products = new List<IProduct>();
            products.Add(new Product { Name = "A", Price = 1000 });
            products.Add(new Product { Name = "B", Price = 100 });
            products.Add(new Product { Name = "C", Price = 10 });
            
            // Act
            var actual = sortManager.StandardSort(products, SortOptions.Low);
            var expected = new List<double?> { 10, 100, 1000 };

            //assert
            Assert.AreEqual(expected, actual.ToList().Select(p => p.Price));
        }
    }
}
