using Microsoft.AspNetCore.Mvc;
using WhiteDentalClinic.Application.Models;
using WhiteDentalClinic.Application.Models.Dentist;
using WhiteDentalClinic.Application.Services.Interfaces;

namespace WhiteDentalClinic.Api.Controllers
{
    public class DentistsController : ApiController
    {
        private readonly IDentistService _dentistService;
        public DentistsController(IDentistService dentistService) 
        {
            _dentistService= dentistService;
        }

        [HttpGet("all")]
        public ActionResult<IEnumerable<DentistResponseModel>> GetAllDentists()
        {
            try
            {
                return Ok(ApiGenericsResult<IEnumerable<DentistResponseModel>>.Success(_dentistService.GetAllDentists()));
            }
            catch (Exception ex)
            {
                return BadRequest(ApiGenericsResult<DentistResponseModel>.Failure(new[] { $"{ex.Message}" }));
            }
        }

        [HttpGet("get{id:guid}")]
        public IActionResult GetDentistById(Guid id)
        {
            try
            {
                return Ok(ApiGenericsResult<DentistResponseModel>.Success(_dentistService.GetDentistById(id)));
            }
            catch (Exception ex)
            {
                if(_dentistService.GetAllDentists().ToList().First(x => x.Id== id) == null)
                {
                    return NotFound(ex.Message);
                }
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("create")]
        public IActionResult CreateDentist(CreateDentistRequestModel requestDentistModel)
        {
            try
            {
                return Ok(ApiGenericsResult<DentistResponseModel>.Success(_dentistService.CreateDentist(requestDentistModel)));
            }
            catch (Exception ex)
            {
                return BadRequest(ApiGenericsResult<DentistResponseModel>.Failure(new[] { $"{ex.Message}" }));
            }
        }

        [HttpPut("update{id:guid}")]
        public IActionResult UpdateDentist (Guid id, UpdateDentistRequestModel updateDentistModel)
        {
            try
            {
                return Ok(ApiGenericsResult<UpdateDentistResponseModel>.Success(_dentistService.UpdateDentist(id, updateDentistModel)));
            }
            catch (Exception ex)
            {
                if(_dentistService.GetAllDentists().ToList().First(x => x.Id == id) == null)
                {
                    return NotFound(ApiGenericsResult<UpdateDentistResponseModel>.Failure(new[] { $"{ex.Message}" }));
                }
                return BadRequest(ApiGenericsResult<UpdateDentistResponseModel>.Failure(new[] { $"{ex.Message}" }));
            }
        }

        [HttpDelete("delete")]
        public IActionResult DeleteDentist(Guid id)
        {
            try
            {
                return Ok(ApiGenericsResult<DentistResponseModel>.Success(_dentistService.DeleteDentist(id)));
            }
            catch (Exception ex)
            {
                if (_dentistService.GetAllDentists().ToList().First(x => x.Id == id) == null)
                {
                    return NotFound(ApiGenericsResult<DentistResponseModel>.Failure(new[] { $"{ex.Message}" }));
                }
                return BadRequest(ApiGenericsResult<DentistResponseModel>.Failure(new[] { $"{ex.Message}" }));
            }
        }
    }
}
