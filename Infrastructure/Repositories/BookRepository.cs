using Application.Interfaces;
using Domain;
using Infrastructure.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly FakeDatabase _db;

        public BookRepository(FakeDatabase db)
        {
            _db = db ?? throw new ArgumentNullException(nameof(db));
        }

        // Create
        public Book Add(Book book)
        {
            if (book == null) throw new ArgumentNullException(nameof(book));
            _db.Books.Add(book);
            return book;
        }

        // Read (Get by ID)
        public Book GetById(Guid id)
        {
            return _db.Books.FirstOrDefault(b => b.Id == id)
                   ?? throw new KeyNotFoundException($"Book with ID {id} not found.");
        }

        // Read (Get all)
        public List<Book> GetAll()
        {
            return _db.Books.ToList();
        }

        // Update
        public void Update(Book book)
        {
            var existingBook = GetById(book.Id);
            existingBook.Title = book.Title;
            existingBook.AuthorId = book.AuthorId;
        }

        // Delete
        public void Delete(Guid id)
        {
            var book = GetById(id);
            _db.Books.Remove(book);
        }
    }
}
