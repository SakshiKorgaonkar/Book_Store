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
    public class RemoveBookByIdHandler : IRequestHandler<RemoveBookByIdRequest, BookEntity>
    {
        private readonly IBookRL bookRL;
        public RemoveBookByIdHandler(IBookRL bookRL)
        {
            this.bookRL = bookRL;
        }
        public async Task<BookEntity> Handle(RemoveBookByIdRequest request, CancellationToken cancellationToken)
        {
            return await bookRL.RemoveBookById(request.Id);
        }
    }
}
