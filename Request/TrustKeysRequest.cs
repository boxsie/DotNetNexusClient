using Boxsie.DotNetNexusClient.Core;

namespace Boxsie.DotNetNexusClient.Request
{
    public class TrustKeysRequest : BaseRequest
    {
        public TrustKeysRequest() : base(0, "getnetworktrustkeys") { }
    }
}