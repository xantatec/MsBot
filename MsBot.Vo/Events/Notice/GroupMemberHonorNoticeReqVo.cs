using Newtonsoft.Json;

namespace MsBot.Vo.Events.Notice;

/// <summary>
/// 群成员荣誉变更提示
/// </summary>
public class GroupMemberHonorNoticeReqVo : NoticeReqVo
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
    /// 荣誉类型
    /// </summary>
    [JsonProperty("honor_type")]
    public long HonorType { get; set; }

    /// <summary>
    /// 提示类型
    /// </summary>
    [JsonProperty("sub_type")]
    public string SubType { get; set; }

    public override string Template => "GroupMemberHonor";
}

/// <summary>
/// 荣誉类型
/// </summary>
public enum HonorType
{
    /// <summary>
    /// 龙王
    /// </summary>
    [JsonProperty("talkative")]
    Talkative,

    /// <summary>
    /// 群聊之火
    /// </summary>
    [JsonProperty("performer")]
    Performer,
    
    /// <summary>
    /// 快乐源泉
    /// </summary>
    [JsonProperty("emotion")]
    Emotion
}