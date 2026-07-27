using AEC.Core.Service;
using AEC.ESoft.Infra.App.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AEC.ESoft.Infra.App.Services
{
    public interface ISalesInvoiceService : IService
    {
         public Task<SalesInvoiceEntity>GetById(int id);

        public Task Update(SalesInvoiceEntity entity);

        public Task<int> Create(SalesInvoiceEntity entity);

    }
}
