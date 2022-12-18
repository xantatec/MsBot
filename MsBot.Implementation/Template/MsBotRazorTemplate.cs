using MsBot.Implementation.Configuration;
using RazorEngine.Templating;

namespace MsBot.Implementation.Template;

public class MsBotRazorTemplate<T> : TemplateBase<T>
{
    public MsBotConfig BotConfig { get; set; }
    public string FolderPath { get; set; }
    public object ReturnResult { get; set; }

    public TemplateWriter Partial(string filePath)
    {
        var templatePath = Path.Combine(FolderPath, filePath + ".cshtml");
        var fi = new FileInfo(templatePath);
        if (!fi.Exists)
            throw new Exception("模板文件不存在");

        using var fs = new FileStream(templatePath, FileMode.Open, FileAccess.Read);
        using var rds = new StreamReader(fs);
        var contents = rds.ReadToEnd();

        Razor.AddTemplate(templatePath, contents);

        return base.Include(templatePath, Model, typeof(T));
    }
}