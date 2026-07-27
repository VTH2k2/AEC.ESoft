using AEC.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AEC.ESoft.Infra.App.Domain.Entities;

namespace AEC.ESoft.Infra.App.Repositories
{
    public interface IProductDefintionsRepository : IRepository
    {
        public Task<List<ProductDefinitionsEntity>> GetAllProductDefintions();

        public Task<ProductDefinitionsEntity> GetProductDefintionsById(int id);// gọi by id 

    }
}
