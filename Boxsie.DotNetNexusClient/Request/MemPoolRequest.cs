using Boxsie.DotNetNexusClient.Core;

namespace Boxsie.DotNetNexusClient.Request
{
    public class MemPoolRequest : BaseRequest
    {
        public MemPoolRequest() : base(0, "getrawmempool") { }
    }
}