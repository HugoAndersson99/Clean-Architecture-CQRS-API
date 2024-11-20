using Domain;

namespace Infrastructure.Database
{
    public class FakeDatabase
    {
        public List<Book> Books { get; set; } = new();
        public List<Author> Authors { get; set; } = new();

        public FakeDatabase() {
            Books.Add(new Book(1,"FirstBook", "Komedi"));
            Books.Add(new Book(2,"SecondBook", "Skräck"));
            Books.Add(new Book(3,"ThirdBook", "Fantasy"));
            
        }
    }
}
