using Newtonsoft.Json;

namespace MsBot.Vo.Events.Message;

/// <summary>
/// 消息上报
/// </summary>
public abstract class MsgReqVo : BaseReqVo
{
    /// <summary>
    /// 消息类型
    /// </summary>
    [JsonProperty("message_type")]
    public MessageTypeVo MessageType { get; set; }

    /// <summary>
    /// 消息的子类型
    /// </summary>
    [JsonProperty("sub_type")]
    public MessageSubTypeVo SubType { get; set; }

    /// <summary>
    /// 消息ID
    /// </summary>
    [JsonProperty("message_id")]
    public int MessageId { get; set; }

    /// <summary>
    /// 发送者 QQ 号
    /// </summary>
    [JsonProperty("user_id")]
    public long UserId { get; set; }

    /// <summary>
    /// 一个消息链
    /// </summary>
    [JsonProperty("message")]
    public string Message { get; set; }

    /// <summary>
    /// CQ 码格式的消息
    /// </summary>
    [JsonProperty("raw_message")]
    public string RawMessage { get; set; }

    /// <summary>
    /// 字体
    /// </summary>
    [JsonProperty("font")]
    public int Font { get; set; }

    /// <summary>
    /// 发送者信息
    /// </summary>
    [JsonProperty("sender")]
    public MessageSenderVo Sender { get; set; }
}

public class MessageSenderVo
{
    /// <summary>
    /// 发送者 QQ 号
    /// </summary>
    [JsonProperty("user_id")]
    public long UserId { get; set; }

    /// <summary>
    /// 昵称
    /// </summary>
    [JsonProperty("nickname")]
    public string NickName { get; set; }

    /// <summary>
    /// 性别
    /// </summary>
    [JsonProperty("sex")]
    public string Sex { get; set; }

    /// <summary>
    /// 年龄
    /// </summary>
    [JsonProperty("age")]
    public int Age { get; set; }

    /// <summary>
    /// 临时群消息来源群号-当私聊类型为群临时会话时的额外字段
    /// </summary>
    [JsonProperty("group_id")]
    public long GroupId { get; set; }

    /// <summary>
    /// 群名片/备注-群聊
    /// </summary>
    [JsonProperty("card")]
    public string Card { get; set; }

    /// <summary>
    /// 地区-群聊
    /// </summary>
    [JsonProperty("area")]
    public string Area { get; set; }

    /// <summary>
    /// 成员等级-群聊
    /// </summary>
    [JsonProperty("level")]
    public string Level { get; set; }

    /// <summary>
    /// 角色 owner 或 admin 或 member-群聊
    /// </summary>
    [JsonProperty("role")]
    public string Role { get; set; }

    /// <summary>
    /// 专属头衔-群聊
    /// </summary>
    [JsonProperty("title")]
    public string Title { get; set; }
}

/// <summary>
/// 消息类型
/// </summary>
public enum MessageTypeVo
{
    /// <summary>
    /// 私聊消息
    /// </summary>
    [JsonProperty("private")]
    Private,

    /// <summary>
    /// 群消息
    /// </summary>
    [JsonProperty("group")]
    Group
}

/// <summary>
/// 
/// </summary>
public enum MessageSubTypeVo
{
    /// <summary>
    /// 好友
    /// </summary>
    [JsonProperty("friend")]
    Friend,

    /// <summary>
    /// 群聊
    /// </summary>
    [JsonProperty("normal")]
    Normal,

    /// <summary>
    /// 匿名
    /// </summary>
    [JsonProperty("anonymous")]
    Anonymous,

    /// <summary>
    /// 群中自身发送
    /// </summary>
    [JsonProperty("group_self")]
    GroupSelf,

    /// <summary>
    /// 群临时会话
    /// </summary>
    [JsonProperty("group")]
    Group,

    /// <summary>
    /// 系统提示
    /// </summary>
    [JsonProperty("notice")]
    Notice
}