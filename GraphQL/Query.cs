using CommanderGQL.Data;
using CommanderGQL.Models;
using HotChocolate;
using HotChocolate.Data;

namespace CommanderGQL.GraphQL
{
    public class Query
    {
        [UseDbContext(typeof(AppDbContext))]
        public IQueryable<Platform> GetPlataform([ScopedService] AppDbContext context)
        {
            return context.Platforms;
        }
        
    }
}