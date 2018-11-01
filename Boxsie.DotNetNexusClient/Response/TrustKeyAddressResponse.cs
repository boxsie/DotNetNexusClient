using Boxsie.DotNetNexusClient.JsonConverters;
using Newtonsoft.Json;

namespace Boxsie.DotNetNexusClient.Response
{
    public class TrustKeyAddressResponse
    {
        [JsonProperty("address")]
        public string AddressHash { get; set; }

        [JsonProperty("interestrate")]
        public double InterestRate { get; set; }

        [JsonProperty("trustkey")]
        [JsonConverter(typeof(TrustKeyDataConverter))]
        public TrustKeyDataResponse Key { get; set; }
    }
}