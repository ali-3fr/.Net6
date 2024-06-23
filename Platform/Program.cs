using Platform;
using Platform.Services;


var builder = WebApplication.CreateBuilder(args);

var serviceConfig = builder.Configuration;

var serviceEnv = builder.Environment;


//

var app = builder.Build();

var pipelineEnv  = app.Environment;
//

app.UseMiddleware<LocationMiddleware>();

app.MapGet("config", async (HttpContext context , IConfiguration config, IWebHostEnvironment env) =>
{
    var defaultConfig = config["Logging:LogLevel:Default"];
    await context.Response.WriteAsync($"default settings is {defaultConfig} \n");

    await context.Response.WriteAsync($"the env setting is {env.EnvironmentName}");

});

app.MapGet("/", async context => await context.Response.WriteAsync("Hello world")) ;

app.Run();