using Newtonsoft.Json;

namespace MsBot.Vo.API;

public class MsgReqVo
{
    [JsonProperty("message_id")]
    public long MessageId { get; set; }
}