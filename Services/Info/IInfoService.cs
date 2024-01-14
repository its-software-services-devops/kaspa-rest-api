namespace Its.Kaspa.Api.Services;

public interface IInfoService
{
    public Task<GetCurrentNetworkResponseMessage> GetCurrentNetwork();
}

