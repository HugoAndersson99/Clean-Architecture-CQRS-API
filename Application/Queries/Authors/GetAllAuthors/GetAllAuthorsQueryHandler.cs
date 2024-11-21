using Domain;
using Infrastructure.Database;
using MediatR;

namespace Application.Queries.Authors.GetAllAuthors
{
    public class GetAllAuthorsQueryHandler : IRequestHandler<GetAllAuthorsQuery, List<Author>>
    {
        private readonly FakeDatabase _database;

        public GetAllAuthorsQueryHandler(FakeDatabase database)
        {
            _database = database;
        }

        public Task<List<Author>> Handle(GetAllAuthorsQuery request, CancellationToken cancellationToken)
        {
            // Kontrollera om databasen innehåller några författare
            if (_database.Authors == null || _database.Authors.Count == 0)
            {
                throw new InvalidOperationException("No authors found in the database.");
            }

            // Hämta böcker från databasen
            List<Author> authorsFromDB = _database.Authors;

            // Returnera resultat
            return Task.FromResult(authorsFromDB);
        }
    }
}
