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
    public class AddBookHandler : IRequestHandler<AddBookRequest, BookEntity>
    {
        private readonly IBookRL bookRL;
        public AddBookHandler(IBookRL bookRL)
        {
            this.bookRL = bookRL;
        }

        public async Task<BookEntity> Handle(AddBookRequest request, CancellationToken cancellationToken)
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
            return await bookRL.AddBook(result,request.AdminId);
        }
    }
}
