using MsBot.Vo.Plugins;
using Newtonsoft.Json;

namespace MsBot.Vo.Events.Notice;

/// <summary>
/// 群管理员变动
/// </summary>
public class GroupAdminNoticeReqVo : NoticeReqVo
{
    /// <summary>
    /// 事件子类型
    /// </summary>
    [JsonProperty("sub_type"), JsonConverter(typeof(MsBotEnumConverter))]
    public GroupAdminNoticeSubTypeVo SubType { get; set; }

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

    public override string Template => "GroupAdmin";
}

public enum GroupAdminNoticeSubTypeVo
{
    /// <summary>
    /// 设置
    /// </summary>
    [JsonProperty("set")]
    Set,

    /// <summary>
    /// 取消
    /// </summary>
    [JsonProperty("unset")]
    UnSet
}