using Newtonsoft.Json;

namespace MsBot.Vo.Events.Notice;

/// <summary>
/// 群红包运气王提示
/// </summary>
public class RedPacketLuckNoticeReqVo : NoticeReqVo
{
    /// <summary>
    /// 红包发送者id
    /// </summary>
    [JsonProperty("user_id")]
    public long UserId { get; set; }

    /// <summary>
    /// 群号
    /// </summary>
    [JsonProperty("group_id")]
    public long GroupId { get; set; }

    /// <summary>
    /// 运气王id
    /// </summary>
    [JsonProperty("target_id")]
    public long TargetId { get; set; }

    /// <summary>
    /// 提示类型
    /// </summary>
    [JsonProperty("sub_type")]
    public string SubType { get; set; }

    public override string Template => "RedPacketLuck";
}