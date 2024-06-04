using Microsoft.AspNetCore.Mvc;
using Shop.Core.Entities;
using Shop.Core.Service;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Shop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProviderController : ControllerBase
    {
        private readonly IProviderService _providerService;
        public ProviderController(IProviderService providerService)
        {
            _providerService = providerService;
        }
        // GET: api/<EmployeeController>
        [HttpGet]
        public async Task< IActionResult> Get()
        {
            return Ok(await _providerService.GetProvidersAsync());
        }

        // GET api/<EmployeeController>/5
        [HttpGet("{id}")]
        public async Task< IActionResult> Get(int id)
        {
            var provider = _providerService.GetProviderByIdAsync(id);
            if (provider == null)
                return NotFound();
            return Ok(provider);
        }

        // POST api/<EmployeeController>
        [HttpPost]
        public async Task< ActionResult> Post([FromBody] Provider provider)
        {
            return Ok(await _providerService.AddProviderAsync(provider));
        }

        // PUT api/<EmployeeController>/5
        [HttpPut("{id}")]
        public async Task< ActionResult> Put(int id, [FromBody] Provider provider)
        {
            return Ok(await _providerService.UpdateProviderAsync(id, provider));
        }

        // DELETE api/<EmployeeController>/5
        [HttpDelete("{id}")]
        public async Task< ActionResult> Delete(int id)
        {
            _providerService.DeleteProviderAsync(id);
            return Ok();
        }
    }
}
