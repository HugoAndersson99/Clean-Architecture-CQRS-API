
using Domain;
using Infrastructure.Database;
using MediatR;

namespace Application.Queries.Authors.GetAuthorById
{
    public class GetAuthorByIdQueryHandler : IRequestHandler<GetAuthorByIdQuery, Author>
    {
        private readonly FakeDatabase _database;

        public GetAuthorByIdQueryHandler(FakeDatabase database)
        {
            _database = database;
        }

        public Task<Author> Handle(GetAuthorByIdQuery request, CancellationToken cancellationToken)
        {
            // Validera att ID är giltigt
            if (request.Id <= 0)
            {
                throw new ArgumentException("Id must be greater than 0.", nameof(request.Id));
            }

            // Hämta författaren från databasen
            Author requestedAuthor = _database.Authors.FirstOrDefault(author => author.Id == request.Id);

            // Kontrollera om författaren existerar
            if (requestedAuthor == null)
            {
                throw new KeyNotFoundException($"Author with Id {request.Id} not found.");
            }

            // Returnera boken
            return Task.FromResult(requestedAuthor);
        }
    }
}
