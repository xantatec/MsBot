namespace MsBot.Domain.Msg;

public partial class MsgAggregateRoot : IAggregateRoot
{
    public long Id { get; set; }

    public string? Answer { get; set; }

    public string? Question { get; set; }

    public string? CreateId { get; set; }

    public string? Link { get; set; }
}
