using CommanderGQL.Models;

namespace CommanderGQL.GraphQL
{
    public class Subscription
    {
        [Subscribe]
        [Topic]
        public Platform OnPlaformAdded([EventMessage] Platform platform)
        {
            return platform;
        }
    }
}