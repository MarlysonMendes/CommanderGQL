using CommanderGQL.Data;
using CommanderGQL.Models;

namespace CommanderGQL.GraphQL.Commands
{
    public class CommandType : ObjectType<Command>
    {
        protected override void Configure(IObjectTypeDescriptor<Command> descriptor)
        {
            descriptor.Description("A command that can be executed on a platform.");

            descriptor
                .Field(t => t.Platform)
                .ResolveWith<Resolvers>(p => p.GetPlatform(default!, default!))
                .UseDbContext<AppDbContext>()
                .Description("The platform that this command is for.");

        }

        private class Resolvers
        {
            public Platform GetPlatform(Command command, [ScopedService] AppDbContext context)
            {
                return context.Platforms.FirstOrDefault(p => p.Id == command.Id);
            }
        }
    }
}