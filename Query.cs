using ApiGq;
using GraphApi;
using Microsoft.EntityFrameworkCore;

namespace HotG
{
    public class Query
    {
        public string Hello() => "World";

        public Task<List<Book>> GetBooks([Service] Repository repository) =>
         repository.GetBooksAsync();

        public Task<List<Author>> GetAuthor([Service] Repository repository) =>
         repository.GetAuthorAsync();


        //, string name
        [UseFiltering]
        public IQueryable<Company> GetCompany(CibContext dbContext)
        { 
            var results = dbContext.Companies.Include(t => t.CompanyMembers).ThenInclude(t => t.Permissions);
            results.ForEachAsync(t => t.Name = t.Name + "*");
            return results.AsQueryable();
        }
        
    }
}
