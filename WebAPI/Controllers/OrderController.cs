using Business;
using Core.Utilities.Results;
using Entities;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
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
        private IBillingService _billingService;
        private IProductService _productService;
        private readonly ILogger<OrderController> _logger;

        public OrderController(IOrderService orderService, IBillingService billingService, IProductService productService, ILogger<OrderController> logger)
        {
            _orderService = orderService;
            _billingService = billingService;
            _productService = productService;
            _logger = logger;
        }

        [HttpPost(template: "add")]
        public IActionResult Add(Order order)
        {
            IResult result;
            _logger.LogInformation("test");
            var prod = _productService.GetById(order.Product.ID);

            if (prod.Data.Stock > order.Quantity)
            {
                result = _orderService.Add(order);
                if (result.Success)
                {
                    prod.Data.Stock -= order.Quantity;
                    _productService.Update(prod.Data);
                    //Billing billing = new Billing();
                    //_billingService.Create(billing);
                    _logger.LogInformation(result.Message);
                    return Ok(result.Message);
                }
                _logger.LogInformation(result.Message);
                return BadRequest(result.Message);
            }
            return BadRequest();
        
        }
    }
}
