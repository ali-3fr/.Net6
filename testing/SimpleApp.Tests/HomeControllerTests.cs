﻿using Microsoft.AspNetCore.Mvc;
using SimpleApp.Controllers;
using SimpleApp.Models;
using Moq;

namespace SimpleApp.Tests
{
    public class HomeControllerTests
    {
        
        [Fact]
        public void IndexActionModelIsComplete()
        {
            //Arrange
            Product[] testData = new Product[] {
 new Product { Name = "P1", Price = 75.10M },
 new Product { Name = "P2", Price = 120M },
 new Product { Name = "P3", Price = 110M }
 };

            var mock = new Mock<IDataSource>();
            mock.SetupGet(m => m.Products).Returns(testData);
            //IDataSource data = new FakeDataSource(testData);
            var controller = new HomeController();
            controller.Source = mock.Object;


            //Act
            var model = (controller.Index() as ViewResult)?.ViewData.Model as IEnumerable<Product>;

            //Assert
            Assert.Equal(testData, model, Comparer.Get<Product>((p1, p2) => p1?.Name == p2?.Name && p2?.Price == p1?.Price));
            mock.VerifyGet(m=>m.Products,Times.Once);
        }
    }
}
