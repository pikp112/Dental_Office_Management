using Microsoft.AspNetCore.Mvc;
using WhiteDentalClinic.Application.Models;
using WhiteDentalClinic.Application.Models.Customer;
using WhiteDentalClinic.Application.Services.Interfaces;

namespace WhiteDentalClinic.Api.Controllers
{
    public class CustomersController : ApiController
    {
        readonly ICustomerService _customerService;
        public CustomersController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet]  
        public ActionResult<IEnumerable<ResponseCustomerModel>> GetAllCustomers()
        {
            try
            {
                return Ok(ApiGenericsResult<IEnumerable<ResponseCustomerModel>>.Success(_customerService.GetAll()));
            }
            catch(Exception ex)
            {
                return BadRequest(ApiGenericsResult<ResponseCustomerModel>.Failure(new[] { $"{ex.Message}" }));
            }
        }

        [HttpGet("{id:guid}")]
        public IActionResult GetCustomerById(Guid id)
        {
            try
            {
                return Ok(ApiGenericsResult<ResponseCustomerModel>.Success(_customerService.GetById(id)));
            }
            catch(Exception ex)
            {
                if(_customerService.GetAll().ToList().First(x=>x.Id == id) == null)
                {
                    return NotFound(ex.Message);
                }
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult CreateCustomer(RequestCreateCustomerModel customerModel) 
        {
            try
            {
                return Ok(ApiGenericsResult<ResponseCustomerModel>.Success(_customerService.Create(customerModel)));
            }
            catch(Exception ex)
            {
                return BadRequest(ApiGenericsResult<ResponseCustomerModel>.Failure(new[] {$"{ex.Message}"})); 
            }
        }
        [HttpPut]
        public IActionResult UpdateCustomer(Guid id, RequestUpdateCustomerModel customerModel)
        {
            try
            {
                return Ok(ApiGenericsResult<ResponseUpdateCustomerModel>.Success(_customerService.Update(id, customerModel)));
            }
            catch(Exception ex)
            {
                if(_customerService.GetAll().ToList().First(x => x.Id ==id) == null)
                {
                    return NotFound(ApiGenericsResult<ResponseUpdateCustomerModel>.Failure(new[] { $"{ex.Message}" }));
                }
                return BadRequest(ApiGenericsResult<ResponseUpdateCustomerModel>.Failure(new[] { $"{ex.Message}" }));
            }
        }

        [HttpDelete]
        public IActionResult DeleteCustomer(Guid id)
        {
            try
            {
                return Ok(ApiGenericsResult<ResponseCustomerModel>.Success(_customerService.Delete(id)));
            }
            catch(Exception ex)
            {
                if (_customerService.GetAll().ToList().First(x => x.Id == id) == null)
                {
                    return NotFound(ApiGenericsResult<ResponseCustomerModel>.Failure(new[] { $"{ex.Message}" }));
                }
                return BadRequest(ApiGenericsResult<ResponseCustomerModel>.Failure(new[] { $"{ex.Message}"}));
            }
        }
    }
}
