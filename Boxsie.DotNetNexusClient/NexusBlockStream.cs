using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Boxsie.DotNetNexusClient.Core;
using Boxsie.DotNetNexusClient.Response;

namespace Boxsie.DotNetNexusClient
{
    public class NexusBlockStream
    {
        private readonly INexusClient _nexusClient;
        private readonly Dictionary<Guid, Func<BlockResponse, Task>> _subscribers;
        private readonly CancellationTokenSource _cancelBlockStream;

        private string _lastHash;

        public NexusBlockStream(INexusClient nexusClient)
        {
            _nexusClient = nexusClient;

            _subscribers = new Dictionary<Guid, Func<BlockResponse, Task>>();
            _cancelBlockStream = new CancellationTokenSource();
        }

        public async Task Start(TimeSpan checkDelay)
        {
            _lastHash = await _nexusClient.GetBlockHashAsync(await _nexusClient.GetBlockCountAsync());

#pragma warning disable 4014
            Task.Run(() => StreamAsync(checkDelay), _cancelBlockStream.Token);
#pragma warning restore 4014
        }

        public void Stop()
        {
            _cancelBlockStream.Cancel();
        }

        public Guid Subscribe(Func<BlockResponse, Task> onNewBlock)
        {
            var guid = Guid.NewGuid();

            _subscribers.Add(guid, onNewBlock);

            return guid;
        }

        public void Unsubscribe(Guid id)
        {
            if (_subscribers.ContainsKey(id))
                _subscribers.Remove(id);
        }

        public void Reset()
        {
            _subscribers.Clear();

            Stop();
        }

        private async Task StreamAsync(TimeSpan checkDelay)
        {
            while (true)
            {
                var block = await _nexusClient.GetNextBlockAsync(_lastHash);

                if (block != null)
                {
                    foreach (var subscriber in _subscribers.Values)
                        await subscriber(block);

                    _lastHash = block.Hash;
                }

                await Task.Delay(checkDelay);
            }
        }
    }
}