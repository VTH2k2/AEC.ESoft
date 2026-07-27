using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AEC.ESoft.Infra.App.Domain.Entities;
using AEC.ESoft.Infra.App.Repositories;
using AEC.ESoft.Infra.Data.SQL.Contexts;
using AEC.Lib.Data.SQL;
using Microsoft.EntityFrameworkCore;

namespace AEC.ESoft.Infra.Data.SQL.Repositories
{
    public class ProductStockRepository
         : RepositoryBase<ProductStockRepository>,
           IProductStockRepository
    {
        private readonly ESoftSqlDbContext _context;

        public ProductStockRepository(
            IServiceProvider serviceProvider,
            ESoftSqlDbContext context)
            : base(serviceProvider)
        {
            _context = context;
        }

        public async Task<ProductStockEntity> GetByProductId(int productId)
        {
            return await _context.ProductStocks
                .FirstOrDefaultAsync(x => x.ProductId == productId);
        }

        public async Task Update(ProductStockEntity entity)
        {
            _context.ProductStocks.Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}
