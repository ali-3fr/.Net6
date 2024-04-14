using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xunit;
using SimpleApp.Models;

namespace SimpleApp.Tests
{
    public class ProductTests
    {
        [Fact]
        public void CanChangeProductName()
        {
            //Arrange
            var p = new Product
            {
                Name = "Test",
                Price = 1,
            };
            //Act
            p.Name = "New Name";
            //Assert
            Assert.Equal("New Name",p.Name);
        }
        [Fact]
        public void CanChangePrice()
        {
            //Arrange
            var p = new Product
            {
                Name = "Test",
                Price = 1,
            };
            //Act
            p.Price = 2;
            //Assert
            Assert.Equal(2,p.Price);

        }
    }
}
