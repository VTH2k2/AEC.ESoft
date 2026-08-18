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
        // Thêm danh mục mới
        public async Task<CategoryEntity> AddCategoryAsync(CategoryEntity category, CancellationToken cancellationToken)
        {
            _context.Categories.AddAsync(category);
            await _context.SaveChangesAsync(cancellationToken);
            return category;
        }

        public async Task<bool> DeleteCategory(int id, CancellationToken cancellationToken)
        {
            var category = _context.Categories.FirstOrDefault(x => x.Id == id);
            if (category == null) return false;
            else
            {
                _context.Categories.Remove(category);
                await _context.SaveChangesAsync(cancellationToken);
                return true;
            }
        }

        public async Task<List<CategoryEntity>> GetAllCategory()
        {
            return await _context.Categories.ToListAsync();
        }

        public async Task<CategoryEntity> GetCategoryById(int id)
        {
            return await _context.Categories.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<CategoryEntity> UpdateCategoryAsync(CategoryEntity category, CancellationToken cancellationToken)
        {
            var existingCategory = await _context.Categories.FirstOrDefaultAsync(x => x.Id == category.Id);
            if (existingCategory == null) return null;
            _context.Entry(existingCategory).CurrentValues.SetValues(category);
            await _context.SaveChangesAsync(cancellationToken);
            return existingCategory;
        }
    }
}
