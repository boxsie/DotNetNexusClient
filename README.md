# DotNetNexusClient
A dot net RPC client for the Nexus wallet

This will allow you to make RPC calls to a Nexus node within the dot net core framework.

Install via package manager...

```
Install-Package Boxsie.DotNetNexusClient
```

Ensure you have RPC access to a Nexus node and then create the NexusClient object using the following connection string format...

```csharp
var client = new NexusClient("localhost:9336;Username=moop;Password=moop");
```

Make asynchronous calls to the Nexus node...

```csharp
int chainHeight = await client.GetBlockCountAsync();

string genesisBlockHash = await client.GetBlockHashAsync(1);

BlockResponse genesisBlock = await client.GetBlockAsync(genesisBlockHash);
```
