using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AEC.Core.Data;
using AEC.ESoft.Infra.App.Domain.Entities;

namespace AEC.ESoft.Infra.App.Repositories
{
    public interface ISalesInvoiceRepository : IRepository
    {
        public Task<SalesInvoiceEntity> GetById(int id);
        
        public Task Update(SalesInvoiceEntity entity);

        public Task<int> Create(SalesInvoiceEntity entity);
    }
}

