using System;

namespace Boxsie.DotNetNexusClient.Tests
{
    public class NexusClientFixture : IDisposable
    {
        public NexusClient Client { get; private set; }

        public NexusClientFixture()
        {
            Client = new NexusClient(TestHelpers.GetConnectionString("Nexus"));
        }

        public void Dispose()
        {
            Client = null;
        }
    }
}