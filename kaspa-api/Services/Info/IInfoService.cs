namespace Its.Kaspa.Api.Services;

public interface IInfoService
{
    public Task<GetCurrentNetworkResponseMessage> GetCurrentNetwork();
    public Task<GetInfoResponseMessage> GetInfo();
    public Task<GetCoinSupplyResponseMessage> GetCoinSupply();
    public Task<GetBlockDagInfoResponseMessage> GetBlockDagInfo();
}

