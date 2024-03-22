using System.Collections.Generic;

namespace ApiGq
{
    public class Repository
    {
        List<Book> Books = new List<Book>();
        public Task<List<Book>> GetBooksAsync()
        {
            Books.Add(new Book(Guid.NewGuid(), "TE AMO", new Author(Guid.NewGuid(), "Anya")));
            Books.Add(new Book(Guid.NewGuid(), "TE AMO2", new Author(Guid.NewGuid(), "Anya2")));
            return Task.FromResult(Books);
        }

        public Task<List<Author>> GetAuthorAsync()
        {
            var autores = new List<Author>();
            autores.Add(new Author(Guid.NewGuid(), "Anya"));
            autores.Add(new Author(Guid.NewGuid(), "Vale"));
            return Task.FromResult(autores);
        }

        public Task<Author?> GetAuthor(Guid authorId)
        {
            var autores = new List<Author>();
            autores.Add(new Author(Guid.NewGuid(), "Anya"));
            autores.Add(new Author(Guid.NewGuid(), "Vale"));
            return Task.FromResult(autores.FirstOrDefault(a => a.Id == authorId));
        }
    }
}
