using AEC.Core.Service;
using AEC.ESoft.Infra.App.Domain.Entities;
using AEC.ESoft.Infra.App.Repositories;
using AEC.ESoft.Infra.App.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AEC.ESoft.Infra.Business.Services
{
    public class ProductStockService : ServiceBase, IProductStockService
    {
        public readonly IProductStockRepository _productStockRepository;

        public ProductStockService(IServiceProvider serviceProvider , IProductStockRepository productStockRepository) : base(serviceProvider)
        {
            _productStockRepository = productStockRepository;
        }

        public async Task<ProductStockEntity> GetByProductId(int productId)
        {
            return await _productStockRepository.GetByProductId(productId);
        }

        public async Task Update(ProductStockEntity entity)
        {
            await _productStockRepository.Update(entity);
        }
    }
}
