using Boxsie.DotNetNexusClient.JsonConverters;
using Newtonsoft.Json;

namespace Boxsie.DotNetNexusClient.Response
{
    public class TrustKeyAddressResponse
    {
        [JsonProperty("address")]
        public string AddressHash { get; set; }

        [JsonProperty("interest rate")]
        public double InterestRate { get; set; }

        [JsonProperty("trust key")]
        [JsonConverter(typeof(TrustKeyDataConverter))]
        public TrustKeyDataResponse Key { get; set; }
    }
}