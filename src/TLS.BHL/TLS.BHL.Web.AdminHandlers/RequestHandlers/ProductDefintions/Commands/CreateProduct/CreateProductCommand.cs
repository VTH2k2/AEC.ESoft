using AEC.ESoft.Infra.App.Domain.Common;
using AEC.ESoft.Infra.App.Domain.DTO;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AEC.ESoft.Web.AdminHandlers.RequestHandlers.ProductDefintions.Commands.CreateProduct
{
    public class CreateProductCommand : IRequest<ApiResponse<ProductDTO>>
    {
        public CreateProductCommand(CreateProductInput product)
        {
            Product = product;
        }

        public CreateProductInput Product { get; }
    }
}
