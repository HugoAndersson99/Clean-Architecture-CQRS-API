using Domain;
using Infrastructure.Database;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.Books.GetById
{
    public class GetBookByIdQueryHandler : IRequestHandler<GetBookByIdQuery, Book>
    {
        private readonly FakeDatabase _database;

        public GetBookByIdQueryHandler(FakeDatabase database)
        {
            _database = database;
        }

        public Task<Book> Handle(GetBookByIdQuery request, CancellationToken cancellationToken)
        {
            // Validera att ID är giltigt
            if (request.Id <= 0)
            {
                throw new ArgumentException("Id must be greater than 0.", nameof(request.Id));
            }

            // Hämta boken från databasen
            Book requestedBook = _database.Books.FirstOrDefault(book => book.Id == request.Id);

            // Kontrollera om boken existerar
            if (requestedBook == null)
            {
                throw new KeyNotFoundException($"Book with Id {request.Id} not found.");
            }

            // Returnera boken
            return Task.FromResult(requestedBook);
        }
    }
}
