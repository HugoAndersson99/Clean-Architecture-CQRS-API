
using Domain;
using MediatR;
using Infrastructure.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.Books.AddBook
{
    public class AddBookCommandHandler : IRequestHandler<AddBookCommand, List<Book>>
    {
        private readonly FakeDatabase _database;

        public AddBookCommandHandler(FakeDatabase database)
        {
            _database = database;
        }

      // public Task<List<Book>> Handle(AddBookCommand request, CancellationToken cancellationToken)
      // {
      //     _database.Books.Add(request.newBook);
      //     return Task.FromResult(_database.Books);
      // }
        public Task<List<Book>> Handle(AddBookCommand request, CancellationToken cancellationToken)
        {
            // Kontrollera om request eller newBook är null
            if (request == null)
                throw new ArgumentNullException(nameof(request));
            if (request.newBook == null)
                throw new ArgumentNullException(nameof(request.newBook));

            Book newBook = request.newBook;

            // Kontrollera om boken redan finns i databasen (baserat på ID eller annan unik identifierare om tillämpligt)
            if (_database.Books.Any(book => book.Id == newBook.Id))
                throw new InvalidOperationException($"A book with Id {newBook.Id} already exists.");

            // Hantera författaren
            if (newBook.Author != null)
            {
                // Kontrollera om författaren redan finns
                var existingAuthor = _database.Authors.FirstOrDefault(a => a.Id == newBook.Author.Id);

                if (existingAuthor == null)
                {
                    // Om författaren inte finns, lägg till den i databasen
                    existingAuthor = newBook.Author;
                    existingAuthor.Id = _database.Authors.Any() ? _database.Authors.Max(a => a.Id) + 1 : 1;
                    _database.Authors.Add(existingAuthor);
                }

                // Lägg till boken i författarens boklista om den inte redan finns där
                if (!existingAuthor.Books.Contains(newBook))
                {
                    existingAuthor.Books.Add(newBook);
                }

                // Koppla boken till författaren
                newBook.Author = existingAuthor;
            }

            // Generera ett nytt ID för boken om det behövs
            newBook.Id = _database.Books.Any() ? _database.Books.Max(b => b.Id) + 1 : 1;

            // Lägg till boken i databasen
            _database.Books.Add(newBook);

            // Returnera uppdaterad lista av böcker
            return Task.FromResult(_database.Books);
        }
    }
}
