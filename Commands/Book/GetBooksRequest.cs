using MediatR;
using Repository_Layer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Commands.Book
{
    public class GetBooksRequest:IRequest<List<BookEntity>>
    {
    }
}
