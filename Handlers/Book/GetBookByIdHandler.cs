using Commands.Book;
using MediatR;
using Repository_Layer.Entity;
using Repository_Layer.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Handlers.Book
{
    public class GetBookByIdHandler : IRequestHandler<GetBookByIdRequest, BookEntity>
    {
        private readonly IBookRL bookRL;
        public GetBookByIdHandler(IBookRL bookRL)
        {
            this.bookRL = bookRL;
        }
        public async Task<BookEntity> Handle(GetBookByIdRequest request, CancellationToken cancellationToken)
        {
            return await bookRL.GetBookById(request.Id);
        }
    }
}
