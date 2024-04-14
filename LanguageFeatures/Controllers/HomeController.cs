


using System.Text.Json;
using System.Text.Json.Nodes;

namespace LanguageFeatures.Controllers
{
    public class HomeController : Controller
    {
        public async Task<IActionResult> Index()
        {


            var products = new[] {
                 new { Name = "Kayak", Price = 275M },
                 new { Name = "Lifejacket", Price = 48.95M },
                 new { Name = "Soccer ball", Price = 19.50M },
                 new { Name = "Corner flag", Price = 34.95M }
                 };
            return View(products.Select(p => $"{nameof(p.Name)}: {p.Name}, {nameof(p.Price)}: {p.Price}"));
        }

        public static async IAsyncEnumerable<long?> GetPageLengths(List<string> output, params string[] urls)
        {
            HttpClient client = new HttpClient();
            foreach (var url in urls)
            {
                output.Add($"Started request for {url}");
                var httpMessage = await client.GetAsync(url);
                output.Add($"completed request for {url}");
                yield return httpMessage.Content.Headers.ContentLength;
            }
        }
    }
}
