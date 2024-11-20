using Domain;
using MediatR;

namespace Application.Commands.Books.AddBook
{
    public class AddBookCommand : IRequest<List<Book>>
    {
        public AddBookCommand(Book bookToAdd)
        {
            newBook = bookToAdd;
        }

        //  public string Title { get; set; }
        //  public string Description { get; set; }
        //  public int AuthorId { get; set; }

        public Book newBook { get; }
    }
}
