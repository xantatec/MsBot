using Newtonsoft.Json;

namespace MsBot.Vo.Events.Notice;

/// <summary>
/// 群成员名片更新
/// </summary>
public class GroupMemberCardNoticeReqVo : NoticeReqVo
{
    /// <summary>
    /// 成员id
    /// </summary>
    [JsonProperty("user_id")]
    public long UserId { get; set; }

    /// <summary>
    /// 群号
    /// </summary>
    [JsonProperty("group_id")]
    public long GroupId { get; set; }

    /// <summary>
    /// 新名片
    /// </summary>
    [JsonProperty("card_new")]
    public long CardNew { get; set; }

    /// <summary>
    /// 旧名片
    /// </summary>
    [JsonProperty("card_old")]
    public long CardOld { get; set; }

    public override string Template => "GroupMemberCard";
}