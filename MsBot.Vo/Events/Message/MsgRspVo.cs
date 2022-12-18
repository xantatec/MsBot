using Newtonsoft.Json;

namespace MsBot.Vo.Events.Message;

public class MsgRspVo
{
    /// <summary>
    /// 要回复的内容
    /// </summary>
    [JsonProperty("reply")]
    public string Reply { get; set; }

    /// <summary>
    /// 消息内容是否作为纯文本发送 ( 即不解析 CQ 码 ) , 只在 reply 字段是字符串时有效
    /// </summary>
    [JsonProperty("auto_escape")]
    public bool AutoEscape { get; set; }
}