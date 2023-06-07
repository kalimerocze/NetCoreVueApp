using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;
using VueApp;
using VueApp.Context;
using Microsoft.AspNetCore.Authentication.Negotiate;
//
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAuthentication(NegotiateDefaults.AuthenticationScheme)
   .AddNegotiate();
builder.Services.AddAuthorization(options =>
{
    // By default, all incoming requests will be authorized according to the default policy.
    options.FallbackPolicy = options.DefaultPolicy;
});
// Add your logging handler
builder.Host.ConfigureLogging(builder =>
{   
    builder.SetMinimumLevel(LogLevel.Trace);
    builder.AddLog4Net("log4net.config");
});
builder.Configuration.AddJsonFile($"AppSettings.json", true, true);
builder.Services.AddDbContext<VueAppDbContext>(options => options.UseSqlServer(builder.Configuration["DevConnection"]));
builder.Services.Configure<AppSettingsModel>(builder.Configuration.GetSection("ApplicationSettings"));
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
//builder.Services.AddScoped<IClaimsTransformer, MyClaimsTransformer>(); 

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseStaticFiles();//enables static file to be served on client
app.UseHttpsRedirection();
app.UseRouting();//
app.UseAuthentication();
app.UseAuthorization();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();//is used to map any attributes that may exist on the controllers, like, [Route], [HttpGet], etc.
    endpoints.MapFallbackToFile("Index.html");
});
app.Run();
