using MsBot.Implementation.Configuration;
using MsBot.Vo.Events;

namespace MsBot.Implementation.Template.Razor
{
    public class MsBotModel<T>
        where T : BaseReqVo
    {
        public T Request { get; set; }

        public MsBotConfig Config { get; set; }
    }
}