using AEC.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AEC.ESoft.Infra.App.Domain.Entities;
using AEC.ESoft.Infra.App.Domain.DTO;

namespace AEC.ESoft.Infra.App.Repositories
{
    public interface IProductDefintionsRepository : IRepository
    {
        public Task<List<ProductDefinitionsEntity>> GetAllProductDefintions();
        public Task<ProductDefinitionsEntity> GetProductDefintionsById(int id);// gọi by id 
        public Task<List<ProductListDTO>> GetAllProduct();
        public Task<ProductDTO> GetProductById(int id);
        public Task<ProductDTO> CreateProduct(CreateProductInput input, CancellationToken cancellationToken);
        public Task<ProductDTO> UpdateProduct(UpdateProductInput input, CancellationToken cancellationToken);
        public Task<bool>DeleteProduct(int id, CancellationToken cancellationToken);

    }
}
