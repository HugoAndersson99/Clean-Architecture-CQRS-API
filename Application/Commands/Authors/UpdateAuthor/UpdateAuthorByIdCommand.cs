using Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.Authors.UpdateAuthor
{
    public class UpdateAuthorByIdCommand : IRequest<Author>
    {
        public UpdateAuthorByIdCommand(Author updatedAuthor, int id)
        {
            UpdatedAuthor = updatedAuthor;
            Id = id;
        }

        public Author UpdatedAuthor { get; }
        public int Id { get; }
    }
}
