using AEC.ESoft.Infra.App.Domain.Common;
using AEC.ESoft.Infra.App.Domain.DTO;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AEC.ESoft.Web.AdminHandlers.RequestHandlers.ProductDefintions.Commands.UpdateProduct
{
    public class UpdateProductCommand : IRequest<ApiResponse<ProductDTO>>
    {
        public UpdateProductCommand(UpdateProductInput product)
        {
            Product = product;
        }

        public UpdateProductInput Product { get; set; }
    }
}
