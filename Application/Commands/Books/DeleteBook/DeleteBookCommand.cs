using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.Books.DeleteBook
{
    public class DeleteBookCommand : IRequest
    {
        public Guid Id { get; set; }
    }
}
