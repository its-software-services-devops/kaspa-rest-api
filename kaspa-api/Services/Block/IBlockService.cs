namespace Its.Kaspa.Api.Services;

public interface IBlockService
{
    public Task<GetBlocksResponseMessage> GetBlocks(string lowHash);
    public Task<GetBlockResponseMessage> GetBlock(string blockHash);
}
