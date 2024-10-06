using Microsoft.AspNetCore.Mvc;
using WebApp.Models;

namespace WebApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private DataContext _dataContext;
        public ProductsController(DataContext dataContex)
        {
            _dataContext = dataContex;
        }



        [HttpGet]
        public  IAsyncEnumerable<Product> GetProducts()
        {
            return  _dataContext.Products.AsAsyncEnumerable();
        }
        [HttpGet("{id}")]
        public async Task<IActionResult?> GetProduct(long id, [FromServices]ILogger<ProductsController> logger)
        {
            Product? P = await _dataContext.Products.FindAsync(id);
            logger.LogDebug("GetProduct Invoked");

            if (P == null)
            {
                return NotFound();
            }

            return Ok(P);
        }

        [HttpPost]
        public async Task<IActionResult> SaveProduct(ProductBindingTarget target)
        {
            
                Product? p = target.ToProduct();

                _dataContext.Products.Add(p);
                await _dataContext.SaveChangesAsync();
                return Ok(p);
           
            
        }

        [HttpPut]
        public async Task UpdateProduct(Product product)
        {
            _dataContext.Products.Update(product);
            await _dataContext.SaveChangesAsync();
        }

        [HttpDelete("{id}")]
        public async Task DeleteProduct(long id)
        {
            _dataContext.Products.Remove(new Product() { ProductId = id });
            await _dataContext.SaveChangesAsync();
        }
        [HttpGet("Redirect")]
        public IActionResult Redirect()
        {
            return RedirectToAction(nameof(GetProduct),nameof(ProductsController), new {Id = 1});
        }
    }
}
