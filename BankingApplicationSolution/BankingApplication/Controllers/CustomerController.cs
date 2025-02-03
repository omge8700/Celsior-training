using BankingApplication.Exceptions;
using BankingApplication.Interface;
using BankingApplication.Models.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BankingApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService employeeService)
        {
            _customerService = employeeService;
            
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCustomer()
        {
            try
            {
                var customers = await _customerService.GetAllCustomer();
                return Ok(customers);
            }

            catch (EmptyCollectionException ex)
            {
                return Ok();

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);

            }


        }

        [HttpGet("{id}")]

        public async Task<IActionResult> GetCustomerById(int id)
        {
            try
            {
                var customer = await _customerService.GetCustomer(id);
                return Ok(customer);

            }
            catch (InvalidOperationException ex)
            {

                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);

                }


            }
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> UpdateCustomer(int id, CreateCustomerDTO updateCustomer)
        {
            try
            {
                var customerId = await _customerService.UpdateCustomer(id, updateCustomer);
                return Ok(new { message = $"Update Successfull for Id: {customerId}" });

            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateCustomer(CreateCustomerDTO customer)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var customerId = await _customerService.CreateCustomer(customer);
                    return Ok(new { message = $"Create Successfull for Id: {customerId}" });
                }
                return BadRequest("One or more fields validate error");

            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteCustomer(int id)
        {
            try
            {
                var deletedCustomerId = await _customerService.DeleteCustomer(id);
                return Ok(new { message = $"Delete Successfull for Customer Id: {id}" });

            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }







    }
}
