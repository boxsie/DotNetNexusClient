using System.Collections.Generic;
using System.IO;
using System.Reflection;
using Newtonsoft.Json;

namespace Boxsie.DotNetNexusClient.Tests
{
    public static class TestHelpers
    {
        public static string GetConnectionString(string connectionName)
        {
            var configPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

            using (var s = File.OpenText($"{configPath}/config.json"))
            {
                var json = JsonConvert.DeserializeObject<Dictionary<string, string>>(s.ReadToEnd());

                return json[connectionName];
            }
        }
    }
}