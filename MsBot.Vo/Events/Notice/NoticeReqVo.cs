using MsBot.Vo.Plugins;
using Newtonsoft.Json;

namespace MsBot.Vo.Events.Notice;

/// <summary>
/// 通知上报
/// </summary>
public abstract class NoticeReqVo : BaseReqVo
{
    /// <summary>
    /// 通知类型
    /// </summary>
    [JsonProperty("notice_type"), JsonConverter(typeof(MsBotEnumConverter))]
    public NoticeTypeVo NoticeType { get; set; }
}

/// <summary>
/// 通知类型
/// </summary>
public enum NoticeTypeVo
{
    /// <summary>
    ///群文件上传
    /// </summary>
    [JsonProperty("group_upload")]
    GroupUpload,

    /// <summary>
    ///群管理员变更
    /// </summary>
    [JsonProperty("group_admin")]
    GroupAdmin,

    /// <summary>
    ///群成员减少
    /// </summary>
    [JsonProperty("group_decrease")]
    GroupDecrease,

    /// <summary>
    ///群成员增加
    /// </summary>
    [JsonProperty("group_increase")]
    GroupIncrease,

    /// <summary>
    ///群成员禁言
    /// </summary>
    [JsonProperty("group_ban")]
    GroupBan,

    /// <summary>
    ///好友添加
    /// </summary>
    [JsonProperty("friend_add")]
    FriendAdd,

    /// <summary>
    ///群消息撤回
    /// </summary>
    [JsonProperty("group_recall")]
    GroupRecall,

    /// <summary>
    ///好友消息撤回
    /// </summary>
    [JsonProperty("friend_recall")]
    FriendRecall,

    /// <summary>
    ///群名片变更
    /// </summary>
    [JsonProperty("group_card")]
    GroupCard,

    /// <summary>
    ///离线文件上传
    /// </summary>
    [JsonProperty("offline_file")]
    OfflineFile,

    /// <summary>
    ///客户端状态变更
    /// </summary>
    [JsonProperty("client_status")]
    ClientStatus,

    /// <summary>
    ///精华消息
    /// </summary>
    [JsonProperty("essence")]
    Essence,

    /// <summary>
    ///系统通知
    /// </summary>
    [JsonProperty("notify")]
    Notify
}