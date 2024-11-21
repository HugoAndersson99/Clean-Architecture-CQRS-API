using Domain;
using Infrastructure.Database;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.Books.GetAll
{
    public class GetAllBooksQueryHandler : IRequestHandler<GetAllBooksQuery, List<Book>>
    {
        private readonly FakeDatabase _database;

        public GetAllBooksQueryHandler(FakeDatabase database)
        {
            _database = database;
        }

        
        public Task<List<Book>> Handle(GetAllBooksQuery request, CancellationToken cancellationToken)
        {
            // Kontrollera om databasen innehåller några böcker
            if (_database.Books == null || !_database.Books.Any())
            {
                throw new InvalidOperationException("No books found in the database.");
            }

            // Hämta böcker från databasen
            List<Book> booksFromDB = _database.Books;

            // Returnera resultat
            return Task.FromResult(booksFromDB);
        }
    }
}
