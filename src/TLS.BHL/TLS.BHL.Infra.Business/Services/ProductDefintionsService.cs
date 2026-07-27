using AEC.Core.Service;
using AEC.ESoft.Infra.App.Domain.Entities;
using AEC.ESoft.Infra.App.Repositories;
using AEC.ESoft.Infra.App.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AEC.ESoft.Infra.Business.Services
{
    public class ProductDefintionsService : ServiceBase , IProductDefintionsService
    {
        private readonly IProductDefintionsRepository _productDefintionRepostitory;
        public ProductDefintionsService(IServiceProvider serviceProvider, IProductDefintionsRepository productDefintionRepostitory) : base(serviceProvider)
        {
            _productDefintionRepostitory = productDefintionRepostitory;
        }

        public async Task<List<ProductDefinitionsEntity>> GetAllProductDefintions()
        {
            return await _productDefintionRepostitory.GetAllProductDefintions();
        }

        public async Task<ProductDefinitionsEntity> GetProductDefintionsById(int id)
        {
            return await _productDefintionRepostitory.GetProductDefintionsById(id);
        }
    }
}
