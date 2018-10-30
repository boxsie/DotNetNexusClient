using Boxsie.DotNetNexusClient.Core;

namespace Boxsie.DotNetNexusClient.Request
{
    public class InfoRequest : BaseRequest
    {
        public InfoRequest() : base(0, "getinfo") { }
    }
}
