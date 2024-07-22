using Book_Store.Controllers;
using MediatR;
using Repository_Layer.Entity;
using Repository_Layer.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Handlers.Orders
{
    public class GetOrderHandler : IRequestHandler<GetOrdersRequest, List<OrdersEntity>>
    {
        private readonly IOrderRL orderRL;
        public GetOrderHandler(IOrderRL orderRL)
        {
            this.orderRL = orderRL;
        }

        public async Task<List<OrdersEntity>> Handle(GetOrdersRequest request, CancellationToken cancellationToken)
        {
            return await orderRL.GetOrder(request.Id);
        }
    }
}
