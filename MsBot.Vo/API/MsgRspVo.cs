using Newtonsoft.Json;

namespace MsBot.Vo.API;

public class MsgRspVo
{
    /// <summary>
    /// 是否是群消息
    /// </summary>
    [JsonProperty("group")]
    public bool Group { get; set; }

    /// <summary>
    /// 消息id
    /// </summary>
    [JsonProperty("message_id")]
    public int MessageId { get; set; }

    /// <summary>
    /// 消息真实id
    /// </summary>
    [JsonProperty("real_id")]
    public int RealId { get; set; }

    /// <summary>
    ///  群消息时为group, 私聊消息为private
    /// </summary>
    [JsonProperty("message_type")]
    public string MessageType { get; set; }

    /// <summary>
    /// 发送者
    /// </summary>
    [JsonProperty("sender")]
    public MsgSenderVo Sender { get; set; }

    /// <summary>
    /// 发送时间
    /// </summary>
    [JsonProperty("time")]
    public int Time { get; set; }

    /// <summary>
    /// 消息内容
    /// </summary>
    [JsonProperty("message")]
    public string Message { get; set; }

    /// <summary>
    /// 原始消息内容
    /// </summary>
    [JsonProperty("raw_message")]
    public string RawMessage { get; set; }
}

public class MsgSenderVo
{
    /// <summary>
    /// 发送者昵称
    /// </summary>
    [JsonProperty("nickname")]
    public string Nickname { get; set; }

    /// <summary>
    /// 发送者 QQ 号
    /// </summary>
    [JsonProperty("user_id")]
    public long UserId { get; set; }
}