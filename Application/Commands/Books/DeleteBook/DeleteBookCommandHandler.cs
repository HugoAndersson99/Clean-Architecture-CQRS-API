using Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.Books.DeleteBook
{
    public class DeleteBookCommandHandler : IRequestHandler<DeleteBookCommand>
    {
        private readonly IBookRepository _bookRepository;

        public DeleteBookCommandHandler(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }


      // public Task<Unit> Handle(DeleteBookCommand request, CancellationToken cancellationToken)
      // {
      //     // Verifiera att boken finns
      //     var book = _bookRepository.GetById(request.Id);
      //     if (book == null)
      //     {
      //         throw new KeyNotFoundException($"Book with ID {request.Id} not found.");
      //     }
      //
      //     // Ta bort boken
      //     _bookRepository.Delete(request.Id);
      //
      //     // Returnera Task som innehåller Unit.Value
      //     return Task.FromResult(Unit.Value);
      // }

        Task IRequestHandler<DeleteBookCommand>.Handle(DeleteBookCommand request, CancellationToken cancellationToken)
        {
            // Kontrollera om boken finns
            var book = _bookRepository.GetById(request.Id);
            if (book == null)
            {
                throw new KeyNotFoundException($"Book with ID {request.Id} not found.");
            }

            // Ta bort boken
            _bookRepository.Delete(request.Id);

            // Returnera Task som indikerar att operationen är klar
            return Task.FromResult(Unit.Value);
        }
    }
}
