using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using pharmacyManagementSystem.Dto;
using pharmacyManagementSystem.Models;
using pharmacyManagementSystem.Repository;
using System;

namespace pharmacyManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderRepository _orderRepository;

        public OrderController(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var order = _orderRepository.GetAll();
                return Ok(order);
            }
            catch(Exception)
            {
                return BadRequest();
            }
            
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
                var supplier = _orderRepository.GetOrder(id);
                if (supplier == null)
                {
                    throw new ArgumentException();
                }
                return new OkObjectResult(supplier);
            }
            catch(Exception)
            {
                return NotFound();
            }
            
        }
        [HttpPost]
        public IActionResult Post(OrderDto orderDto)
        {
            var order = new OrderDetail
            {
                DrugId = orderDto.DrugId,
                Quantity = orderDto.Quantity,
                OrderPickedUp = orderDto.OrderPickedUp,
                TotalAmount = orderDto.TotalAmount,
                OrderPrice = orderDto.OrderPrice,
            };
            var newOrder = _orderRepository.Create(order);
            return Created("Sucess", newOrder);

        }
        [HttpPut("{id}")]
        public IActionResult Put(int id, OrderDto orderDto)
        {
            var order = new OrderDetail
            {
                DrugId = orderDto.DrugId,
                Quantity = orderDto.Quantity,
                TotalAmount = orderDto.TotalAmount,
                OrderPrice = orderDto.OrderPrice,
            };
            _orderRepository.UpdateOrder(order);
            return new OkResult();

        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _orderRepository.DeleteOrder(id);
            return Ok();
        }
    }
}
