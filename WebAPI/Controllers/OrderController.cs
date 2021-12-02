using Business;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {

        private IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpPost(template: "add")]
        public IActionResult Add(Order order)
        {
            var result = _orderService.Add(order);

            if (result.Success)
            {

                return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }
    }
}
