using Microsoft.AspNetCore.Mvc;
using WhiteDentalClinic.Application.Models;
using WhiteDentalClinic.Application.Models.Dentist;
using WhiteDentalClinic.Application.Models.MedicalServiceModel;
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

        [HttpGet]
        public ActionResult<IEnumerable<ResponseDentistModel>> GetAllDentists()
        {
            try
            {
                return Ok(ApiGenericsResult<IEnumerable<ResponseDentistModel>>.Success(_dentistService.GetAll()));
            }
            catch (Exception ex)
            {
                return BadRequest(ApiGenericsResult<ResponseDentistModel>.Failure(new[] { $"{ex.Message}" }));
            }
        }

        [HttpGet("{id:guid}")]
        public IActionResult GetDentistById(Guid id)
        {
            try
            {
                return Ok(ApiGenericsResult<ResponseDentistModel>.Success(_dentistService.GetById(id)));
            }
            catch (Exception ex)
            {
                if(_dentistService.GetAll().ToList().First(x => x.Id== id) == null)
                {
                    return NotFound(ex.Message);
                }
                return BadRequest(ex.Message);
            }
        }



        [HttpPost]
        public IActionResult CreateDentist(RequestCreateDentistModel dentistModel)
        {
            try
            {
                return Ok(ApiGenericsResult<ResponseDentistModel>.Success(_dentistService.Create(dentistModel)));
            }
            catch (Exception ex)
            {
                return BadRequest(ApiGenericsResult<ResponseDentistModel>.Failure(new[] { $"{ex.Message}" }));
            }
        }




        [HttpPut]
        public IActionResult UpdateDentist (Guid id, RequestUpdateDentistModel dentistModel)
        {
            try
            {
                return Ok(ApiGenericsResult<ResponseUpdateDentistModel>.Success(_dentistService.Update(id, dentistModel)));
            }
            catch (Exception ex)
            {
                if(_dentistService.GetAll().ToList().First(x => x.Id == id) == null)
                {
                    return NotFound(ApiGenericsResult<ResponseUpdateDentistModel>.Failure(new[] { $"{ex.Message}" }));
                }
                return BadRequest(ApiGenericsResult<ResponseUpdateDentistModel>.Failure(new[] { $"{ex.Message}" }));
            }
        }




        [HttpDelete]
        public IActionResult DeleteDentist(Guid id)
        {
            try
            {
                return Ok(ApiGenericsResult<ResponseDentistModel>.Success(_dentistService.DeleteDentist(id)));
            }
            catch (Exception ex)
            {
                if (_dentistService.GetAll().ToList().First(x => x.Id == id) == null)
                {
                    return NotFound(ApiGenericsResult<ResponseDentistModel>.Failure(new[] { $"{ex.Message}" }));
                }
                return BadRequest(ApiGenericsResult<ResponseDentistModel>.Failure(new[] { $"{ex.Message}" }));
            }
        }


        [HttpGet("medicalservices{id}")]
        public IActionResult GetMedicalServices(Guid id)
        {
            try
            {
                return Ok(ApiGenericsResult<IEnumerable<ResponseMedicalServices>>.Success(_dentistService.GetMedicalServicesByDentistId(id)));
            }
            catch (Exception ex)
            {
                return BadRequest(ApiGenericsResult<ResponseMedicalServices>.Failure(new[] { $"{ex.Message}" }));
            }

        }
    }
}
