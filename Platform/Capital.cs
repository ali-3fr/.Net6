using System.Diagnostics.Metrics;

namespace Platform
{
    public class Capital
    {

        public static async Task Endpoint(HttpContext httpContext)
        {
            string? captial = null;

            string? country = httpContext.Request.RouteValues["country"] as string;

            switch((country ?? "").ToLower()){
                case "uk":
                    captial = "London";
                    break;
                case "frarnce":
                    captial = "paris";
                    break;
                case "monaco":
                    LinkGenerator? generator = httpContext.RequestServices.GetService<LinkGenerator>();
                    string? url = generator?.GetPathByRouteValues(httpContext, "population", new {city=country});

                    if(url != null)
                    {
                        httpContext.Response.Redirect(url);
                    }

                    return;
            }


            if (captial != null)
            {
                await httpContext.Response.WriteAsync($"{captial} is the capital of {country}");
            }
            else
            {
                httpContext.Response.StatusCode = StatusCodes.Status404NotFound;
            }
        }



    }
}
