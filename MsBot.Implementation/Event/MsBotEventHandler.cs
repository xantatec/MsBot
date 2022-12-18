using MsBot.Implementation.Event.Actions;
using Newtonsoft.Json.Linq;

namespace MsBot.Implementation.Event;

public class MsBotEventHandler : IMsBotEventHandler
{
    private readonly MessageEventAction _messageEventAction;
    private readonly RequestEventAction _requestEventAction;
    private readonly NoticeEventAction _noticeEventAction;
    private readonly MetaEventAction _metaEventAction;

    public MsBotEventHandler(MessageEventAction messageEventAction, RequestEventAction requestEventAction, NoticeEventAction noticeEventAction, MetaEventAction metaEventAction)
    {
        _messageEventAction = messageEventAction;
        _requestEventAction = requestEventAction;
        _noticeEventAction = noticeEventAction;
        _metaEventAction = metaEventAction;
    }

    public void Handle(string requestStr)
    {
        if (string.IsNullOrEmpty(requestStr))
            return;

        var reqObj = JObject.Parse(requestStr);

        if (reqObj == null)
            return;

        var postTypeObj = reqObj["post_type"];
        if (postTypeObj == null)
            return;

        var postType = postTypeObj.ToString();

        string result;

        switch (postType)
        {
            case "message":
                result = _messageEventAction.Invoke(reqObj);
                break;

            case "request":
                result = _requestEventAction.Invoke(reqObj);
                break;

            case "notice":
                result = _noticeEventAction.Invoke(reqObj);
                break;

            case "meta_event":
                result = _metaEventAction.Invoke(reqObj);
                break;

            default:
                return;
        }

        Console.WriteLine($"[{postType}]OUTPUT：{result}");
    }
}