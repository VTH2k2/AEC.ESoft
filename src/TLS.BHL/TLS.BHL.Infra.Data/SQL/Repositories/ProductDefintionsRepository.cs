using AEC.ESoft.Infra.App.Domain.Entities;
using AEC.ESoft.Infra.App.Repositories;
using AEC.ESoft.Infra.Data.SQL.Contexts;
using AEC.Lib.Data.SQL;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AEC.ESoft.Infra.Data.SQL.Repositories
{
    public class ProductDefintionsRepository : RepositoryBase<ProductDefintionsRepository>, IProductDefintionsRepository
    {
        private readonly ESoftSqlDbContext _context;
        public ProductDefintionsRepository(IServiceProvider serviceProvider, ESoftSqlDbContext context) : base(serviceProvider)
        {
            _context = context;
        }

        public async Task<List<ProductDefinitionsEntity>> GetAllProductDefintions()
        {
            return await _context.ProductDefinitions
                .AsNoTracking()
                .OrderBy(x => x.Id)
                .ToListAsync();
        }

        public async Task<ProductDefinitionsEntity> GetProductDefintionsById(int id)
        {
            return await _context.ProductDefinitions
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
