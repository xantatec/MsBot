using Newtonsoft.Json;

namespace MsBot.Vo.Events.Message;

public class GroupMsgRspVo: MsgRspVo
{
    /// <summary>
    /// 是否要在回复开头 at 发送者 ( 自动添加 ) , 发送者是匿名用户时无效
    /// </summary>
    [JsonProperty("at_sender")]
    public bool AtSender { get; set; }

    /// <summary>
    /// 撤回该条消息
    /// </summary>
    [JsonProperty("delete")]
    public bool Delete { get; set; }

    /// <summary>
    /// 把发送者踢出群组 ( 需要登录号权限足够 ) , 不拒绝此人后续加群请求, 发送者是匿名用户时无效
    /// </summary>
    [JsonProperty("kick")]
    public bool Kick { get; set; }

    /// <summary>
    /// 把发送者禁言 ban_duration 指定时长, 对匿名用户也有效
    /// </summary>
    [JsonProperty("ban")]
    public bool Ban { get; set; }

    /// <summary>
    /// 禁言时长
    /// </summary>
    [JsonProperty("ban_duration")]
    public double BanDuration { get; set; }
}