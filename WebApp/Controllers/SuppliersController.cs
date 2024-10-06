using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using WebApp.Models;
namespace WebApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SuppliersController : ControllerBase
    {
        private DataContext context;
        public SuppliersController(DataContext _context)
        {
            context = _context;
        }

        [HttpGet("{id}")]
        public async Task<Supplier?> GetSupplier(long id)
        {
            var s =  await context.Suppliers
                .Include(s => s.Products)
                .FirstAsync(a => a.SupplierId == id);

            if( s.Products != null)
            {
                foreach(var p in s.Products)
                {
                    p.Supplier = null;
                }
            }
            return s;

        }
    }
}
