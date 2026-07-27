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
    public class SalesInvoiceService : ServiceBase, ISalesInvoiceService
    {
        private readonly ISalesInvoiceRepository _salesInvoiceRepository;
        public SalesInvoiceService(IServiceProvider serviceProvider, ISalesInvoiceRepository salesInvoiceRepository) : base(serviceProvider)
        {
            _salesInvoiceRepository = salesInvoiceRepository;           
        }

        public async Task<int> Create(SalesInvoiceEntity entity)
        {
            return await _salesInvoiceRepository.Create(entity);
        }

        public async  Task<SalesInvoiceEntity> GetById(int id)
        {
            return await _salesInvoiceRepository.GetById(id);
        }

        public async Task Update(SalesInvoiceEntity entity)
        {
            await _salesInvoiceRepository.Update(entity);
        }

       

      
    }
}

