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
    public class SalesInvoiceItemService : ServicesBase, ISalesInvoiceItemService
    {
        private readonly ISalesInvoiceItemRepository _salesInvoiceItemRepository;

        public SalesInvoiceItemService(
            IServiceProvider serviceProvider,
            ISalesInvoiceItemRepository salesInvoiceItemRepository)
            : base(serviceProvider)
        {
            _salesInvoiceItemRepository = salesInvoiceItemRepository;
        }
        public async Task<List<SalesInvoiceItemsEntity>> GetByInvoiceId(int invoiceId)
        {
            return await _salesInvoiceItemRepository.GetByInvoiceId(invoiceId);
        }

        public async Task Update(SalesInvoiceItemsEntity entity)
        {
            await _salesInvoiceItemRepository.Update(entity);
        }
        
        public async Task Add(SalesInvoiceItemsEntity entity)
        {
            await _salesInvoiceItemRepository.Add(entity);
        }
    }
}
