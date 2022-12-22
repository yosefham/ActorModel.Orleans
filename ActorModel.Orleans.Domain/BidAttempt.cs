namespace ActorModel.Orleans.Domain;

[GenerateSerializer]
public class BidAttempt
{
    [Id(0)]
    public decimal Amount { get; set; }
    [Id(1)]
    public DateTime LastUpdate { get; set; }
    [Id(2)]
    public string BidderId { get; set; }
    [Id(3)]
    public string ObjectId { get; set; }
}