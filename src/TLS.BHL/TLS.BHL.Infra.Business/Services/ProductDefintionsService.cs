using AEC.Core.Service;
using AEC.ESoft.Infra.App.Domain.DTO;
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

        public async Task<ProductDTO> CreateProduct(CreateProductInput input, CancellationToken cancellationToken)
        {
            return await _productDefintionRepostitory.CreateProduct(input, cancellationToken);
        }

        public async Task<bool> DeleteProduct(int id, CancellationToken cancellationToken)
        {
            return await _productDefintionRepostitory.DeleteProduct(id, cancellationToken);
        }

        public async Task<List<ProductListDTO>> GetAllProduct()
        {
            return await _productDefintionRepostitory.GetAllProduct();
        }

        public async Task<List<ProductDefinitionsEntity>> GetAllProductDefintions()
        {
            return await _productDefintionRepostitory.GetAllProductDefintions();
        }

        public async Task<ProductDTO> GetProductById(int id)
        {
            return await _productDefintionRepostitory.GetProductById(id);
        }

        public async Task<ProductDefinitionsEntity> GetProductDefintionsById(int id)
        {
            return await _productDefintionRepostitory.GetProductDefintionsById(id);
        }

        public async Task<ProductDTO> UpdateProduct(UpdateProductInput input, CancellationToken cancellationToken)
        {
            return await _productDefintionRepostitory.UpdateProduct(input, cancellationToken);
        }
    }
}
