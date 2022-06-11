using Microsoft.AspNetCore.Mvc;
using pharmacyManagementSystem.Models;
using pharmacyManagementSystem.Repository;
using pharmacyManagementSystem.Dto;
using System;

namespace pharmacyManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrdersRepostiory _ordersRepository;

        public OrdersController(IOrdersRepostiory orderRepository)
        {
            _ordersRepository = orderRepository;
        }
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var orders = _ordersRepository.GetAll();
                return Ok(orders);
            }
            catch(Exception)
            {
                return BadRequest();
            }
        }
        [HttpPost]
        public IActionResult Post(AddOrdersDto addOrder)
        {
            var order = new Order
            {
                OrderId = addOrder.OrderId,
                UserId = addOrder.UserId,
            };
            var newOrder = _ordersRepository.Create(order);
            return Created("Sucess", newOrder);

        }
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                if (id <= 0)
                {
                    throw new ArgumentException();
                }
                var order = _ordersRepository.GetOrders(id);
                if (order == null)
                {
                    throw new ArgumentException();
                }
                return new OkObjectResult(order);
            }
            catch(Exception)
            {
                return BadRequest();
            }
           
        }
    }
}
