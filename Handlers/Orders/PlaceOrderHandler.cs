using Book_Store.Controllers;
using MediatR;
using Model_Layer;
using Repository_Layer.Entity;
using Repository_Layer.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Handlers.Orders
{
    public class PlaceOrderHandler:IRequestHandler<PlaceOrderRequest,List<OrdersEntity>>
    {
        private readonly IOrderRL orderRL;
        public PlaceOrderHandler(IOrderRL orderRL)
        {
            this.orderRL = orderRL;
        }

        public async Task<List<OrdersEntity>> Handle(PlaceOrderRequest request, CancellationToken cancellationToken)
        {
            var result = new OrdersML
            {
                CustomerDetailId = request.CustomerDetailId,
            };
            return await orderRL.PlaceOrder(request.Id, result);
        }
    }
}
