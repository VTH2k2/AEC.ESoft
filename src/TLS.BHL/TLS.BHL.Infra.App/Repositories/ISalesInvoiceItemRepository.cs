using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AEC.Core.Data;
using AEC.ESoft.Infra.App.Domain.Entities;

namespace AEC.ESoft.Infra.App.Repositories
{
    public  interface ISalesInvoiceItemRepository : IRepository
    {
        public Task<List<SalesInvoiceItemsEntity>> GetByInvoiceId(int invoiceId);

        public Task Update(SalesInvoiceItemsEntity entity);

        public Task Add(SalesInvoiceItemsEntity entity);
    }
}
