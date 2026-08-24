using AEC.ESoft.Infra.App.Domain.Common;
using AEC.ESoft.Infra.App.Domain.DTO;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AEC.ESoft.Web.AdminHandlers.RequestHandlers.ProductDefintions.Queries.GetProductById
{
    public class GetProductByIdQuery : IRequest<ApiResponse<ProductDTO>>
    {
        public GetProductByIdQuery(int id)
        {
            Id = id;
        }

        public int Id { get; }
    }
}
