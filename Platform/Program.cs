using Platform;
using Platform.Services;


var builder = WebApplication.CreateBuilder(args);


builder.Services.AddSingleton<IResponseFormatter, TextResponseFormatter>();
var app = builder.Build();


app.UseMiddleware<WeatherMiddlware>();

//IResponseFormatter formatter = new TextResponseFormatter();

app.MapGet("middleware/function", async (HttpContext context, IResponseFormatter formatter) =>
{
    await formatter.Format(context, "MiddleWareFunctrion it is snowing in chigaco");
 
});;

app.MapGet("endpoint/class", WeatherEndpoint.Endpoint);

app.MapGet("endpoint/function", async (HttpContext context, IResponseFormatter formatter) =>
{
    await formatter.Format(context, "Endpoint Function: It is sunny in LA");

});

//app.MapGet("capital/{country}", Capital.Endpoint);
//app.MapGet("population/{city}",Population.Endpoint)
//    .WithMetadata(new RouteNameMetadata("population"));

app.MapFallback(async context => {
    await context.Response.WriteAsync("Routed to fallback endpoint");
});
app.Run();