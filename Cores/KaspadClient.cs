using Grpc.Net.Client;

namespace Its.Kaspa.Api.Cores;

public class KaspadClient : RPC.RPCClient, IDisposable, IClient
{
    private readonly RPC.RPCClient client;
    
    private GrpcChannel channel;
    
    public KaspadClient(IConfiguration cfg)  
    {
        var url = cfg["Kaspad:Url"];

        channel = GrpcChannel.ForAddress(url!);
        client = new RPC.RPCClient(channel);
    }

    public RPC.RPCClient GetRpcClient()
    {
        return client;
    }

    public void Dispose()
    {
        channel.Dispose();
    }
}
