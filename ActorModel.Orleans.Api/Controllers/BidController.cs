using ActorModel.Orleans.Domain;
using Microsoft.AspNetCore.Mvc;

namespace ActorModel.Orleans.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class BidController : ControllerBase
{
    private readonly IClusterClient _grainCluster;

    public BidController(IClusterClient grainCluster)
    {
        _grainCluster = grainCluster;
    }

    [HttpPost("/{objectId}")]
    public async Task<ActionResult> PlaceBid([FromRoute]string objectId, [FromBody] BidAttempt bidAttempt)
    {
        var friend = _grainCluster.GetGrain<IBidHandler>(objectId);
        var bid = new BidAttempt
        {
            Amount = bidAttempt.Amount,
            LastUpdate = bidAttempt.LastUpdate,
            BidderId = bidAttempt.BidderId,
            ObjectId = objectId
        };

        return await friend.ProcessBid(bid) ? new OkResult() : Problem("The bid processing failed.");
    }
}