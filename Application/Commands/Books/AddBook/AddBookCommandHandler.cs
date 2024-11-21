
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
            Book newBook = request.newBook;

            // Kontrollera om författaren redan finns
            if (newBook.Author != null)
            {
                var existingAuthor = _database.Authors.FirstOrDefault(a => a.Id == newBook.Author.Id);

                if (existingAuthor == null)
                {
                    // Om författaren inte finns, lägg till den i databasen
                    existingAuthor = newBook.Author;
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

            // Lägg till boken i databasen
            _database.Books.Add(newBook);

            // Returnera uppdaterad lista av böcker
            return Task.FromResult(_database.Books);
        }
    }
}
