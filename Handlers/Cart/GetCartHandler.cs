using Book_Store.Controllers;
using MediatR;
using Repository_Layer.Entity;
using Repository_Layer.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Handlers.Cart
{
    public class GetCartHandler : IRequestHandler<GetCartRequest, List<CartEntity>>
    {
        private readonly ICartRL cartRL;

        public GetCartHandler(ICartRL cartRL)
        {
            this.cartRL = cartRL;
        }
        public async Task<List<CartEntity>> Handle(GetCartRequest request, CancellationToken cancellationToken)
        {
            return await cartRL.GetCart(request.Id);
        }
    }
}
