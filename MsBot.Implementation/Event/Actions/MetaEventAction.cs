using MsBot.Implementation.Configuration;
using MsBot.Vo.Events.MetaEvent;
using Newtonsoft.Json.Linq;
using RazorEngine.Templating;

namespace MsBot.Implementation.Event.Actions;

public class MetaEventAction : EventAction
{
    public MetaEventAction(MsBotConfig botConfig, IRazorEngineService razorEngine)
        : base(botConfig, razorEngine)
    {
    }

    public override string PostType => "Meta";

    public override string Invoke(JObject reqObj)
    {
        return Render<MetaEventReqVo>(reqObj);
    }
}