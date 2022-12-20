using MsBot.Implementation.Configuration;
using MsBot.Implementation.Template;
using MsBot.Implementation.Template.Razor;
using MsBot.Vo.Events;
using Newtonsoft.Json.Linq;
using System.Collections;

namespace MsBot.Implementation.Event;

public abstract class EventAction
{
    public abstract string PostType { get; }
    public MsBotConfig BotConfig { get; }
    protected IRazorLightEngine Engine { get; }

    protected EventAction(MsBotConfig botConfig, IRazorLightEngine engine)
    {
        BotConfig = botConfig;
        Engine = engine;
    }

    protected string Render<TRequest>(JObject reqObj)
        where TRequest : BaseReqVo
    {
        var request = reqObj.ToObject<TRequest>();
        if (request == null)
            return string.Empty;

        var filePath = $"Templates/{BotConfig.RenderEngine}/{PostType}/{request.Template}.cshtml";

        if (BotConfig.RenderEngine == "Razor")
        {
            return Engine.CompileRenderAsync(filePath, request).Result;
        }
        else if (BotConfig.RenderEngine == "NVelocity")
        {
            var engine = NVelocityEngine.Create(filePath);
            var templatePath = Path.Combine(filePath, request.Template + ".vm");
            return engine.AccessTemplate(templatePath, new Hashtable
            {
                { "Request", request },
                { "BotConfig", BotConfig }
            });
        }
        else
            throw new Exception("不受支持的模板引擎");
    }

    public abstract string Invoke(JObject reqObj);
}