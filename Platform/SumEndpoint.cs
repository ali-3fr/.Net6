using Microsoft.Extensions.Caching.Distributed;
using Platform.Services;
using Platform.Models;
namespace Platform
{
    public class SumEndpoint
    {
        public async Task Endpoint(HttpContext context, CalculationContext calcContext)
        {
            int count;
            int.TryParse((string?)context.Request.RouteValues["count"],
            out count);

            long total = calcContext.Calculations.FirstOrDefault(a => a.Count == count)?.Result ?? 0;
            if (total == 0)
            {
                for (int i = 1; i <= count; i++)
                {
                    total += i;
                }
                calcContext.Calculations.Add(new Calculation
                {
                    Count = count,
                    Result = total
                });
                await calcContext.SaveChangesAsync();
            }
            string totalString = $"({ DateTime.Now.ToLongTimeString() }) {total}";
            await context.Response.WriteAsync(
 $"({DateTime.Now.ToLongTimeString()}) Total for {count}"
 + $" values:\n{totalString}\n");



        }
    }
}
