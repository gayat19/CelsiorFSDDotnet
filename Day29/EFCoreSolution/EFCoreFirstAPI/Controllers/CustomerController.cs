using EFCoreFirstAPI.Interfaces;
using EFCoreFirstAPI.Models.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EFCoreFirstAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerBasicService _customerService;
        private readonly ILogger<CustomerController> _logger;

        public CustomerController(ICustomerBasicService customerService,ILogger<CustomerController> logger)
        {
            _customerService = customerService;
            _logger = logger;
        }
        [HttpPost]
        public async Task<IActionResult> CreateCustomer(CustomerDTO customer)
        {
            try
            {
                var customerId = await _customerService.CreateCustomer(customer);
                _logger.LogInformation($"Customer created with id {customerId}");
                return Ok(customerId);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating customer");
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
