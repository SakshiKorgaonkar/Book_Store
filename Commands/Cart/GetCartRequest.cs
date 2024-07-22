using MediatR;
using Repository_Layer.Entity;

namespace Book_Store.Controllers
{
    public class GetCartRequest : IRequest<List<CartEntity>>
    {
        public int Id { get; set; }
    }
}