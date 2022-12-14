using Newtonsoft.Json;

namespace MsBot.Vo.Events.Notice;

/// <summary>
/// 群消息撤回
/// </summary>
public class GroupMsgRecallNoticeReqVo: NoticeReqVo
{
    /// <summary>
    /// 群号
    /// </summary>
    [JsonProperty("group_id")]
    public long GroupId { get; set; }

    /// <summary>
    /// 发送者 QQ 号
    /// </summary>
    [JsonProperty("user_id")]
    public long UserId { get; set; }

    /// <summary>
    /// 操作者 QQ 号
    /// </summary>
    [JsonProperty("operator_id")]
    public long OperatorId { get; set; }

    /// <summary>
    /// 被撤回的消息 ID
    /// </summary>
    [JsonProperty("message_id")]
    public long MessageId { get; set; }

    public override string Template => "GroupMsgRecall";
}
