using Newtonsoft.Json;

namespace MsBot.Vo.Events.Request;

public class AddGroupRequestReqVo : RequestReqVo
{
    /// <summary>
    /// 发送请求的 QQ 号
    /// </summary>
    [JsonProperty("user_id")]
    public long UserId { get; set; }

    /// <summary>
    /// 群号
    /// </summary>
    [JsonProperty("group_id")]
    public long GroupId { get; set; }

    /// <summary>
    /// 验证信息
    /// </summary>
    [JsonProperty("comment")]
    public string Comment { get; set; }

    /// <summary>
    /// 请求 flag, 在调用处理请求的 API 时需要传入
    /// </summary>
    [JsonProperty("flag")]
    public long Flag { get; set; }

    public override string Template => "AddGroup";
}