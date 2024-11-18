using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IBookRepository
    {
        Book Add(Book book);
        Book GetById(Guid id);
        List<Book> GetAll();
        void Update(Book book);
        void Delete(Guid id);
    }
}
