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

        public async Task<IEnumerable<ProductViewModel>> GetProducts()
        {
            return _productViewModelMapper.MapList(await _productRepository.GetAll());
        }

        public async Task<ProductViewModel> GetProduct(int id)
        {
            return _productViewModelMapper.MapModel(await _productRepository.GetById(id));
        }

        public async Task<ProductViewModel> Create(ProductViewModel model)
        {
            var entity = _productMapper.MapModel(model);
            entity.EntryDate = DateTime.Now;

            return _productViewModelMapper.MapModel(await _productRepository.Create(entity));
        }

        public async Task Update(ProductViewModel model)
        {
            var entity = _productMapper.MapModel(model);
            entity.UpdateDate = DateTime.Now;

            await _productRepository.Update(entity);
        }

        public async Task Delete(int id)
        {
            var entity = await _productRepository.GetById(id);
            await _productRepository.Delete(entity);
        }

    }
}
