using Newtonsoft.Json;

namespace MsBot.Vo.API;

public class GroupMemberReqVo
{
    /// <summary>
    /// 群号
    /// </summary>
    [JsonProperty("group_id")]
    public long GroupId { get; set; }

    /// <summary>
    /// 用户ID
    /// </summary>
    [JsonProperty("user_id")]
    public long UserId { get; set; }
}
