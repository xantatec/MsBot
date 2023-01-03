namespace MsBot.Domain.Msg
{
    public class MsgSummaryAggregateRoot : IAggregateRoot
    {
        public long Id { get; set; }

        public int Hour { get; set; }

        public int Day { get; set; }

        public int Month { get; set; }

        public int Year { get; set; }

        public long Count { get; set; }
    }
}