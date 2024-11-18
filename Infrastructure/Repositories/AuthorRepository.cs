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
    public class AuthorRepository : IAuthorRepository
    {
        private readonly FakeDatabase _database;

        public AuthorRepository(FakeDatabase database)
        {
            _database = database;
        }

        // Add a new author
        public Author Add(Author author)
        {
            if (author == null) throw new ArgumentNullException(nameof(author));
            _database.Authors.Add(author);
            return author;
        }

        // Get an author by ID
        public Author GetById(Guid id)
        {
            return _database.Authors.FirstOrDefault(a => a.Id == id)
                   ?? throw new KeyNotFoundException($"Author with ID {id} not found.");
        }

        // Get all authors
        public List<Author> GetAll()
        {
            return _database.Authors.ToList();
        }

        // Update an existing author
        public void Update(Author author)
        {
            var existingAuthor = GetById(author.Id);
            existingAuthor.Name = author.Name;
            
        }

        // Delete an author
        public void Delete(Guid id)
        {
            var author = GetById(id);
            _database.Authors.Remove(author);
        }
    }
}
