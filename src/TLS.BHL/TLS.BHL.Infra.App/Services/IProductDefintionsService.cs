using AEC.Core.Service;
using AEC.ESoft.Infra.App.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AEC.ESoft.Infra.App.Services
{
    public interface IProductDefintionsService : IService
    {
        public Task<List<ProductDefinitionsEntity>> GetAllProductDefintions();
        
        public Task<ProductDefinitionsEntity> GetProductDefintionsById(int id);
    }
}
