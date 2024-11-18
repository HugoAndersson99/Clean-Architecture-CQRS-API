using Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.Books.UpdateBook
{
    public class UpdateBookCommandHandler : IRequestHandler<UpdateBookCommand>
    {
        private readonly IBookRepository _bookRepository;

        public UpdateBookCommandHandler(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

       // public async Task<Unit> Handle(UpdateBookCommand request, CancellationToken cancellationToken)
       // {
       //     var book = _bookRepository.GetById(request.Id);
       //     book.Title = request.Title;
       //     book.AuthorId = request.AuthorId;
       //     _bookRepository.Update(book);
       //     return Unit.Value;
       // }

        
        Task IRequestHandler<UpdateBookCommand>.Handle(UpdateBookCommand request, CancellationToken cancellationToken)
        {
            // Hämta boken från databasen
            var book = _bookRepository.GetById(request.Id);
            if (book == null)
            {
                throw new KeyNotFoundException($"Book with ID {request.Id} not found.");
            }

            // Uppdatera bokens egenskaper
            book.Title = request.Title;
            book.Description = request.Description;
            book.AuthorId = request.AuthorId;

            // Spara ändringar
            _bookRepository.Update(book);

            // Returnera Task som signalerar att operationen är klar
            return Task.FromResult(Unit.Value);
        }
    }
}
