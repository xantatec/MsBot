namespace MsBot.Implementation.Configuration;

public class MsBotConfig
{
    /// <summary>
    /// go-cqhttp地址
    /// </summary>
    public string CqHttpUrl { get; set; }

    /// <summary>
    /// 机器人名称
    /// </summary>
    public string BotName { get; set; }

    /// <summary>
    /// 机器人版本
    /// </summary>
    public string BotVersion { get; set; }

    /// <summary>
    /// 机器人QQ
    /// </summary>
    public string BotQQ { get; set; }

    /// <summary>
    /// 机器人管理员
    /// </summary>
    public List<string> BotMaster { get; set; }

    /// <summary>
    /// 机器人渲染引擎
    /// </summary>
    public string RenderEngine { get; set; }    

    /// <summary>
    /// 链接字符串
    /// </summary>
    public string ConnectionString { get; set; }

    /// <summary>
    /// 图片地址
    /// </summary>
    public string ImageFolder { get; set; }
}