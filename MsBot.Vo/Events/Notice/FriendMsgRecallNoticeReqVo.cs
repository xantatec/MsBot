using Newtonsoft.Json;

namespace MsBot.Vo.Events.Notice;

/// <summary>
/// 好友消息撤回
/// </summary>
public class FriendMsgRecallNoticeReqVo : NoticeReqVo
{
    /// <summary>
    /// 发送者 QQ 号
    /// </summary>
    [JsonProperty("user_id")]
    public long UserId { get; set; }

    /// <summary>
    /// 被撤回的消息 ID
    /// </summary>
    [JsonProperty("message_id")]
    public long MessageId { get; set; }

    public override string Template => "FriendMsg";
}