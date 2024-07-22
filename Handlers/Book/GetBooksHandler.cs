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
    public class GetBooksHandler : IRequestHandler<GetBooksRequest, List<BookEntity>>
    {
        private readonly IBookRL bookRL;

        public GetBooksHandler(IBookRL bookRL)
        {
            this.bookRL = bookRL;
        }
        public async Task<List<BookEntity>> Handle(GetBooksRequest request, CancellationToken cancellationToken)
        {
            return await bookRL.GetBooks();
        }
    }
}
