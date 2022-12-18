using Newtonsoft.Json;

namespace MsBot.Vo.Events.Notice;

/// <summary>
/// 好友添加
/// </summary>
public class FriendAddNoticeReqVo : NoticeReqVo
{
    /// <summary>
    /// 发送者 QQ 号
    /// </summary>
    [JsonProperty("user_id")]
    public long UserId { get; set; }

    public override string Template => "FriendAdd";
}
