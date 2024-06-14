using Platform;
var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<RouteOptions>(opt =>
{
    opt.ConstraintMap.Add("countryName", typeof(CountryRouteConstraint));
});

var app = builder.Build();


app.MapGet("capital/{country:countryName}", Capital.Endpoint).Add(b => ((RouteEndpointBuilder)b).Order = 1);


app.MapGet("capital/{country:regex(^uk|france|monaco$)}", Capital.Endpoint);
app.MapGet("population/{city}",Population.Endpoint)
    .WithMetadata(new RouteNameMetadata("population"));

app.MapFallback(async context => {
    await context.Response.WriteAsync("Routed to fallback endpoint");
});
app.Run();