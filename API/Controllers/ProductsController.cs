using Core.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API.Data;

namespace API.Controllers
{
    [ApiController] //validate the data type of HTTP Request 
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        //the idea of Dependency Injection is when a request comes into our controller, our framework is going to root our request list controller and create instantiate a new instance of our product controller
        //after got access to all of the DB context methods inside our controller then our request is finished, our products controller is disposed of and store context also.
        private readonly StoreContext _context;
        public ProductsController(StoreContext context)
        {
            _context = context;

        }
        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetProducts()
        {
            var products = await _context.Products.ToListAsync();
            return products;
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            var product = await _context.Products.FirstOrDefaultAsync(p => p.Id == id);
            return product;
        }
      
        
      
       

    }

}