using ActorModel.Orleans.Domain;
using Microsoft.Extensions.Logging;
using Orleans.Runtime;

namespace ActorModel.Orleans.Grains;

public class BidHandlerGrain : Grain, IBidHandler
{
    private readonly ILogger _logger;
    private readonly IPersistentState<BidAttempt> _bid;

    public BidHandlerGrain(ILogger<BidHandlerGrain> logger, 
        [PersistentState("Bid","BidState")] IPersistentState<BidAttempt> bid)
    {
        _logger = logger;
        _bid = bid;
    }

    public async ValueTask<bool> ProcessBid(BidAttempt bid)
    {
        var successful = false;

        if (!string.IsNullOrWhiteSpace(bid.BidderId) && bid.Amount > _bid.State.Amount)
        {
            _bid.State = bid;
            successful = true;

            await _bid.WriteStateAsync();
        }

        return successful;
    }
}