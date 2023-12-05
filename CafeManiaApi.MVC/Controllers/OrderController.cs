using CafeManiaApi.Application.DTOs;
using CafeManiaApi.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CafeManiaApi.MVC.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : Controller
    {

        public readonly IOrderService _orderService;
        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpPost("RegisterOrder")]
        public IActionResult RegisterOrder(AddOrderDTO order)
        {
            try
            {
                var codigoOrder = _orderService.RegisterOrder(order); ;
                return Ok(codigoOrder);
            }
            catch (Exception e)
            {
                return BadRequest("Error:" + e);

            }

        }

        [HttpPost("getAllPerUser")]
        public IActionResult GetAllPerUser(int iduser)
        {

            try
            {
                var ret = _orderService.GetAllPerUser(iduser);
                return Ok(ret);
            }
            catch (Exception e)
            {
                return BadRequest("Error:" + e);

            }
        }

        [HttpGet("{orderId:int}")]
        public IActionResult GetOrder([FromRoute] int orderId)
        {
            try
            {
                var ret = _orderService.GetOrderById(orderId);
                return Ok(ret);
            }
            catch (Exception e)
            {
                return BadRequest("Error:" + e);

            }
        }
    }
}
