using MsBot.Implementation.Configuration;
using MsBot.Vo.Events.MetaEvent;
using Newtonsoft.Json.Linq;

namespace MsBot.Implementation.Event.Actions;

public class MetaEventAction : EventAction
{
    public MetaEventAction(MsBotConfig botConfig)
        : base(botConfig)
    {
    }

    public override string PostType => "Meta";

    public override string Invoke(JObject reqObj)
    {
        return Render<MetaEventReqVo>(reqObj);
    }
}