using Microsoft.EntityFrameworkCore;
using VueApp;
using VueApp.Context;

var builder = WebApplication.CreateBuilder(args);//vytvori root aplikace

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
// Add your logging handler
builder.Host.ConfigureLogging(builder =>
{   // Configuration here:
    builder.SetMinimumLevel(LogLevel.Trace);
    builder.AddLog4Net("log4net.config");
});
builder.Configuration.AddJsonFile($"AppSettings.json", true, true);
builder.Services.AddDbContext<VueAppDbContext>(options => options.UseSqlServer(builder.Configuration["DevConnection"]));
builder.Services.Configure<AppSettingsModel>(builder.Configuration.GetSection("ApplicationSettings"));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseStaticFiles();//enables tatic file to be served on client
app.UseHttpsRedirection();//pøesmìruje všechny httppozadavky na https
app.UseRouting();//
app.UseAuthorization();
//app.MapRazorPages();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();//is used to map any attributes that may exist on the controllers, like, [Route], [HttpGet], etc.
    endpoints.MapFallbackToFile("Index.html");
});
app.Run();
