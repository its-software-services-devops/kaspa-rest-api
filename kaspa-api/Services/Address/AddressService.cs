using Grpc.Core;
using Its.Kaspa.Api.Cores;

namespace Its.Kaspa.Api.Services;

public class AddressService : IAddressService
{
    private readonly IClient rpcClient;

    public AddressService(IClient client) 
    {
        rpcClient = client;
    }

    public async Task<GetBalanceByAddressResponseMessage> GetBalanceByAddress(string address)
    {
        using var messageStream = rpcClient.GetRpcClient().MessageStream();
        var request = new KaspadRequest
        {
            GetBalanceByAddressRequest = new GetBalanceByAddressRequestMessage()
            {
                Address = address
            }
        };

        await messageStream.RequestStream.WriteAsync(request);
        await messageStream.ResponseStream.MoveNext();
        var response = messageStream.ResponseStream.Current;

        var result = response.GetBalanceByAddressResponse;
        return result;
    }

    public async Task<GetUtxosByAddressesResponseMessage> GetUtxosByAddress(string address)
    {
        using var messageStream = rpcClient.GetRpcClient().MessageStream();

        var message = new GetUtxosByAddressesRequestMessage();
        message.Addresses.Add(address);

        var request = new KaspadRequest
        {
            GetUtxosByAddressesRequest = message
        };

        await messageStream.RequestStream.WriteAsync(request);
        await messageStream.ResponseStream.MoveNext();
        var response = messageStream.ResponseStream.Current;

        var result = response.GetUtxosByAddressesResponse;
        return result;
    }
}
