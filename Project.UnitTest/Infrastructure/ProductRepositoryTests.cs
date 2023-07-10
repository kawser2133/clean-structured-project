using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Moq;
using Project.Core.Entities.General;
using Project.Infrastructure.Data;
using Project.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.UnitTest.Infrastructure
{
    public class ProductRepositoryTests
    {
        private Mock<ApplicationDbContext> _dbContextMock;
        private ProductRepository _productRepository;

        [SetUp]
        public void Setup()
        {
            _dbContextMock = new Mock<ApplicationDbContext>(new DbContextOptions<ApplicationDbContext>());
            _productRepository = new ProductRepository(_dbContextMock.Object);
        }

        [Test]
        public async Task AddAsync_ValidProduct_ReturnsAddedProduct()
        {

            // Arrange
            var newProduct = new Product
            {
                Code = "P001",
                Name = "Sample Product",
                Price = 9.99f,
                IsActive = true
            };

            var productDbSetMock = new Mock<DbSet<Product>>();

            _dbContextMock.Setup(db => db.Set<Product>())
                          .Returns(productDbSetMock.Object);

            productDbSetMock.Setup(dbSet => dbSet.AddAsync(newProduct, default))
                            .ReturnsAsync((EntityEntry<Product>)null);

            // Act
            var result = await _productRepository.Create(newProduct);


            // Assert
            Assert.NotNull(result);
            Assert.That(result, Is.EqualTo(newProduct));
        }

        // Add more test methods for other repository operations, such as GetByIdAsync, UpdateAsync, DeleteAsync, etc.
    }
}
