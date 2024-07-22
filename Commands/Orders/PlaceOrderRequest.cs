using MediatR;
using Repository_Layer.Entity;

namespace Book_Store.Controllers
{
    public class PlaceOrderRequest : IRequest<List<OrdersEntity>>
    {
        public int CustomerDetailId {  get; set; }

        public PlaceOrderRequest(int customerDetailId)
        {
            this.CustomerDetailId = customerDetailId;
        }

        public int Id { get; set; }
    }
}