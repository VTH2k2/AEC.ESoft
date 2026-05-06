using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using AEC.Core;
using AEC.Core.Service;
using AEC.Lib.Exceptional;
using AEC.ESoft.Infra.Data;
using AEC.ESoft.Infra.Business;
using AEC.ESoft.Web.AdminHandlers;
using Microsoft.EntityFrameworkCore;
using AEC.ESoft.Web.AdminApi;

var builder = WebApplication.CreateBuilder(args);
builder.Configuration.AddJsonFile("exceptional.json", optional: false, reloadOnChange: true);
builder.Configuration.AddJsonFile($"exceptional.{builder.Environment.EnvironmentName}.json", optional: true, reloadOnChange: true);
builder.ConfigureAppCore();

// Add services to the container.
builder.Services.AddCors(o => o.AddPolicy("AllowAll", builder =>
{
    builder.AllowAnyOrigin()
           .AllowAnyMethod()
           .AllowAnyHeader()
           .WithExposedHeaders("Content-Disposition"); // content-disposition is *exposed* (and allowed because of AllowAnyHeader)
}));
builder.Services.AddHealthChecks();
builder.Services.AddControllers().AddNewtonsoftJson(options =>
{
    var contractResolver = new DefaultContractResolver();
    // Configure Newtonsoft.Json options here
    options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
    options.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
    options.SerializerSettings.DateTimeZoneHandling = DateTimeZoneHandling.Unspecified;
    options.SerializerSettings.ContractResolver = contractResolver; // For api
    options.SerializerSettings.ContractResolver =
                new Newtonsoft.Json.Serialization.CamelCasePropertyNamesContractResolver();

    // For other json convert
    JsonConvert.DefaultSettings = () => new JsonSerializerSettings
    {
        ContractResolver = contractResolver
    };
});

//services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
//services.AddSingleton<IActionContextAccessor, ActionContextAccessor>();
builder.Services.AddHttpContextAccessor();
builder.Services.Configure<ForwardedHeadersOptions>(options =>
{
    options.ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto;

    // Only loopback proxies are allowed by default.
    // Clear that restriction because forwarders are enabled by explicit 
    // configuration.
    options.KnownNetworks.Clear();
    options.KnownProxies.Clear();
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddExceptionHandler<WebAdminExceptionsHandler>();
builder.Services.AddLibExceptional();
//builder.Services.AddLibRedisCache(true);
builder.Services.AddInfraRepositories();
builder.Services.AddInfraServices();
builder.Services.AddWebAdminHandlers();

var app = builder.Build();
app.UseExceptionHandler(o => { });

// If development mode
if (app.Environment.IsDevelopment())
{
    app.UseCors("AllowAll");
}

// Forwarded all headers
app.UseForwardedHeaders();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();
app.MapHealthChecks("/health");
//app.MapFallbackToFile("index.html");

app.Run();
