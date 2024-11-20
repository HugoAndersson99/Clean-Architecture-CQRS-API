using Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.Books.UpdateBook
{
    public class UpdateBookByIdCommand : IRequest<List<Book>>
    {
        public UpdateBookByIdCommand(Book updatedBook, int id)
        {
            UpdatedBook = updatedBook;
            Id = id;
        }

        public Book UpdatedBook { get; }
        public int Id { get; }
    }
}
