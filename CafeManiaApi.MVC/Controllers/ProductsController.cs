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
                var ret = _ProductService.GetProductsAll();
                return Ok(ret);
            }
            catch (Exception e)
            {
                return BadRequest("Error:" + e);

            }
        }

        [HttpPost("RegisterProduct")]
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

        [HttpPost("RemoverProduct")]
        public IActionResult RemoverProduct(int idproduct)
        {
            try
            {
                _ProductService.RemoverProduct(idproduct);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest("Error:" + e);

            }

        }


    }
}
