using Project.Core.Entities.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Core.Interfaces.IServices
{
    public interface IProductService
    {
        Task<IEnumerable<ProductViewModel>> GetProducts();
        Task<IEnumerable<ProductViewModel>> GetPaginatedProducts(int pageNumber, int pageSize);
        Task<ProductViewModel> GetProduct(int id);
        Task<bool> IsExists(string key, string value);
        Task<bool> IsExistsForUpdate(int id, string key, string value);
        Task<ProductViewModel> Create(ProductViewModel model);
        Task Update(ProductViewModel model);
        Task Delete(int id);
    }
}
