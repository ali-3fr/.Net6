namespace Platform
{
    public class QueryStringMiddleWare
    {
        private RequestDelegate? next;

        public QueryStringMiddleWare()
        {

        }

        public QueryStringMiddleWare(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            if(context.Request.Method == HttpMethods.Get && context.Request.Query["custom"] == "true")
            {
                if (!context.Response.HasStarted)
                {
                    context.Response.ContentType = "text/plain";

                }
                await context.Response.WriteAsync("class-Based middleWare \n");
            }
            if(next != null)
            {
                await next(context);
            }
        }
    }
}
