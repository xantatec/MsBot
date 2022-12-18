using Newtonsoft.Json;

namespace MsBot.Vo.Events.Request;

/// <summary>
/// 请求上报
/// </summary>
public abstract class RequestReqVo : BaseReqVo
{
    /// <summary>
    /// 请求类型
    /// </summary>
    [JsonProperty("request_type")]
    public RequestTypeVo RequestType { get; set; }
}

/// <summary>
/// 请求类型
/// </summary>
public enum RequestTypeVo
{
    /// <summary>
    /// 好友请求
    /// </summary>
    [JsonProperty("friend")]
    Friend,

    /// <summary>
    /// 群请求
    /// </summary>
    [JsonProperty("group")]
    Group
}
