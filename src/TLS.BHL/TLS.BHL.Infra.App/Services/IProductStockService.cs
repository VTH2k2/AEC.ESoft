using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AEC.Core.Service;
using AEC.ESoft.Infra.App.Domain.Entities;

namespace AEC.ESoft.Infra.App.Services
{
    public  interface IProductStockService : IService
    {
        public Task<ProductStockEntity> GetByProductId(int productId);

        public Task Update(ProductStockEntity entity);
    }
}
