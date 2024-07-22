using Book_Store.Controllers;
using MediatR;
using Repository_Layer.Entity;
using Repository_Layer.Interface;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Handlers.Details
{
    public class DeleteDetailsHandler : IRequestHandler<DeleteDetailsRequest, CustomerDetailsEntity>
    {
        private readonly ICustomerDetailsRL _customerDetailsRL;
        public DeleteDetailsHandler(ICustomerDetailsRL customerDetailsRL)
        {
            _customerDetailsRL = customerDetailsRL;
        }
        public async Task<CustomerDetailsEntity> Handle(DeleteDetailsRequest request, CancellationToken cancellationToken)
        {
            return await _customerDetailsRL.DeleteCustomerDetails(request.UserId, request.Type);
        }
    }
}
