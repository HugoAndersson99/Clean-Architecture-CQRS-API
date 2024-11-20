using Domain;
using Infrastructure.Database;
using MediatR;

namespace Application.Commands.Books.DeleteBook
{
    public class DeleteBookCommandHandler : IRequestHandler<DeleteBookCommand, List<Book>>
    {
        private readonly FakeDatabase _database;

        public DeleteBookCommandHandler(FakeDatabase database)
        {
            _database = database;
        }

        public Task<List<Book>> Handle(DeleteBookCommand request, CancellationToken cancellationToken)
        {
            Book bookToDelete = _database.Books.FirstOrDefault(book  => book.Id == request.Id);
            _database.Books.Remove(bookToDelete);
            return Task.FromResult(_database.Books);

        }
    }
}
