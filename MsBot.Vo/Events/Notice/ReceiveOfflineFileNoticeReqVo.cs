using Newtonsoft.Json;

namespace MsBot.Vo.Events.Notice;

/// <summary>
/// 接收到离线文件
/// </summary>
public class ReceiveOfflineFileNoticeReqVo : NoticeReqVo
{
    /// <summary>
    /// 成员id
    /// </summary>
    [JsonProperty("user_id")]
    public long UserId { get; set; }

    /// <summary>
    /// 文件数据
    /// </summary>
    [JsonProperty("file")]
    public ReceiveOfflineFileVo File { get; set; }

    public override string Template => "ReceiveOffline";
}

/// <summary>
/// 文件数据
/// </summary>
public class ReceiveOfflineFileVo
{
    /// <summary>
    /// 文件名
    /// </summary>
    [JsonProperty("name")]
    public string Name { get; set; }

    /// <summary>
    /// 文件大小
    /// </summary>
    [JsonProperty("size")]
    public long Size { get; set; }

    /// <summary>
    /// 下载链接
    /// </summary>
    [JsonProperty("url")]
    public string Url { get; set; }
}