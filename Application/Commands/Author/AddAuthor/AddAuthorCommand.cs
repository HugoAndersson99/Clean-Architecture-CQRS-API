using Domain;
using MediatR;
namespace Application.Commands.Author.AddAuthor
{
    public class AddAuthorCommand : IRequest<List<Domain.Author>>
    {
        public AddAuthorCommand(Domain.Author authorToAdd)
        {
            this.AuthorToAdd = authorToAdd;
        }

        public Domain.Author AuthorToAdd { get; }
    }
}
