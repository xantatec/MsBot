using MsBot.Domain;
using MsBot.Domain.Msg;

namespace MsBot.Implementation.MySql.Repositories;

public class MsgSummaryRepository : Repository<MsgSummaryAggregateRoot>
{
    public MsgSummaryRepository(IRepositoryContextProvider contextProvider)
        : base(contextProvider)
    {
    }

    public Dictionary<int, long> GetTodayCount(long groupId, int year, int month, int day)
    {
        var query = MsBotContext.MsgSummaries.Where(s => s.GroupId == groupId && s.Year == year && s.Month == month && s.Day == day).ToList();
        var result = new Dictionary<int, long>();
        foreach(var kv in query)
            result.Add(kv.Hour, kv.Count);

        return result;
    }

    public Dictionary<int, long> GetMonthCount(long groupId, int year, int month)
    {
        var query = MsBotContext.MsgSummaries.Where(s => s.GroupId == groupId && s.Year == year && s.Month == month).GroupBy(s => s.Day).Select(s => new
        {
            Day = s.Key,
            Count = s.Sum(ss => ss.Count)
        }).ToList();
        var result = new Dictionary<int, long>();
        foreach(var kv in query)
            result.Add(kv.Day, kv.Count);

        return result;
    }

    public Dictionary<int, long> GetYearCount(long groupId, int year)
    {
        var query = MsBotContext.MsgSummaries.Where(s => s.GroupId == groupId && s.Year == year).GroupBy(s => s.Month).Select(s => new
        {
            Month = s.Key,
            Count = s.Sum(ss => ss.Count)
        }).ToList();
        var result = new Dictionary<int, long>();
        foreach(var kv in query)
            result.Add(kv.Month, kv.Count);

        return result;
    }
}
