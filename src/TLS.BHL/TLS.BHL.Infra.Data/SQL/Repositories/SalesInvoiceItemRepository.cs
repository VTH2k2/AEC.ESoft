using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AEC.ESoft.Infra.App.Domain.Entities;
using AEC.ESoft.Infra.App.Repositories;
using AEC.ESoft.Infra.Data.SQL.Contexts;
using AEC.Lib.Data.SQL;
using Microsoft.EntityFrameworkCore;


namespace AEC.ESoft.Infra.Data.SQL.Repositories
{
    public class SalesInvoiceItemRepository
        : RepositoryBase<SalesInvoiceItemRepository>,
          ISalesInvoiceItemRepository
    {
        private readonly ESoftSqlDbContext _context;

        public SalesInvoiceItemRepository(
            IServiceProvider serviceProvider,
            ESoftSqlDbContext context)
            : base(serviceProvider)
        {
            _context = context;
        }

        public async Task Add(SalesInvoiceItemsEntity entity)
        {
            await _context.SalesInvoiceItems.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<List<SalesInvoiceItemsEntity>> GetByInvoiceId(int invoiceId)
        {
            return await _context.SalesInvoiceItems
                .Where(x => x.InvoiceId == invoiceId)
                .ToListAsync();
        }
        public async Task Update(SalesInvoiceItemsEntity entity)
        {
            _context.SalesInvoiceItems.Update(entity);

            await _context.SaveChangesAsync();

        }
    }
}
