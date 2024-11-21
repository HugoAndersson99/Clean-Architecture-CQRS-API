using Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.Authors.DeleteAuthor
{
    public class DeleteAuthorCommand : IRequest<List<Author>>
    {
        public DeleteAuthorCommand(int id)
        {
            Id = id;
        }

        public int Id { get; }
    }
}
