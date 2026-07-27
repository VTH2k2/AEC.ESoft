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
    public class SalesInvoiceRepository
        : RepositoryBase<SalesInvoiceRepository>,
          ISalesInvoiceRepository
    {
        private readonly ESoftSqlDbContext _context;

        public SalesInvoiceRepository(
             IServiceProvider serviceProvider,
             ESoftSqlDbContext context)
             : base(serviceProvider)
        {
            _context = context;
        }

        public async Task<int> Create(SalesInvoiceEntity entity)
        {
            _context.SalesInvoices.Add(entity);

            await _context.SaveChangesAsync();

            return entity.Id;
        }
        public async Task<SalesInvoiceEntity> GetById(int id)
        {
            return await _context.SalesInvoices
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task Update(SalesInvoiceEntity entity)
        {
            _context.SalesInvoices.Update(entity);

            await _context.SaveChangesAsync();
        }
    }
}
