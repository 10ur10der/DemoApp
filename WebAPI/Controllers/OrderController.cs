using Business;
using Core.Utilities.Results;
using Entities;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text;

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
        private readonly IConfiguration _configuration;
        private IConnection _connection;
        private readonly ConnectionFactory factory;

        public OrderController(IOrderService orderService, IBillingService billingService, IProductService productService, ILogger<OrderController> logger, IConfiguration configuration)
        {
            _orderService = orderService;
            _billingService = billingService;
            _productService = productService;
            _logger = logger;
            _configuration = configuration;
            //_connection = connection;

            factory = new ConnectionFactory()
            {
                HostName = "localhost",
                UserName = "guest",
                Password = "guest"

            };

            _connection = factory.CreateConnection();
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
                    SendBilling(order);
                    _logger.LogInformation(result.Message);
                    return Ok(result.Message);
                }
                _logger.LogInformation(result.Message);
                return BadRequest(result.Message);
            }
            return BadRequest("Stokta Ürün bulunamadı");

        }


        private void SendBilling(Order order)
        {
            Billing billing = new Billing();
            billing.Order = order;
            billing.ItemPrice = 100;
            billing.JsonTaxes = "{\"Key\":1,\"Value\":20}";
            billing.JsonDiscounts = "{\"Key\":2,\"Value\":5}";
            billing.TotalCost = 50;
            _billingService.Create(billing);

            using (var channel = this._connection.CreateModel())
            {
                channel.QueueDeclare(
                    queue:"customer",
                    durable:false,
                    exclusive:false,
                    autoDelete:false,
                    arguments:null
                    );

                var customerBilling = System.Text.Json.JsonSerializer.Serialize(billing);
                var body = Encoding.UTF8.GetBytes(customerBilling);

                channel.BasicPublish(
                    exchange:"",
                    routingKey:"customer",
                    basicProperties:null,
                    body:body
                    );
            }
        }
       
    
    }
}
