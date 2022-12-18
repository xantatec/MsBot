using Newtonsoft.Json;

namespace MsBot.Vo.Events.Message;

/// <summary>
/// 群消息
/// </summary>
public class GroupMsgReqVo : MsgReqVo
{
    /// <summary>
    /// 群号
    /// </summary>
    [JsonProperty("group_id")]
    public long GroupId { get; set; }

    /// <summary>
    /// 匿名信息
    /// </summary>
    [JsonProperty("anonymous")]
    public AnonymousVo Anonymous { get; set; }

    public override string Template => "GroupMsg";
}

/// <summary>
/// 匿名信息
/// </summary>
public class AnonymousVo
{
    /// <summary>
    /// 匿名用户 ID
    /// </summary>
    [JsonProperty("id")]
    public long Id { get; set; }

    /// <summary>
    /// 匿名用户名称
    /// </summary>
    [JsonProperty("name")]
    public string Name { get; set; }

    /// <summary>
    /// 匿名用户 flag, 在调用禁言 API 时需要传入
    /// </summary>
    [JsonProperty("flag")]
    public long Flag { get; set; }
}