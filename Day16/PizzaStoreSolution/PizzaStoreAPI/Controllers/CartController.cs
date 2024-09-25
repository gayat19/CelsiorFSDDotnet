using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PizzaStoreAPI.Interfaces;
using PizzaStoreAPI.Models.DTOs;
using System.Diagnostics;

namespace PizzaStoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly ICartService _cartService;

        public CartController(ICartService cartService)
        {
            _cartService = cartService;
        }
        [HttpPost]
        public async Task<IActionResult> AddPizzaToCart(PizzaCartDTO pizzaCartDTO, int customerId)
        {
            try
            {
                var cart = await _cartService.AddPizzaToCart(pizzaCartDTO, customerId);
                return Ok(cart);
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                Debug.WriteLine(e.StackTrace);
                return BadRequest(e.Message);
            }
        }
        [HttpGet]
        public async Task<IActionResult> GetCart(int customerId)
        {
            try
            {
                var cart = await _cartService.GetCart(customerId);
                return Ok(cart);
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                Debug.WriteLine(e.StackTrace);
                return BadRequest(e.Message);
            }
        }
    }
}
