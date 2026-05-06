using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AEC.ESoft.Infra.App.Domain.Entities;
using AEC.Core.Data;

namespace AEC.ESoft.Infra.App.Repositories
{
    public interface ICategoryRepository : IRepository
    {
        public Task<List<CategoryEntity>> GetAllCategory();
        public Task<CategoryEntity> GetCategoryById(int id);
    }
}
