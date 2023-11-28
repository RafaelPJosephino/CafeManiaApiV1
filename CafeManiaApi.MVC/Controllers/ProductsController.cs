using CafeManiaApi.Application.DTOs;
using CafeManiaApi.Application.Interfaces;
using CafeManiaApi.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace CafeManiaApi.MVC.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController: Controller
    {
        public readonly IProductService _ProductService;
        public ProductsController(IProductService productService)
        {
            _ProductService = productService;
        }

        [HttpGet("getAll")]
        public IActionResult GetAll()
        {

            try
            {
                return Ok(_ProductService.GetProductsAll());
            }
            catch (Exception e)
            {
                return BadRequest("Error:" + e);

            }
        }

        [HttpPost("RegisterUser")]
        public IActionResult RegisterProduct(ProductDTO product)
        {
            try
            {
                _ProductService.RegisterProduct(product);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest("Error:" + e);

            }

        }

    }
}
