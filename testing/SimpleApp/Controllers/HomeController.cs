using Microsoft.AspNetCore.Mvc;
using SimpleApp.Models;
using System.Security.Cryptography.X509Certificates;

namespace SimpleApp.Controllers
{
    public class HomeController : Controller
    {
        public IDataSource Source  = new ProductDataSource();
        public IActionResult Index()
        {
            
            return View(Source.Products);
        }
    }
}
