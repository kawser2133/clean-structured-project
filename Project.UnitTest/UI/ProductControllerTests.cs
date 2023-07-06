using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using Project.Core.Entities.General;
using Project.Core.Interfaces.IServices;
using Project.UI.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.UnitTest.UI
{
    public class ProductControllerTests
    {
        private Mock<IProductService> _productServiceMock;
        private Mock<ILogger<ProductController>> _loggerMock;
        private ProductController _productController;

        [SetUp]
        public void Setup()
        {
            _productServiceMock = new Mock<IProductService>();
            _loggerMock = new Mock<ILogger<ProductController>>();
            _productController = new ProductController(_loggerMock.Object, _productServiceMock.Object);
        }

        [Test]
        public async Task Index_ReturnsViewWithListOfProducts()
        {
            // Arrange
            var products = new List<ProductViewModel>
            {
                new ProductViewModel { Id = 1, Code = "P001", Name = "Product A", Price = 9.99f, IsActive = true },
                new ProductViewModel { Id = 2, Code = "P002", Name = "Product B", Price = 19.99f, IsActive = true }
            };

            _productServiceMock.Setup(service => service.GetProducts())
                               .ReturnsAsync(products);

            // Act
            var result = await _productController.Index();

            // Assert
            Assert.IsInstanceOf<ViewResult>(result);
            var viewResult = (ViewResult)result;
            Assert.NotNull(viewResult);
            Assert.That(viewResult.Model, Is.InstanceOf<IEnumerable<ProductViewModel>>());
            var model = (IEnumerable<ProductViewModel>)viewResult.Model;
            Assert.NotNull(model);
            Assert.That(model.Count(), Is.EqualTo(products.Count));
        }

        // Add more test methods for other controller actions, such as Create, Update, Delete, etc.

    }
}
