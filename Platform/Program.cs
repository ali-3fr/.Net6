var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.Use(async(context, next) =>
{
    await next();
    await context.Response.WriteAsync($"\n Status Code : {context.Response.StatusCode}");


});

((IApplicationBuilder)app).Map("/branch", branch =>
{
    branch.UseMiddleware<Platform.QueryStringMiddleWare>();
    branch.Run(async (HttpContext context) =>
    {
        await context.Response.WriteAsync("Branch MiddleWare");
    });
});
//app.Use(async(context, next) =>
//{
//    if(context.Request.Path == "/short")
//    {
//        await context.Response.WriteAsync("short circuted");
//    }
//    else
//    {
//        await next();
//    }
//});

//app.Use((async(context, next) =>
//{
//    if(context.Request.Method == HttpMethods.Get && context.Request.Query["custom"] == "true")
//    {
//        context.Response.ContentType = "text/plain";
//        await context.Response.WriteAsync("Custome MiddleWare \n");
//    }
//    await next();
//}));

app.UseMiddleware<Platform.QueryStringMiddleWare>();

app.MapGet("/", () => "Hello World!");

app.Run();
