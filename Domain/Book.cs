namespace Domain
{
    public class Book
    {
        public Book(Guid id, string title, string description, Guid authorId, Author author)
        {
            Id = id;
            Title = title;
            Description = description;
            AuthorId = authorId;
            Author = author;
        }

        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Guid AuthorId { get; set; }
        public Author Author { get; set; }
    }
}
