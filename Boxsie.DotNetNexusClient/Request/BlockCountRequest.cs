using Boxsie.DotNetNexusClient.Core;

namespace Boxsie.DotNetNexusClient.Request
{
    public class BlockCountRequest : BaseRequest
    {
        public BlockCountRequest() : base(0, "getblockcount") { }
    }
}