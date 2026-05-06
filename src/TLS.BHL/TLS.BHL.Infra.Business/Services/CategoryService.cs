using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AEC.ESoft.Infra.App.Domain.Entities;
using AEC.ESoft.Infra.App.Repositories;
using AEC.ESoft.Infra.App.Services;
using AEC.Core.Service;

namespace AEC.ESoft.Infra.Business.Services
{
    public class CategoryService : ServiceBase, ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        public CategoryService(IServiceProvider serviceProvider, ICategoryRepository categoryRepository) : base(serviceProvider)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<List<CategoryEntity>> GetAllCategory()
        {
            return await _categoryRepository.GetAllCategory();
        }

        public async Task<CategoryEntity> GetCategoryById(int id)
        {
            return await _categoryRepository.GetCategoryById(id);
        }
    }
}
