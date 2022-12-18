using Newtonsoft.Json;

namespace MsBot.Vo.Events.Notice;

/// <summary>
/// 好友戳一戳
/// </summary>
public class FriendStampNoticeReqVo : NoticeReqVo
{
    /// <summary>
    /// 发送者 QQ 号
    /// </summary>
    [JsonProperty("user_id")]
    public long UserId { get; set; }

    /// <summary>
    /// 发送者 QQ 号
    /// </summary>
    [JsonProperty("sender_id")]
    public long SenderId { get; set; }

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

    public override string Template => "FriendStamp";
}