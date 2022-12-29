using MsBot.Vo.Plugins;
using Newtonsoft.Json;

namespace MsBot.Vo.Events.Notice;

/// <summary>
/// 精华消息
/// </summary>
public class CreamMsgNoticeReqVo: NoticeReqVo
{
    /// <summary>
    /// 消息发送者ID
    /// </summary>
    [JsonProperty("sender_id")]
    public long SenderId { get; set; }

    /// <summary>
    /// 发送者 QQ 号
    /// </summary>
    [JsonProperty("sub_type"), JsonConverter(typeof(MsBotEnumConverter))]
    public CreamMsgSubType SubType { get; set; }

    /// <summary>
    /// 操作者ID
    /// </summary>
    [JsonProperty("operator_id")]
    public long OperatorId { get; set; }

    /// <summary>
    /// 消息ID
    /// </summary>
    [JsonProperty("message_id")]
    public long MessageId { get; set; }

    public override string Template => "CreamMsg";
}

public enum CreamMsgSubType
{
    /// <summary>
    /// 添加
    /// </summary>
    [JsonProperty("add")]
    Add,

    /// <summary>
    /// 移出
    /// </summary>
    [JsonProperty("delete")]
    Delete
}