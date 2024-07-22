using Book_Store.Controllers;
using MediatR;
using Microsoft.AspNetCore.Components.Forms;
using Repository_Layer.Entity;
using Repository_Layer.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Handlers.Details
{
    public class GetDetailsHandler : IRequestHandler<GetDetailsRequest, List<CustomerDetailsEntity>>
    {
        private readonly ICustomerDetailsRL customerDetailsRL;
        public GetDetailsHandler(ICustomerDetailsRL customerDetailsRL)
        {
            this.customerDetailsRL = customerDetailsRL;
        }

        public async Task<List<CustomerDetailsEntity>> Handle(GetDetailsRequest request, CancellationToken cancellationToken)
        {
            return await customerDetailsRL.GetCustomerDetails(request.Id);
        }
    }
}
