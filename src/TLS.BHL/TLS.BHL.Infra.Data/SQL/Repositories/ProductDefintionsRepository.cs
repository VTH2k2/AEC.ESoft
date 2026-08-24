using AEC.ESoft.Infra.App.Domain.DTO;
using AEC.ESoft.Infra.App.Domain.Entities;
using AEC.ESoft.Infra.App.Repositories;
using AEC.ESoft.Infra.Data.SQL.Contexts;
using AEC.Lib.Data.SQL;
using Azure.Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace AEC.ESoft.Infra.Data.SQL.Repositories
{
    public class ProductDefintionsRepository : RepositoryBase<ProductDefintionsRepository>, IProductDefintionsRepository
    {
        private readonly ESoftSqlDbContext _context;
        public ProductDefintionsRepository(IServiceProvider serviceProvider, ESoftSqlDbContext context) : base(serviceProvider)
        {
            _context = context;
        }
        // Phương thức tạo SKU ngẫu nhiên
        public static class SkuGenerator
        {
            private const string Characters = "ABCDEFGHJKLMNPQRSTUVWXYZ23456789";

            public static string Generate(int length = 10)
            {
                char[] result = new char[length];

                for (int i = 0; i < length; i++)
                {
                    int index = RandomNumberGenerator.GetInt32(Characters.Length);
                    result[i] = Characters[index];
                }

                return new string(result);
            }
        }
        public async Task<ProductDTO> CreateProduct(CreateProductInput input, CancellationToken cancellationToken)
        {
            // Bắt đầu transaction
            // Cơ chế transaction sẽ giúp đảm bảo rằng tất cả các bước trong quá trình tạo sản phẩm đều thành công hoặc không có gì thay đổi nếu có lỗi xảy ra.
            await using var transaction = await _context.Database.BeginTransactionAsync();
            try
            {
                // 1. Kiểm tra xem CategoryId có tồn tại trong bảng Categories hay không
                var category = await _context.Categories.FindAsync(input.CategoryId);
                if (category == null) return null;
                // 2. Tạo SKU
                string sku;
                do
                {
                    sku = SkuGenerator.Generate();
                }
                while (await _context.ProductDefinitions.AnyAsync(p => p.Sku == sku));
                // 3. Tạo ProductDefinitions
                var productDefinition = new ProductDefinitionsEntity
                {
                    CategoryId = input.CategoryId,
                    Sku = sku,
                    ProductName = input.ProductName,
                    Unit = input.Unit,
                    HasDocument = (bool)input.HasDocument,
                    CreatedAt = DateTime.Now
                };
                _context.ProductDefinitions.Add(productDefinition);
                await _context.SaveChangesAsync(cancellationToken);
                // 4. Xử lý Quantity
                int quantityMain = 0;
                int quantitySub = 0;
                if (input.HasDocument == true)
                {
                    quantityMain = (int)input.Quantity;
                }
                else quantitySub = (int)input.Quantity;
                // 5. Tạo ProductStocks
                var productStock = new ProductStockEntity
                {
                    ProductId = productDefinition.Id,
                    QuantityMain = quantityMain,
                    QuantitySub = quantitySub,
                    ImportPrice = (decimal)input.ImportPrice,
                    SellPrice = (decimal)input.SellPrice
                };
                _context.ProductStocks.Add(productStock);
                await _context.SaveChangesAsync(cancellationToken);
                // 6. Commit transaction
                await transaction.CommitAsync();
                // 7. Trả về ProductDTO
                return await GetProductById(productDefinition.Id);
            } 
            catch
            {
                // Rollback transaction nếu có lỗi xảy ra
                await transaction.RollbackAsync(); 
                throw;
            }
        }

        public async Task<bool> DeleteProduct(int id, CancellationToken cancellationToken)
        {
            // Kiểm tra ProductDefinition tồn tại
            var product = await _context.ProductDefinitions.FindAsync(id);
            if (product == null) return false;
            // Kiểm tra ProductStock tồn tại
            var stock = await _context.ProductStocks.FirstOrDefaultAsync(ps => ps.ProductId == id);
            if (stock == null) return false;
            // Xóa ProductDefinition và ProductStock
            _context.ProductDefinitions.Remove(product);
            _context.ProductStocks.Remove(stock);
            await _context.SaveChangesAsync(cancellationToken);
            return true;
        }

        public async Task<List<ProductListDTO>> GetAllProduct()
        {
            var query = from p in _context.ProductDefinitions
                        join c in _context.Categories on p.CategoryId equals c.Id into cateJoin
                        from c in cateJoin.DefaultIfEmpty()
                        select new ProductListDTO
                        {
                            Id = p.Id,
                            CategoryId = (int)p.CategoryId,
                            CategoryName = c.Name,
                            Sku = p.Sku,
                            ProductName = p.ProductName,
                        };
            return await query.ToListAsync();
        }

        public async Task<List<ProductDefinitionsEntity>> GetAllProductDefintions()
        {
            return await _context.ProductDefinitions
                .AsNoTracking()
                .OrderBy(x => x.Id)
                .ToListAsync();
        }

        public async Task<ProductDTO> GetProductById(int id)
        {
            var query = from p in _context.ProductDefinitions
                        join c in _context.Categories on p.CategoryId equals c.Id into cateJoin
                        from c in cateJoin.DefaultIfEmpty()
                        join ps in _context.ProductStocks on p.Id equals ps.ProductId into psJoin
                        from ps in psJoin.DefaultIfEmpty()
                        select new ProductDTO
                        {
                            Id = p.Id,
                            CategoryId = (int)p.CategoryId,
                            CategoryName = c.Name,
                            Sku = p.Sku,
                            ProductName = p.ProductName,
                            Unit = p.Unit,
                            HasDocument = p.HasDocument,
                            Quantity = ps != null ? ps.QuantityMain : ps.QuantitySub,
                            ImportPrice = ps != null ? ps.ImportPrice : 0,
                            SellPrice = ps != null ? ps.SellPrice : 0
                        };
            return await query.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<ProductDefinitionsEntity> GetProductDefintionsById(int id)
        {
            return await _context.ProductDefinitions
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<ProductDTO> UpdateProduct(UpdateProductInput input, CancellationToken cancellationToken)
        {
            // Bắt đầu transaction
            await using var transaction = await _context.Database.BeginTransactionAsync();
            try
            {
                // Kiểm tra ProductDefinition tồn tại
                var product = await _context.ProductDefinitions.FindAsync(input.Id);
                if (product == null) return null;
                // Kiểm tra ProductStock tồn tại
                var stock = await _context.ProductStocks.FirstOrDefaultAsync(ps => ps.ProductId == input.Id);
                if (stock == null) return null;
                // Kiểm tra Category tồn tại
                var category = await _context.Categories.FindAsync(input.CategoryId);
                if (category == null) return null;
                // Cập nhật ProductDefinition
                product.CategoryId = input.CategoryId;
                product.ProductName = input.ProductName;
                product.Unit = input.Unit;
                product.HasDocument = (bool)input.HasDocument;
                //_context.ProductDefinitions.Update(product);
                await _context.SaveChangesAsync(cancellationToken);
                // Cập nhật ProductStock
                if (product.HasDocument == true)
                {
                    stock.QuantityMain = (int)input.Quantity;
                    stock.QuantitySub = 0;

                }
                else
                {
                    stock.QuantitySub = (int)input.Quantity;
                    stock.QuantityMain = 0;
                }
                stock.ImportPrice = (decimal)input.ImportPrice;
                stock.SellPrice = (decimal)input.SellPrice;
                stock.UpdatedAt = DateTime.Now;
                //_context.ProductStocks.Update(stock);
                await _context.SaveChangesAsync(cancellationToken);
                // Commit transaction
                await transaction.CommitAsync();
                // Trả về ProductDTO
                return await GetProductById(product.Id);
            }
            catch
            {
                // Rollback transaction nếu có lỗi xảy ra
                await transaction.RollbackAsync();
                throw;
            }
            
        }
    }
}
