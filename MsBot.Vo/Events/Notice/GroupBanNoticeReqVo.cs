using Newtonsoft.Json;

namespace MsBot.Vo.Events.Notice;

/// <summary>
/// 群禁言
/// </summary>
public class GroupBanNoticeReqVo : NoticeReqVo
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
    /// 禁言时长, 单位秒
    /// </summary>
    [JsonProperty("duration")]
    public long Duration { get; set; }

    public override string Template => "GroupBan";
}
