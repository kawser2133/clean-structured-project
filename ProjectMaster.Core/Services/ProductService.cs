using ProjectMaster.Core.Entities.General;
using ProjectMaster.Core.Interfaces.IMapper;
using ProjectMaster.Core.Interfaces.IRepositories;
using ProjectMaster.Core.Interfaces.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectMaster.Core.Services
{
    public class ProductService : IProductService
    {
        private readonly IBaseMapper<Product, ProductViewModel> _productViewModelMapper;
        private readonly IBaseMapper<ProductViewModel, Product> _productMapper;
        private readonly IProductRepository _productRepository;

        public ProductService(
            IBaseMapper<Product, ProductViewModel> productViewModelMapper,
            IBaseMapper<ProductViewModel, Product> productMapper,
            IProductRepository productRepository)
        {
            _productMapper = productMapper;
            _productViewModelMapper = productViewModelMapper;
            _productRepository = productRepository;
        }


        public async Task<ProductViewModel> Create(ProductViewModel model)
        {
            var data = _productMapper.MapModel(model);
            return _productViewModelMapper.MapModel(await _productRepository.Create(data));
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ProductViewModel> GetProduct(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ProductViewModel>> GetProducts()
        {
            throw new NotImplementedException();
        }

        public Task Update(ProductViewModel model)
        {
            throw new NotImplementedException();
        }
    }
}
