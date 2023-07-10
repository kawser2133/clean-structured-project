using Project.Core.Entities.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Core.Interfaces.IRepositories
{
    //Unit of Work Pattern
    public interface IBaseRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> GetById<Tid>(Tid id);
        Task<T> Create(T model);
        Task Update(T model);
        Task Delete(T model);
        Task SaveChangeAsync();
    }
}
