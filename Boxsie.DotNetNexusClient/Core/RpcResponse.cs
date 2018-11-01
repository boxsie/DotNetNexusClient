﻿using Newtonsoft.Json;

namespace Boxsie.DotNetNexusClient.Core
{
    public class RpcResponse<T>
    {
        [JsonProperty("result")]
        public T Result { get; set; }

        [JsonProperty("error")]
        public RpcError Error { get; set; }

        [JsonProperty("id")]
        public int Id { get; set; }
    }
}
