using Platform.Services;

namespace Platform
{
    public class WeatherMiddlware
    {
        private RequestDelegate next;
        private IResponseFormatter formatter;
        public WeatherMiddlware(RequestDelegate next, IResponseFormatter _formatter)
        {
            formatter = _formatter;
            this.next = next;
        }
        public async Task Invoke(HttpContext context)
        {
            if(context.Request.Path == "/middleware/class")
            {
                await formatter.Format(context, "Middleware Class: It is raining in London");
            }
            else
            {
                await next(context);
            }
        }
    }
}
