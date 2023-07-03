using ProjectMaster.Core.Entities.General;
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
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<ProductViewModel> Create(ProductViewModel model)
        {


            return await _productRepository.Create(model);
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
