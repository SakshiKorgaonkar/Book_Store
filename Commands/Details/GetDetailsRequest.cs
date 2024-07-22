using MediatR;
using Repository_Layer.Entity;

namespace Book_Store.Controllers
{
    public class GetDetailsRequest : IRequest<List<CustomerDetailsEntity>>
    {
        public int Id { get; set; }

        public GetDetailsRequest(int id)
        {
            Id= id;
        }
    }
}