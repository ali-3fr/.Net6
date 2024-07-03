using Platform;
using Platform.Services;


var builder = WebApplication.CreateBuilder(args);

var serviceConfig = builder.Configuration;

var serviceEnv = builder.Environment;



//

var app = builder.Build();

var logger = app.Services.GetRequiredService<ILoggerFactory>().CreateLogger("Pipeline");

var pipelineEnv  = app.Environment;
//
logger.LogDebug("Pipeline configuration started");

app.MapGet("population/{city?}",Population.Endpoint);

logger.LogDebug("Pipeline configuration finished");



app.MapGet("/", async context => await context.Response.WriteAsync("Hello world")) ;

app.Run();