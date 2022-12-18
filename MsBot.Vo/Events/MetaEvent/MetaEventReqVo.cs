using Newtonsoft.Json;

namespace MsBot.Vo.Events.MetaEvent;

/// <summary>
/// 元事件上报
/// </summary>
public class MetaEventReqVo : BaseReqVo
{
    /// <summary>
    /// 元数据类型
    /// </summary>
    [JsonProperty("meta_event_type")]
    public MetaEventTypeVo MetaEventType { get; set; }

    public override string Template => "MetaEvent";
}

/// <summary>
/// 元数据类型
/// </summary>
public enum MetaEventTypeVo
{
    /// <summary>
    /// 生命周期
    /// </summary>
    [JsonProperty("lifecycle")]
    LifeCycle,

    /// <summary>
    /// 心跳包
    /// </summary>
    [JsonProperty("heartbeat")]
    HeartBeat
}