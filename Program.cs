using CommanderGQL.Data;
using CommanderGQL.GraphQL;
using Microsoft.EntityFrameworkCore;
using GraphQL.Server.Ui.Voyager;
using CommanderGQL.GraphQL.Platforms;
using CommanderGQL.GraphQL.Commands;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddPooledDbContextFactory<AppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("CommandConStr"));
});
builder.Services
.AddGraphQLServer()
.AddQueryType<Query>()
.AddType<PlatformType>()
.AddType<CommandType>();

var app = builder.Build();
app.UseRouting();
app.UseEndpoints(endpoints =>
    {
        endpoints.MapGraphQL();
    });
app.UseGraphQLVoyager(new VoyagerOptions()
{
    GraphQLEndPoint = "/graphql"
}, "/graphql-voyager");

app.Run();
