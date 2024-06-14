using static System.Net.Mime.MediaTypeNames;

namespace Platform
{
    public class Population
    {
        

        public static async Task Endpoint(HttpContext context)
        {

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

        }
    }
}
