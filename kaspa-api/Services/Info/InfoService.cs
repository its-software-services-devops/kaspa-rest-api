using Grpc.Core;
using Its.Kaspa.Api.Cores;

namespace Its.Kaspa.Api.Services;

public class InfoService : IInfoService
{
    private readonly IClient rpcClient;

    public InfoService(IClient client) 
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

    public async Task<GetInfoResponseMessage> GetInfo()
    {
        using var messageStream = rpcClient.GetRpcClient().MessageStream();
        var request = new KaspadRequest
        {
            GetInfoRequest = new GetInfoRequestMessage()
        };

        await messageStream.RequestStream.WriteAsync(request);
        await messageStream.ResponseStream.MoveNext();
        var response = messageStream.ResponseStream.Current;

        var result = response.GetInfoResponse;
        return result;
    }

    public async Task<GetCoinSupplyResponseMessage> GetCoinSupply()
    {
        using var messageStream = rpcClient.GetRpcClient().MessageStream();
        var request = new KaspadRequest
        {
            GetCoinSupplyRequest = new GetCoinSupplyRequestMessage()
        };

        await messageStream.RequestStream.WriteAsync(request);
        await messageStream.ResponseStream.MoveNext();
        var response = messageStream.ResponseStream.Current;

        var result = response.GetCoinSupplyResponse;
        return result; 
    }

    public async Task<GetBlockDagInfoResponseMessage> GetBlockDagInfo()
    {
        using var messageStream = rpcClient.GetRpcClient().MessageStream();
        var request = new KaspadRequest
        {
            GetBlockDagInfoRequest = new GetBlockDagInfoRequestMessage()
        };

        await messageStream.RequestStream.WriteAsync(request);
        await messageStream.ResponseStream.MoveNext();
        var response = messageStream.ResponseStream.Current;

        var result = response.GetBlockDagInfoResponse;
        return result; 
    }
}
