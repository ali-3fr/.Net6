using Microsoft.AspNetCore.Http.Features;

namespace Platform
{
    public class ConsentMiddleware
    {
        private RequestDelegate _next;
        public ConsentMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            if (context.Request.Path == "/consent")
            {
                ITrackingConsentFeature? trackingConsentFeature = context.Features.Get<ITrackingConsentFeature>();

                if(trackingConsentFeature != null)
                {
                    if (!trackingConsentFeature.HasConsent)
                    {
                        trackingConsentFeature.GrantConsent();
                    }
                    else
                    {
                        trackingConsentFeature.WithdrawConsent();
                    }

                    await context.Response.WriteAsync(trackingConsentFeature.HasConsent  ? "Consent Granted \n" : "Consent Withdrawn\n");

                }

            }
            else
            {
                await _next(context);
            }
        }
    }
}
