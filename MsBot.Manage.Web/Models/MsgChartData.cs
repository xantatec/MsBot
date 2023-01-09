namespace MsBot.Manage.Web.Models;

public class MsgChartData<T>
{
    public List<string> Categories { get; set; }
    public List<T> Values { get; set; }
}
