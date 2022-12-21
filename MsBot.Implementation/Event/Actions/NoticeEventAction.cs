using MsBot.Implementation.Configuration;
using MsBot.Implementation.Template.Razor;
using MsBot.Vo.Events.Notice;
using Newtonsoft.Json.Linq;

namespace MsBot.Implementation.Event.Actions;

public class NoticeEventAction : EventAction
{
    public NoticeEventAction(MsBotConfig botConfig, RazorLightEngine engine)
        : base(botConfig, engine)
    {
    }

    public override string PostType => "Notice";

    public override string Invoke(JObject reqObj)
    {
        var noticeTypeObj = reqObj["notice_type"];
        if (noticeTypeObj == null)
            return string.Empty;

        var noticeType = noticeTypeObj.ToString();
        switch (noticeType)
        {
            case "group_admin":
                return Render<GroupAdminNoticeReqVo>(reqObj);

            case "group_decrease":
            case "group_increase":
                return Render<GroupMemberChangeNoticeReqVo>(reqObj);

            case "group_ban":
                return Render<GroupBanNoticeReqVo>(reqObj);

            case "friend_add":
                return Render<FriendAddNoticeReqVo>(reqObj);

            case "group_recall":
                return Render<GroupMsgRecallNoticeReqVo>(reqObj);

            case "friend_recall":
                return Render<FriendMsgRecallNoticeReqVo>(reqObj);

            case "notify":
                {
                    var subTypeObj = reqObj["poke"];
                    if (subTypeObj == null)
                        return string.Empty;

                    var subType = subTypeObj.ToString();
                    switch (subType)
                    {
                        case "poke":
                            {
                                var groupIdObj = reqObj["group_id"];
                                if (groupIdObj != null && !string.IsNullOrEmpty(groupIdObj.ToString()) && groupIdObj.ToString() != "0")
                                    return Render<GroupStampNoticeReqVo>(reqObj);
                                else
                                    return Render<FriendStampNoticeReqVo>(reqObj);
                            }

                        case "lucky_king":
                            return Render<RedPacketLuckNoticeReqVo>(reqObj);

                        case "honor":
                            return Render<GroupMemberHonorNoticeReqVo>(reqObj);
                        default:
                            return string.Empty;
                    }
                }


            case "group_card":
                return Render<GroupMemberCardNoticeReqVo>(reqObj);

            case "offline_file":
                return Render<ReceiveOfflineFileNoticeReqVo>(reqObj);

            case "essence":
                return Render<CreamMsgNoticeReqVo>(reqObj);

            default:
                return string.Empty;
        }
    }
}