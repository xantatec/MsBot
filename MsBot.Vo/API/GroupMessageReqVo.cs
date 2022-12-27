using Newtonsoft.Json;

namespace MsBot.Vo.API;

public class GroupMessageReqVo
{
    /// <summary>
    /// 群号
    /// </summary>
    [JsonProperty("group_id")]
    public long GroupId { get; set; }

    /// <summary>
    /// 消息
    /// </summary>
    [JsonProperty("message")]
    public string Message { get; set; }

    /// <summary>
    /// 消息内容是否作为纯文本发送（即不解析 CQ 码），只在 message 字段是字符串时有效
    /// </summary>
    [JsonProperty("auto_escape")]
    public bool AutoEscape { get; set; }
}