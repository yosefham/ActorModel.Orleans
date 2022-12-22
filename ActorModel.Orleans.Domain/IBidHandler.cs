namespace ActorModel.Orleans.Domain;

public interface IBidHandler : IGrainWithStringKey
{
    ValueTask<bool> ProcessBid(BidAttempt bid);
}