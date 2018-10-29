﻿using System.Net.Http;
using System.Text;
using Boxsie.DotNetNexusClient.JsonConverters;
using Newtonsoft.Json;

namespace Boxsie.DotNetNexusClient.Core
{
    public abstract class BaseRequest
    {
        [JsonProperty("id")]
        public int Id { get; }

        [JsonProperty("method", Required = Required.Always)]
        public string Method { get; }

        [JsonProperty("params")]
        [JsonConverter(typeof(ParameterJsonConverter))]
        public object[] Parameters { get; }

        [JsonProperty("jsonrpc", Required = Required.Always)]
        public string JsonRpcVersion { get; }

        protected BaseRequest(int id, string method, params object[] parameters)
        {
            Id = id;
            Method = method;
            Parameters = parameters;

            JsonRpcVersion = "2.0";
        }

        public StringContent GetContent()
        {
            return new StringContent(JsonConvert.SerializeObject(this), Encoding.UTF8, "application/json");
        }
    }
}
