
using Domain;
using Infrastructure.Database;
using MediatR;

namespace Application.Commands.Author.AddAuthor
{
    public class AddAuthorCommandHandler : IRequestHandler<AddAuthorCommand, List<Domain.Author>>
    {
        private readonly FakeDatabase _database;

        public AddAuthorCommandHandler(FakeDatabase database)
        {
            _database = database;
        }

        public Task<List<Domain.Author>> Handle(AddAuthorCommand request, CancellationToken cancellationToken)
        {
            if (request.AuthorToAdd == null)
            {
                throw new ArgumentNullException(nameof(request.AuthorToAdd), "Author details must be provided.");
            }

            if (string.IsNullOrWhiteSpace(request.AuthorToAdd.Name))
            {
                throw new ArgumentException("Author name must not be empty.", nameof(request.AuthorToAdd.Name));
            }

            // Generera ett nytt ID om det behövs
            if (_database.Authors.Any())
            {
                request.AuthorToAdd.Id = _database.Authors.Max(a => a.Id) + 1;
            }
            else
            {
                request.AuthorToAdd.Id = 1;
            }

            // Lägg till författaren
            _database.Authors.Add(request.AuthorToAdd);

            // Returnera listan av författare
            return Task.FromResult(_database.Authors);
        }
    }
}
