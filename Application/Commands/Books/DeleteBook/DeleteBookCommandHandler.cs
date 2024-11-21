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

       //public Task<List<Book>> Handle(DeleteBookCommand request, CancellationToken cancellationToken)
       //{
       //    Book bookToDelete = _database.Books.FirstOrDefault(book  => book.Id == request.Id);
       //    _database.Books.Remove(bookToDelete);
       //    return Task.FromResult(_database.Books);
       //
       //}
        public Task<List<Book>> Handle(DeleteBookCommand request, CancellationToken cancellationToken)
        {
            // Validera att ID är giltigt
            if (request.Id <= 0)
            {
                throw new ArgumentException("Id must be greater than 0.", nameof(request.Id));
            }

            // Försök hitta boken
            Book bookToDelete = _database.Books.FirstOrDefault(book => book.Id == request.Id);

            // Hantera om boken inte hittas
            if (bookToDelete == null)
            {
                throw new KeyNotFoundException($"No book found with Id {request.Id}.");
            }

            // Ta bort boken
            try
            {
                _database.Books.Remove(bookToDelete);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"An error occurred while trying to delete the book with Id {request.Id}.", ex);
            }

            // Returnera uppdaterad lista
            return Task.FromResult(_database.Books);
        }
    }
}
