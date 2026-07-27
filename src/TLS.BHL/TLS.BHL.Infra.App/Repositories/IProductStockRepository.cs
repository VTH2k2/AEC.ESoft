using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AEC.Core.Data;
using AEC.ESoft.Infra.App.Domain.Entities;

namespace AEC.ESoft.Infra.App.Repositories
{
    public interface IProductStockRepository : IRepository
    {
        public Task<ProductStockEntity> GetByProductId(int productId);

        public Task Update(ProductStockEntity entity);

    }
}
