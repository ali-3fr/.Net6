using Platform.Services;

namespace Platform
{
    public class WeatherEndpoint
    {
        private IResponseFormatter _responseFormatter;
        public WeatherEndpoint(IResponseFormatter responseFormatter)
        {
            _responseFormatter = responseFormatter;
        }

        public async Task Endpoint(HttpContext context)
        {
                
            await _responseFormatter.Format(context, "Endpoint Class : It is clody in Milan");
        }
    }
}
