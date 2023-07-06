using Moq;
using Project.Core.Entities.General;
using Project.Core.Interfaces.IMapper;
using Project.Core.Interfaces.IRepositories;
using Project.Core.Services;

namespace Project.UnitTest
{
    public class ProductServiceTests
    {
        private Mock<IBaseMapper<Product, ProductViewModel>> _productViewModelMapperMock;
        private Mock<IBaseMapper<ProductViewModel, Product>> _productMapperMock;
        private Mock<IProductRepository> _productRepositoryMock;

        [SetUp]
        public void Setup()
        {
            _productViewModelMapperMock = new Mock<IBaseMapper<Product, ProductViewModel>>();
            _productMapperMock = new Mock<IBaseMapper<ProductViewModel, Product>>();
            _productRepositoryMock = new Mock<IProductRepository>();
        }

        [Test]
        public async Task CreateProductAsync_ValidProduct_ReturnsCreatedProductViewModel()
        {
            // Arrange
            var productService = new ProductService(
                _productViewModelMapperMock.Object,
                _productMapperMock.Object,
                _productRepositoryMock.Object);

            var newProductViewModel = new ProductViewModel
            {
                Code = "P001",
                Name = "Sample Product",
                Price = 9.99f,
                Description = "Sample description",
                IsActive = true
            };

            var createdProduct = new Product
            {
                Code = "P001",
                Name = "Sample Product",
                Price = 9.99f,
                Description = "Sample description",
                IsActive = true
            };

            _productMapperMock.Setup(mapper => mapper.MapModel(newProductViewModel))
                              .Returns(createdProduct);

            _productRepositoryMock.Setup(repo => repo.Create(createdProduct))
                                  .ReturnsAsync(createdProduct);

            _productViewModelMapperMock.Setup(mapper => mapper.MapModel(createdProduct))
                                       .Returns(newProductViewModel);

            // Act
            var result = await productService.Create(newProductViewModel);

            // Assert
            Assert.NotNull(result);
            Assert.That(result.Code, Is.EqualTo(newProductViewModel.Code));
            // Additional assertions for other properties
        }
    }

}