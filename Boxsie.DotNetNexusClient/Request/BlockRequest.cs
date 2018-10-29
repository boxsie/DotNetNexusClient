using Boxsie.DotNetNexusClient.Core;

namespace Boxsie.DotNetNexusClient.Request
{
    public class BlockRequest : BaseRequest
    {
        private string _blockHash;

        public BlockRequest(string blockHash) : base(0, "getblock", blockHash)
        {
            _blockHash = blockHash;
        }
    }
}