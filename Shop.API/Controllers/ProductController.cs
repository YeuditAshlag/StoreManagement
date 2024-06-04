using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Shop.API.Models;
using Shop.Core.Entities;
using Shop.Core.Service;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Shop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;

        public ProductController(IProductService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }
        // GET: api/<EmployeeController>
        [HttpGet]
        public async Task< IActionResult> Get()
        {
            return Ok(await _productService.GetProductsAsync());
        }

        // GET api/<EmployeeController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult >Get(int id)
        {
            var prod =await _productService.GetProductByIdAsync(id);
            if (prod == null)
                return NotFound();
            return Ok(prod);
        }

        // POST api/<EmployeeController>
        [HttpPost]
        public ActionResult Post([FromBody] ProductPostModel product)
        {
            var productToAdd = _mapper.Map<Product>(product);
            var addedProduct = _productService.AddProductAsync(productToAdd);
            var newProduct = _productService.GetProductByIdAsync(addedProduct.Id);
            //var productDto = _mapper.Map<OrderDto>(newProduct);
            return Ok(newProduct);
        }

        // PUT api/<EmployeeController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Product product)
        {
            return Ok(_productService.UpdateProductAsync(id, product));
        }
        // PUT api/<EmployeeController>/5
        [HttpPut("{id}/price")]
        public ActionResult Put(int id, [FromBody] int price)
        {
            return Ok(_productService.UpdateProductPriceAsync(id, price));
        }

        // DELETE api/<EmployeeController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            _productService.DeleteProductAsync(id);
            return Ok();
        }
    }
}
