using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Shop.API.Models;
using Shop.Core.DTOs;
using Shop.Core.Entities;
using Shop.Core.Service;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Shop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;
        private readonly IMapper _mapper;
        private readonly IConfiguration _config;

        public OrderController(IOrderService orderService, IMapper mapper, IConfiguration config)
        {
            _orderService = orderService;
            _mapper = mapper;
            _config = config;
        }

        // GET: api/<OrderController>
        [HttpGet]
        public async Task< ActionResult> Get()
        {
            return Ok(await _orderService.GetAllOrdersAsync());
        }

        // GET api/<OrderController>/5
        [HttpGet("{id}")]
        public async Task< IActionResult> Get(int id)
        {
            var ord = _orderService.GetOrderByIDAsync(id);
            var orderDto = _mapper.Map<OrderDto>(ord);
            if (orderDto == null)
                return NotFound();
            return Ok(orderDto);
        }

        // POST api/<OrderController>
        [HttpPost]
        public async Task< ActionResult> Post([FromBody] OrderPostModel order)
        {
            var orderToAdd = _mapper.Map<Order>(order);
            var addedOrder = _orderService.AddOrderAsync(orderToAdd);
            var newOrder = _orderService.GetOrderByIDAsync(addedOrder.Id);
            var orderDto = _mapper.Map<OrderDto>(newOrder);
            return Ok(orderDto);
        }
        // PUT api/<OrderController>/5
        [HttpPut("{id}")]
        public async Task< ActionResult> Put(int id, [FromBody] Order order)
        {
            return Ok(_orderService.UpdateOrderAsync(id, order));
        }

        // DELETE api/<OrderController>/5
        [HttpDelete("{id}")]
        public async Task< ActionResult> Delete(int id)
        {
            _orderService.DeleteOrderAsync(id);
            return Ok();
        }
    }
}
