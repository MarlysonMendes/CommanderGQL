using CommanderGQL.Data;
using CommanderGQL.Models;
using HotChocolate;

namespace CommanderGQL.GraphQL
{
    public class Query
    {
        public IQueryable<Platform> GetPlataform([Service] AppDbContext context)
        {
            return context.Platforms;
        }
        
    }
}