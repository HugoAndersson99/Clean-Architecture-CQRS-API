
using Domain;
using Infrastructure.Database;
using MediatR;

namespace Application.Commands.Books.UpdateBook
{
    public class UpdateBookByIdCommandHandler : IRequestHandler<UpdateBookByIdCommand, List<Book>>
    {
        private readonly FakeDatabase _database;

        public UpdateBookByIdCommandHandler(FakeDatabase database)
        {
            _database = database;
        }

        public Task<List<Book>> Handle(UpdateBookByIdCommand request, CancellationToken cancellationToken)
        {
            // Hitta boken som ska uppdateras
            Book bookToUpdate = _database.Books.FirstOrDefault(book => book.Id == request.Id);

            if (bookToUpdate == null)
            {
                throw new Exception($"Book with Id {request.Id} not found");
            }

            // Uppdatera egenskaper (utom Id)
            bookToUpdate.Description = request.UpdatedBook.Description;
            bookToUpdate.Title = request.UpdatedBook.Title;

            // Returnera den uppdaterade boken
            return Task.FromResult(_database.Books);
        }
    }
}
