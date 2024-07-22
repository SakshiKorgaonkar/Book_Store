using MediatR;
using Repository_Layer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Commands.Book
{
    public class RemoveBookByIdRequest : IRequest<BookEntity>
    {
        public int Id { get; set; }
    }
}
