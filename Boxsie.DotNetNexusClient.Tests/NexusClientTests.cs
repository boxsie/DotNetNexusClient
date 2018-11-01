using System.Linq;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace Boxsie.DotNetNexusClient.Tests
{
    public class NexusClientTests : IClassFixture<NexusClientFixture>
    {
        private readonly NexusClientFixture _clientFixture;
        private readonly ITestOutputHelper _output;

        public NexusClientTests(NexusClientFixture clientFixture, ITestOutputHelper output)
        {
            _clientFixture = clientFixture;
            _output = output;
        }

        [Fact]
        public async Task NexusClient_GetBlockCount_GreaterThanZero()
        {
            var height = await _clientFixture.Client.GetBlockCountAsync();

            _output.WriteLine($"GetBlockCount returned {height}");

            Assert.True(height > 0);
        }

        [Theory]
        [InlineData("c8b01fc7f3fa20237a9440e0645fea8876ca6fa2367f926e1ce262264e536bfc77865f54ad5eade99295fe014fb6f78fa6a6a9356bc732a1ca50952af368a0b6e89bec3f51e9afb42627220f70d9a68f6b6bc74742b3bb7c669ccc1e05e34142e0ea3b399b405598302ffafa3f94cfa53b1536392ac1b4acad4176cfdea3fa0e")]
        [InlineData(1)]
        public async Task NexusClient_GetBlock_ReturnsGenesisBlock(object value)
        {
            switch (value)
            {
                case string s:
                {
                    var block = await _clientFixture.Client.GetBlockAsync(s);

                    _output.WriteLine($"GetBlock returned block with height {block.Height}");

                    Assert.True(block.Hash == s && block.Height == 1);
                    break;
                }
                case int i:
                {
                    var blockHash = await _clientFixture.Client.GetBlockHashAsync(i);
                    var block = await _clientFixture.Client.GetBlockAsync(blockHash);

                    _output.WriteLine($"GetBlock returned block with height {block.Height}");

                    Assert.True(block.Height == i && block.Hash == "c8b01fc7f3fa20237a9440e0645fea8876ca6fa2367f926e1ce262264e536bfc77865f54ad5eade99295fe014fb6f78fa6a6a9356bc732a1ca50952af368a0b6e89bec3f51e9afb42627220f70d9a68f6b6bc74742b3bb7c669ccc1e05e34142e0ea3b399b405598302ffafa3f94cfa53b1536392ac1b4acad4176cfdea3fa0e");
                    break;
                }
                default:
                    Assert.True(false);
                    break;
            }
        }

        [Fact]
        public async Task NexusClient_GetDifficultyResponseSerialisation_NothingIsZero()
        {
            var diff = await _clientFixture.Client.GetNetworkDifficultyAsync();

            _output.WriteLine($"HASH = {diff.HashChannel}\nPRIME = {diff.PrimeChannel}\nPOS = {diff.ProofOfStake}");

            Assert.True(diff.HashChannel > 0 && diff.PrimeChannel > 0 && diff.ProofOfStake > 0);
        }

        [Fact]
        public async Task NexusClient_GetTrustKeysResponseSerialisation_NothingIsNullOrEmptyOrZero()
        {
            var keyResponse = await _clientFixture.Client.GetTrustKeysAsync();

            _output.WriteLine($"{keyResponse.Keys.Count} keys");

            Assert.True(keyResponse.Keys.Count > 0 && 
                        keyResponse.Keys.All(x => x.Key != null) && 
                        keyResponse.Keys.All(x => x.InterestRate > 0));
        }
    }
}
