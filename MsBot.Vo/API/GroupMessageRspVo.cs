using Newtonsoft.Json;

namespace MsBot.Vo.API;

public class GroupMessageRspVo
{
    [JsonProperty("message_id")]
    public int MessageId { get;set; }
}
