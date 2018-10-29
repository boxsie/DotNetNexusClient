using Boxsie.DotNetNexusClient.Core;

namespace Boxsie.DotNetNexusClient.Request
{
    public class MiningInfoRequest : BaseRequest
    {
        public MiningInfoRequest() : base(0, "getmininginfo") { }
    }
}