using Application.Interfaces;
using Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.Books.AddBook
{
    public class AddBookCommandHandler : IRequestHandler<AddBookCommand, Guid>
    {
        private readonly IBookRepository _bookRepository;

        public AddBookCommandHandler(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task<Guid> Handle(AddBookCommand request, CancellationToken cancellationToken)
        {
            var book = new Book
            {
                Id = Guid.NewGuid(),
                Title = request.Title,
                AuthorId = request.AuthorId
            };
            _bookRepository.Add(book);
            return book.Id;
            //return _bookRepository.Add(book);
        }
    }
}
