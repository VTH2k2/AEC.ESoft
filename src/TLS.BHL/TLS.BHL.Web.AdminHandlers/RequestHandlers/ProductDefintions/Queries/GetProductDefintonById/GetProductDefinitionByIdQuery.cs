using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AEC.ESoft.Infra.App.Domain.Common;
using AEC.ESoft.Infra.App.Domain.DTO;
using MediatR;



namespace AEC.ESoft.Web.AdminHandlers.RequestHandlers.ProductDefintions.Queries.GetProductDefintonById
{
    public class GetProductDefinitionByIdQuery : IRequest<ApiResponse<ProductDefinitionsDTO>>
    {
        public int ID {  get; set; }

        public GetProductDefinitionByIdQuery(int id)
        {
            ID = id;
        }

    }
}
