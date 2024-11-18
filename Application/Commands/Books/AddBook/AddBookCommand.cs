using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace Application.Commands.Books.AddBook
{
    public class AddBookCommand : IRequest<Guid>
    {
        public string Title { get; set; }
        public Guid AuthorId { get; set; }
    }
}
