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

        private const string GenesisHash =
            "c8b01fc7f3fa20237a9440e0645fea8876ca6fa2367f926e1ce262264e536bfc77865f54ad5eade99295f" +
            "e014fb6f78fa6a6a9356bc732a1ca50952af368a0b6e89bec3f51e9afb42627220f70d9a68f6b6bc74742" +
            "b3bb7c669ccc1e05e34142e0ea3b399b405598302ffafa3f94cfa53b1536392ac1b4acad4176cfdea3fa0e";

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

        [Fact]
        public async Task NexusClient_GetBlockWithGenesisHash_ReturnsGenesisBlock()
        {
            var block = await _clientFixture.Client.GetBlockAsync(GenesisHash);

            _output.WriteLine($"GetBlock returned block with height {block.Height} for the genesis hash");

            Assert.True(block.Hash == GenesisHash && block.Height == 1);
        }

        [Fact]
        public async Task NexusClient_GetBlockHeightWithGenesisHeight_ReturnsGenesisHash()
        {
            var genesisHash = await _clientFixture.Client.GetBlockHashAsync(1);

            _output.WriteLine($"GetBlockHash returned block 1's hash as {genesisHash}");

            Assert.True(genesisHash == GenesisHash);
        }

        [Fact]
        public async Task NexusClient_IsGenesisHashOnChain_ReturnsTrue()
        {
            var isGenesisOnChain = await _clientFixture.Client.IsBlockHashOnChainAsync(GenesisHash);

            _output.WriteLine($"Genesis block hash on chain = {isGenesisOnChain}");

            Assert.True(isGenesisOnChain);
        }

        [Fact]
        public async Task NexusClient_IsFakeHashOnChain_ReturnsFalse()
        {
            var isFakeHashOnChain = await _clientFixture.Client.IsBlockHashOnChainAsync("FAKEHASH");

            _output.WriteLine($"Fake block hash on chain = {isFakeHashOnChain}");

            Assert.True(!isFakeHashOnChain);
        }
    }
}
