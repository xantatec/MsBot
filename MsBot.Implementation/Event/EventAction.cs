using MsBot.Implementation.Configuration;
using MsBot.Implementation.Template;
using MsBot.Vo.Events;
using Newtonsoft.Json.Linq;
using RazorEngine.Templating;
using System.Collections;

namespace MsBot.Implementation.Event;

public abstract class EventAction
{
    private readonly IRazorEngineService _razorEngine;

    public abstract string PostType { get; }
    public MsBotConfig BotConfig { get; }

    protected EventAction(MsBotConfig botConfig, IRazorEngineService razorEngine)
    {
        BotConfig = botConfig;
        _razorEngine = razorEngine;
    }

    protected string Render<TRequest>(JObject reqObj)
        where TRequest : BaseReqVo
    {
        var request = reqObj.ToObject<TRequest>();
        if (request == null)
            return string.Empty;

        var folderPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Templates", BotConfig.RenderEngine, PostType);

        if (BotConfig.RenderEngine == "Razor")
        {
            var templatePath = Path.Combine(folderPath, request.Template + ".cshtml");
            var fi = new FileInfo(templatePath);
            if (!fi.Exists)
                throw new Exception("模板文件不存在");

            using var fs = new FileStream(templatePath, FileMode.Open, FileAccess.Read);
            using var rds = new StreamReader(fs);
            var contents = rds.ReadToEnd();

            return _razorEngine.RunCompile(new LoadedTemplateSource(contents, templatePath), templatePath, typeof(TRequest), request, null);
        }
        else if (BotConfig.RenderEngine == "NVelocity")
        {
            var templatePath = Path.Combine(folderPath, request.Template + ".vm");
            var engine = NVelocityEngine.Create();
            return engine.AccessTemplate(templatePath, new Hashtable { });
        }
        else
            throw new Exception("不受支持的模板引擎");
    }

    public abstract string Invoke(JObject reqObj);
}