using Newtonsoft.Json;

namespace MsBot.Vo.Events;

public abstract class BaseReqVo
{
    /// <summary>
    /// 模板
    /// </summary>
    [JsonIgnore]
    public abstract string Template { get; }

    /// <summary>
    /// 事件发生的时间戳
    /// </summary>
    [JsonProperty("time")]
    public long Time { get; set; }

    /// <summary>
    /// 收到事件的机器人的 QQ 号
    /// </summary>
    [JsonProperty("self_id")]
    public long SelfId { get; set; }

    /// <summary>
    /// 表示该上报的类型, 消息, 请求, 通知, 或元事件
    /// </summary>
    [JsonProperty("post_type")]
    public PostTypeVo PostType { get; set; }
}
