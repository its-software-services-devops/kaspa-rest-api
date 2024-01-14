using Grpc.Core;
using Its.Kaspa.Api.Cores;

namespace Its.Kaspa.Api.Services;

public class NetworkService : INetworkService
{
    private readonly IClient rpcClient;

    public NetworkService(IClient client) 
    {
        rpcClient = client;
    }

    public async Task<GetCurrentNetworkResponseMessage> GetCurrentNetwork()
    {
        using var messageStream = rpcClient.GetRpcClient().MessageStream();
        var request = new KaspadRequest
        {
            GetCurrentNetworkRequest = new GetCurrentNetworkRequestMessage()
        };

        await messageStream.RequestStream.WriteAsync(request);
        await messageStream.ResponseStream.MoveNext();
        var response = messageStream.ResponseStream.Current;

        var result = response.GetCurrentNetworkResponse;
        return result;
    }
}
