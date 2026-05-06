using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AEC.ESoft.Infra.App.Domain.Entities;
using AEC.ESoft.Infra.App.Repositories;
using AEC.ESoft.Infra.Data.SQL.Contexts;
using AEC.Lib.Data.SQL;

namespace AEC.ESoft.Infra.Data.SQL.Repositories
{
    public class CategoryRepository : RepositoryBase<CategoryRepository>, ICategoryRepository
    {
        private readonly ESoftSqlDbContext _context;
        public CategoryRepository(IServiceProvider serviceProvider, ESoftSqlDbContext context) : base(serviceProvider)
        {
            _context = context;
        }

        public async Task<List<CategoryEntity>> GetAllCategory()
        {
            return await _context.Categories.ToListAsync();
        }

        public async Task<CategoryEntity> GetCategoryById(int id)
        {
            return await _context.Categories.FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
