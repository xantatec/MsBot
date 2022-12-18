using Newtonsoft.Json;

namespace MsBot.Vo.Events;

/// <summary>
/// 上报类型
/// </summary>
public enum PostTypeVo
{
    /// <summary>
    /// 消息, 例如, 群聊消息
    /// </summary>
    [JsonProperty("message")]
    Message,

    /// <summary>
    /// 请求, 例如, 好友申请
    /// </summary>
    [JsonProperty("request")]
    Request,

    /// <summary>
    /// 通知, 例如, 群成员增加
    /// </summary>
    [JsonProperty("notice")]
    Notice,
    
    /// <summary>
    /// 元事件, 例如, go-cqhttp 心跳包
    /// </summary>
    [JsonProperty("meta_event")]
    MetaEvent
}
