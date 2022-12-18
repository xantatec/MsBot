using Microsoft.Extensions.Configuration;
using MsBot.Implementation.Configuration;
using MsBot.Implementation.Event;
using MsBot.Implementation.Event.Actions;
using MsBot.Implementation.Template;
using RazorEngine.Configuration;
using RazorEngine.Templating;
using RazorEngine.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
var razorCfg = new TemplateServiceConfiguration
{
    Language = RazorEngine.Language.CSharp,
    EncodedStringFactory = new RawStringFactory(),
    BaseTemplateType = typeof(MsBotRazorTemplate<>)
};
var razorSvc = RazorEngineService.Create(razorCfg);

builder.Services.AddSingleton(razorSvc);

builder.Services.AddTransient<MessageEventAction>();
builder.Services.AddTransient<MetaEventAction>();
builder.Services.AddTransient<NoticeEventAction>();
builder.Services.AddTransient<RequestEventAction>();
builder.Services.AddTransient<IMsBotEventHandler, MsBotEventHandler>();

var config = builder.Configuration.GetSection("MsBot").Get<MsBotConfig>();
builder.Services.AddSingleton(config);

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseAuthorization();

app.MapControllers();

app.Run();
