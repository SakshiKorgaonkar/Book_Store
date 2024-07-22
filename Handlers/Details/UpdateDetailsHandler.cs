using Book_Store.Controllers;
using MediatR;
using Repository_Layer.Entity;
using Repository_Layer.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Handlers.Details
{
    public class UpdateDetailsHandler : IRequestHandler<UpdateDetailsRequest, CustomerDetailsEntity>
    {
        private readonly ICustomerDetailsRL customerDetailsRL;
        public UpdateDetailsHandler(ICustomerDetailsRL customerDetailsRL)
        {
            this.customerDetailsRL = customerDetailsRL;
        }

        public async Task<CustomerDetailsEntity> Handle(UpdateDetailsRequest request, CancellationToken cancellationToken)
        {
            var result = new CustomerDetailsML
            {
                Address = request.Address,
                City = request.City,
                State = request.State,
                AddressType = request.AddressType,
            };
            return await customerDetailsRL.UpdateCustomerDetails(request.UserId, result);
        }
    }
}
