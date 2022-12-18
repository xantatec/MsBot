using Newtonsoft.Json;

namespace MsBot.Vo.Events.Notice;

/// <summary>
/// 群文件上传
/// </summary>
public class GroupFileUploadNoticeReqVo : NoticeReqVo
{
    /// <summary>
    /// 群号
    /// </summary>
    [JsonProperty("group_id")]
    public long GroupId { get; set; }

    /// <summary>
    /// 发送者 QQ 号
    /// </summary>
    [JsonProperty("user_id")]
    public long UserId { get; set; }

    /// <summary>
    /// 文件信息
    /// </summary>
    [JsonProperty("file")]
    public FileVo File { get; set; }

    public override string Template => "GroupFileUpload";
}

/// <summary>
/// 文件信息
/// </summary>
public class FileVo
{
    /// <summary>
    /// 文件 ID
    /// </summary>
    [JsonProperty("id")]
    public string Id { get; set; }

    /// <summary>
    /// 文件名
    /// </summary>
    [JsonProperty("name")]
    public string Name { get; set; }

    /// <summary>
    /// 文件大小 ( 字节数 )
    /// </summary>
    [JsonProperty("size")]
    public long Size { get; set; }

    /// <summary>
    /// busid ( 目前不清楚有什么作用 )
    /// </summary>
    [JsonProperty("busid")]
    public long BusId { get; set; }
}
