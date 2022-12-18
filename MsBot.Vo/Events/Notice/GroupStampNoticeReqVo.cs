using Newtonsoft.Json;

namespace MsBot.Vo.Events.Notice;

/// <summary>
/// 群内戳一戳
/// </summary>
public class GroupStampNoticeReqVo: NoticeReqVo
{
    /// <summary>
    /// 发送者 QQ 号
    /// </summary>
    [JsonProperty("user_id")]
    public long UserId { get; set; }

    /// <summary>
    /// 群号
    /// </summary>
    [JsonProperty("group_id")]
    public long GroupId { get; set; }

    /// <summary>
    /// 被戳者 QQ 号
    /// </summary>
    [JsonProperty("target_id")]
    public long TargetId { get; set; }

    /// <summary>
    /// 提示类型
    /// </summary>
    [JsonProperty("sub_type")]
    public string SubType { get; set; }

    public override string Template => "GroupStamp";
}