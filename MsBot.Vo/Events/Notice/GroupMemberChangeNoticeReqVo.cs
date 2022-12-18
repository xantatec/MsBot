using Newtonsoft.Json;

namespace MsBot.Vo.Events.Notice;

public class GroupMemberChangeNoticeReqVo : NoticeReqVo
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
    /// 操作者 QQ 号
    /// </summary>
    [JsonProperty("operator_id")]
    public long OperatorId { get; set; }

    public override string Template => "GroupMemberChange";
}


public enum GroupMemberChangeNoticeSubType
{
    /// <summary>
    /// 主动退群
    /// </summary>
    [JsonProperty("leave")]
    Leave,

    /// <summary>
    /// 成员被踢
    /// </summary>
    [JsonProperty("kick")]
    Kick,

    /// <summary>
    /// 登录号被踢
    /// </summary>
    [JsonProperty("kick_me")]
    KickMe,

    /// <summary>
    /// 管理员已同意入群
    /// </summary>
    [JsonProperty("approve")]
    Approve,

    /// <summary>
    /// 管理员邀请入群
    /// </summary>
    [JsonProperty("invite")]
    Invite
}