using Commands.Book;
using MediatR;
using Model_Layer;
using Repository_Layer.Entity;
using Repository_Layer.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Handlers.Book
{
    public class UpdateBookByIdRequestHandler : IRequestHandler<UpdateBookByIdRequest, BookEntity>
    {
        private readonly IBookRL bookRL;

        public UpdateBookByIdRequestHandler(IBookRL bookRL)
        {
            this.bookRL = bookRL;
        }
        public async Task<BookEntity> Handle(UpdateBookByIdRequest request, CancellationToken cancellationToken)
        {
            var result = new BookML
            {
                Name = request.Name,
                Description = request.Description,
                Price = request.Price,
                DiscountedPrice = request.DiscountedPrice,
                Author = request.Author,
                Quantity = request.Quantity,
                Image = request.Image,
            };
            return await bookRL.UpdateBookById(request.BookId,result,request.AdminId);
        }
    }
}
