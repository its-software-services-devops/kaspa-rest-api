namespace Its.Kaspa.Api.Services;

public interface INetworkService
{
    public Task<GetCurrentNetworkResponseMessage> GetCurrentNetwork();
}

