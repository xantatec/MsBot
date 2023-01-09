using MsBot.Infrastructure;
using MsBot.Vo.API;

namespace MsBot.Implementation.API
{
    public class APIHelper
    {
        public static APIHelper Instance { get; private set; }

        private readonly string CQ_HTTP_URL;

        private APIHelper(string url)
        {
            CQ_HTTP_URL = url.TrimEnd('/');
        }

        public static void Initialize(string url)
        {
            Instance = new APIHelper(url);
        }

        /// <summary>
        /// 发送群消息
        /// </summary>
        public Result<GroupMessageRspVo> SendGroupMsg(GroupMessageReqVo groupMsg)
        {
            var url = CQ_HTTP_URL + "/send_group_msg";
            var strResult = RequestHelper.Instance.WebRequest(url, "POST", parameter: groupMsg);
            return SerializerHelper.Instance.JsonDeserialize<Result<GroupMessageRspVo>>(strResult);
        }

        /// <summary>
        /// 获取群成员列表
        /// </summary>
        public Result<List<GroupMemberRspVo>> GetGroupMembers(GroupMessageReqVo groupMsg)
        {
            var url = CQ_HTTP_URL + "/get_group_member_list";
            var strResult = RequestHelper.Instance.WebRequest(url, "POST", parameter: groupMsg);
            return SerializerHelper.Instance.JsonDeserialize<Result<List<GroupMemberRspVo>>>(strResult);
        }

        /// <summary>
        /// 获取群成员信息
        /// </summary>
        public Result<GroupMemberRspVo> GetGroupMember(GroupMemberReqVo groupMember)
        {
            var url = CQ_HTTP_URL + "/get_group_member_info";
            var strResult = RequestHelper.Instance.WebRequest(url, "POST", parameter: groupMember);
            return SerializerHelper.Instance.JsonDeserialize<Result<GroupMemberRspVo>>(strResult);
        }

        /// <summary>
        /// 获取群成员信息
        /// </summary>
        public Result<MsgRspVo> GetMsg(MsgReqVo msg)
        {
            var url = CQ_HTTP_URL + "/get_msg";
            var strResult = RequestHelper.Instance.WebRequest(url, "POST", parameter: msg);
            return SerializerHelper.Instance.JsonDeserialize<Result<MsgRspVo>>(strResult);
        }
    }
}