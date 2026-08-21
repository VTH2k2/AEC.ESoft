using AEC.Core.Service;
using AEC.ESoft.Infra.App.Domain.DTO;
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
        public Task<ProductDefinitionsEntity> GetProductDefintionsById(int id);// gọi by id 
        public Task<List<ProductListDTO>> GetAllProduct();
        public Task<ProductDTO> GetProductById(int id);
        public Task<ProductDTO> CreateProduct(CreateProductInput input, CancellationToken cancellationToken);
        public Task<ProductDTO> UpdateProduct(UpdateProductInput input, CancellationToken cancellationToken);
        public Task<bool> DeleteProduct(int id, CancellationToken cancellationToken);
    }
}
