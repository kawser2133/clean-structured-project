using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using ProjectMaster.Core.Entities.General;
using ProjectMaster.Core.Interfaces.IMapper;
using ProjectMaster.Core.Interfaces.IRepositories;
using ProjectMaster.Core.Interfaces.IServices;
using ProjectMaster.Core.Mapper;
using ProjectMaster.Core.Services;
using ProjectMaster.Infrastructure.Repositories;

namespace ProjectMaster.Web.Extensions
{
    public static class ServiceExtension
    {
        public static IServiceCollection RegisterService(this IServiceCollection services)
        {
            #region Services
            services.AddScoped<IProductService, ProductService>();

            #endregion

            #region Repositories
            services.AddTransient<IProductRepository, ProductRepository>();

            #endregion

            #region Mapper
            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Product, ProductViewModel>();
                cfg.CreateMap<ProductViewModel, Product>();
            });

            IMapper mapper = configuration.CreateMapper();

            // Register the IMapperService implementation with your dependency injection container
            services.AddSingleton<IBaseMapper<Product, ProductViewModel>>(new BaseMapper<Product, ProductViewModel>(mapper));
            services.AddSingleton<IBaseMapper<ProductViewModel, Product>>(new BaseMapper<ProductViewModel, Product>(mapper));

            #endregion

            return services;
        }
    }
}
