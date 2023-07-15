using Project.Core.Entities.Business;
using Project.Core.Entities.General;
using Project.Core.Exceptions;
using Project.Core.Interfaces.IMapper;
using Project.Core.Interfaces.IRepositories;
using Project.Core.Interfaces.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Core.Services
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

        public async Task<PaginatedDataViewModel<ProductViewModel>> GetPaginatedProducts(int pageNumber, int pageSize)
        {
            var paginatedData = await _productRepository.GetPaginatedData(pageNumber, pageSize);
            var mappedData = _productViewModelMapper.MapList(paginatedData.Data);

            var paginatedDataViewModel = new PaginatedDataViewModel<ProductViewModel>(mappedData.ToList(), paginatedData.TotalCount);
            
            return paginatedDataViewModel;
        }

        public async Task<ProductViewModel> GetProduct(int id)
        {
            return _productViewModelMapper.MapModel(await _productRepository.GetById(id));
        }

        public async Task<bool> IsExists(string key, string value)
        {
            return await _productRepository.IsExists(key, value);
        }

        public async Task<bool> IsExistsForUpdate(int id, string key, string value)
        {
            return await _productRepository.IsExistsForUpdate(id, key, value);
        }

        public async Task<ProductViewModel> Create(ProductViewModel model)
        {
            //Mapping through AutoMapper
            var entity = _productMapper.MapModel(model);
            entity.EntryDate = DateTime.Now;

            return _productViewModelMapper.MapModel(await _productRepository.Create(entity));
        }

        public async Task Update(ProductViewModel model)
        {
            var existingData = await _productRepository.GetById(model.Id);

            //Manual mapping
            existingData.Code = model.Code;
            existingData.Name = model.Name;
            existingData.Price = model.Price;
            existingData.Description = model.Description;
            existingData.IsActive = model.IsActive;
            existingData.UpdateDate = DateTime.Now;

            await _productRepository.Update(existingData);
        }

        public async Task Delete(int id)
        {
            var entity = await _productRepository.GetById(id);
            await _productRepository.Delete(entity);
        }

    }
}
