using Newtonsoft.Json;

namespace MsBot.Vo.API;

public class Result<T>
{
    /// <summary>
    /// 数据
    /// </summary>
    [JsonProperty("data")]
    public T Data { get; set; }

    /// <summary>
    /// 响应码
    /// </summary>
    [JsonProperty("retCode")]
    public int RetCode { get; set; }

    /// <summary>
    /// 状态
    /// </summary>
    [JsonProperty("status")]
    public string Status { get; set; }
}