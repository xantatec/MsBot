using Microsoft.Extensions.Configuration;
using MsBot.Implementation.Configuration;
using MsBot.Implementation.Event;
using MsBot.Implementation.Event.Actions;
using MsBot.Implementation.Template;
using MsBot.Implementation.Template.Razor;
using MsBot.Vo.Events;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();


builder.Services.AddTransient<MessageEventAction>();
builder.Services.AddTransient<MetaEventAction>();
builder.Services.AddTransient<NoticeEventAction>();
builder.Services.AddTransient<RequestEventAction>();
builder.Services.AddTransient<IMsBotEventHandler, MsBotEventHandler>();

var config = builder.Configuration.GetSection("MsBot").Get<MsBotConfig>();
builder.Services.AddSingleton(config);
var engine = new RazorLightEngineBuilder()
    .UseFileSystemProject(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Templates"))
    .UseMemoryCachingProvider()
    .Build();

builder.Services.AddSingleton(engine);
var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseAuthorization();

app.MapControllers();

app.Run();
