using Boxsie.DotNetNexusClient.Core;

namespace Boxsie.DotNetNexusClient.Request
{
    public class TxRequest : BaseRequest
    {
        private string _txHash;

        public TxRequest(string txHash) : base(0, "getglobaltransaction", txHash)
        {
            _txHash = txHash;
        }
    }
}
