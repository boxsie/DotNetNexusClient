using Boxsie.DotNetNexusClient.Core;

namespace Boxsie.DotNetNexusClient.Request
{
    public class DifficultyRequest : BaseRequest
    {
        public DifficultyRequest() : base(0, "getdifficulty") { }
    }
}