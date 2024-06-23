using System.Reflection;

namespace Platform.Services
{
    public static class EndpointExtensions
    {
        public static void MapEndpoint<T>(this IEndpointRouteBuilder app, string path, string methodName = "Endpoint")
        {
            MethodInfo? methodInfo = typeof(T).GetMethod(methodName);
            if(methodInfo == null || methodInfo.ReturnType != typeof(Task))
            {
                throw new Exception("method cannot be used");
            }

            T endpointInstace = ActivatorUtilities.CreateInstance<T>(app.ServiceProvider);

            app.MapGet(path, (RequestDelegate)methodInfo.CreateDelegate(typeof(RequestDelegate), endpointInstace));

        }
    }
}
