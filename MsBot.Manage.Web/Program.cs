using MsBot.Domain;
using MsBot.Implementation.MySql;
using MsBot.Implementation.MySql.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation().AddNewtonsoftJson(opt =>
{
    opt.UseMemberCasing();
    opt.SerializerSettings.DateFormatString = "yyyy-MM-dd HH:mm:ss";
});

builder.Services.AddScoped<MsgSummaryRepository>();
builder.Services.AddScoped<IRepositoryContextProvider, RepositoryContextProvider>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if(!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Account}/{action=Login}/{id?}");

app.Run();
