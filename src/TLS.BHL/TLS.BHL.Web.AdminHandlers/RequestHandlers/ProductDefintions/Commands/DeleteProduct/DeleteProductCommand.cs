using AEC.ESoft.Infra.App.Domain.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AEC.ESoft.Web.AdminHandlers.RequestHandlers.ProductDefintions.Commands.DeleteProduct
{
    public class DeleteProductCommand : IRequest<ApiResponse<bool>>
    {
        public DeleteProductCommand(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
