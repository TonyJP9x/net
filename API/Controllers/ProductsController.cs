using Core.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API.Data;
using Core.Interfaces;

namespace API.Controllers
{
    [ApiController] //validate the data type of HTTP Request so it can make sure the parameter type
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        //the idea of Dependency Injection is when a request comes into our controller, our framework is going to root our request list controller and create instantiate a new instance of our product controller
        //after got access to all of the DB context methods inside our controller then our request is finished, our products controller is disposed of and store context also.
        private readonly IProductRepository _repo;
        
        public ProductsController(IProductRepository repo)
        {
            _repo = repo;
          

        }
        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetProducts()
        {
            var products = await _repo.GetProductsAsync();
            return Ok(products);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            var product = await _repo.GetProductByIdAsync(id);
            return product;
        }
        [HttpGet("brands")]
        public async Task<ActionResult<List<ProductBrand>>> GetProductBrands(){
            var productBrands = await _repo.GetProductBrandsAsync();
            return Ok(productBrands);
        }
        [HttpGet("types")]
        public async Task<ActionResult<List<ProductType>>> GetProductTypes(){
            var productTypes = await _repo.GetProductTypesAsync();
            return Ok(productTypes);
        }
      
        
      
       

    }

}