using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IAuthorRepository
    {
        Author Add(Author author);
        Author GetById(Guid id);
        List<Author> GetAll();
        void Update(Author author);
        void Delete(Guid id);
    }
}
