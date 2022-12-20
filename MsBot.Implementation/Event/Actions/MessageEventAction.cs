using MsBot.Implementation.Configuration;
using MsBot.Vo.Events.Message;
using Newtonsoft.Json.Linq;

namespace MsBot.Implementation.Event.Actions;

public class MessageEventAction : EventAction
{
    public MessageEventAction(MsBotConfig botConfig)
        : base(botConfig)
    {
    }

    public override string PostType => "Message";

    public override string Invoke(JObject reqObj)
    {
        var msgTypeObj = reqObj["message_type"];

        if (msgTypeObj == null)
            return string.Empty;

        var msgType = msgTypeObj.ToString();
        switch (msgType)
        {
            case "private":
                return Render<PrivateMsgReqVo>(reqObj);

            case "group":
                return Render<GroupMsgReqVo>(reqObj);

            default:
                return string.Empty;
        }
    }
}