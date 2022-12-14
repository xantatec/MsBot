using MsBot.Implementation.Configuration;
using MsBot.Implementation.Template.Razor;
using MsBot.Vo.Events.Request;
using Newtonsoft.Json.Linq;

namespace MsBot.Implementation.Event.Actions;

public class RequestEventAction : EventAction
{
    public RequestEventAction(MsBotConfig botConfig, RazorLightEngine engine)
        : base(botConfig, engine)
    {
    }

    public override string PostType => "Request";

    public override string Invoke(JObject reqObj)
    {
        var requestTypeObj = reqObj["request_type"];
        if (requestTypeObj == null)
            return string.Empty;

        var requestType = requestTypeObj.ToString();
        switch (requestType)
        {
            case "group":
                return Render<AddGroupRequestReqVo>(reqObj);

            case "friend":
                return Render<AddFriendRequestReqVo>(reqObj);

            default:
                return string.Empty;
        }
    }
}