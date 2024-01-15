namespace Its.Kaspa.Api.Services;

public interface IAddressService
{
    public Task<GetBalanceByAddressResponseMessage> GetBalanceByAddress(string address);
    public Task<GetUtxosByAddressesResponseMessage> GetUtxosByAddress(string address);
}
