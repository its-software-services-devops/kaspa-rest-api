using Grpc.Core;
using Its.Kaspa.Api.Cores;

namespace Its.Kaspa.Api.Services;

public class BlockService : IBlockService
{
    private readonly IClient rpcClient;

    public BlockService(IClient client) 
    {
        rpcClient = client;
    }

    public async Task<GetBlocksResponseMessage> GetBlocks(string lowHash)
    {
        using var messageStream = rpcClient.GetRpcClient().MessageStream();
        var request = new KaspadRequest
        {
            GetBlocksRequest = new GetBlocksRequestMessage()
            {
                LowHash = lowHash,
                IncludeBlocks = false,
                IncludeTransactions = false
            }
        };

        await messageStream.RequestStream.WriteAsync(request);
        await messageStream.ResponseStream.MoveNext();
        var response = messageStream.ResponseStream.Current;

        var result = response.GetBlocksResponse;
        return result;
    }

    public async Task<GetBlockResponseMessage> GetBlock(string blockHash)
    {
        using var messageStream = rpcClient.GetRpcClient().MessageStream();
        var request = new KaspadRequest
        {
            GetBlockRequest = new GetBlockRequestMessage()
            {
                Hash = blockHash,
                IncludeTransactions = true
            }
        };

        await messageStream.RequestStream.WriteAsync(request);
        await messageStream.ResponseStream.MoveNext();
        var response = messageStream.ResponseStream.Current;

        var result = response.GetBlockResponse;
        return result;
    }
}
