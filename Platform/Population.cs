using static System.Net.Mime.MediaTypeNames;

namespace Platform
{
    public partial class Population
    {
        

        public static async Task Endpoint(HttpContext context, ILogger<Population> logger)
        {

            //logger.LogDebug($"Started processing for {context.Request.Path}");

            StartingResponse(logger, context.Request.Path );

            int? population =  null;
            string? city = context.Request.RouteValues["city"] as string ?? "london";



            switch((city.ToLower() ?? "").ToLower())
            {
                case "london":
                    population = 8_136_000;
                    break;
                case "paris":
                    population = 2_141_000;
                    break;
                case "monaco":
                    population = 39_000;
                    break;
            }

            if (population.HasValue)
            {
                await context.Response.WriteAsync($"City :{city} , Population : {population}");
            }
            else {
                context.Response.StatusCode = StatusCodes.Status404NotFound;
            }
            logger.LogDebug($"Finished Proccessing for {context.Request.Path}");

        }

        [LoggerMessage(0, LogLevel.Debug, "Starting response for {path}")]
        public static partial void StartingResponse(ILogger logger, string path);
    }
}
