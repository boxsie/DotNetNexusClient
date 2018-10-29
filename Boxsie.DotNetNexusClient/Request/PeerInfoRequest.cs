using Boxsie.DotNetNexusClient.Core;

namespace Boxsie.DotNetNexusClient.Request
{
    public class PeerInfoRequest : BaseRequest
    {
        public PeerInfoRequest() : base(0, "getpeerinfo") { }
    }
}