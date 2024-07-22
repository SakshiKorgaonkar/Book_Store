using MediatR;
using Repository_Layer.Entity;

namespace Book_Store.Controllers
{
    public class GetOrdersRequest : IRequest<List<OrdersEntity>>
    {
        public int Id { get; set; }
    }
}