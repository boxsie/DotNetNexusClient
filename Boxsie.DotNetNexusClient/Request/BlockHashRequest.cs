using Boxsie.DotNetNexusClient.Core;

namespace Boxsie.DotNetNexusClient.Request
{
    public class BlockHashRequest : BaseRequest
    {
        private int _height;

        public BlockHashRequest(int height) : base(0, "getblockhash", height)
        {
            _height = height;
        }
    }
}