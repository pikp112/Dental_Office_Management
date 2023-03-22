using Microsoft.AspNetCore.Mvc;
using WhiteDentalClinic.Application.Models.Dentist;
using WhiteDentalClinic.Application.Models;
using WhiteDentalClinic.Application.Models.MedicalServiceModel;
using WhiteDentalClinic.Application.Services.Interfaces;

namespace WhiteDentalClinic.Api.Controllers
{
    public class MedicalServiceController : ApiController
    {
        private readonly IMedicalServiceService _medicalService;
        public MedicalServiceController(IMedicalServiceService medicalService) 
        {
            _medicalService= medicalService;
        }

        [HttpGet("allmedservices")]
        public ActionResult<IEnumerable<ResponseMedicalServices>> GetAllMedicalServices()
        {
            try
            {
                return Ok(ApiGenericsResult<IEnumerable<ResponseMedicalServices>>.Success(_medicalService.GetAllMedicalServices()));
            }
            catch(Exception ex)
            {
                return BadRequest(ApiGenericsResult<ResponseMedicalServices>.Failure(new[] { $"{ex.Message}" }));
            }
        }
        [HttpGet("allmedservices/dentist{requestDentistId}")]
        public ActionResult<IEnumerable<ResponseMedicalServices>> GetAllMedicalServicesByDentistId(Guid requestDentistId)
        {
            try
            {
                return Ok(ApiGenericsResult<IEnumerable<ResponseMedicalServices>>.Success(_medicalService.GetAllMedicalServicesByDentistId(requestDentistId)));
            }
            catch (Exception ex)
            {
                return BadRequest(ApiGenericsResult<ResponseMedicalServices>.Failure(new[] { $"{ex.Message}" }));
            }
        }

        [HttpPost("create")]
        public IActionResult CreateAMedicalService(CreateMedicalService requestMedicalServiceModel)
        {
            try
            {
                return Ok(ApiGenericsResult<ResponseMedicalServices>.Success(_medicalService.CreateAMedicalService(requestMedicalServiceModel)));
            }
            catch (Exception ex)
            {
                return BadRequest(ApiGenericsResult<ResponseMedicalServices>.Failure(new[] { $"{ex.Message}" }));
            }
        }

        [HttpPut("{id:guid}")]
        public IActionResult UpdateMedicalService(Guid id, UpdateRequestMedicalService updateRequestMedicalServiceModel)
        {
            try
            {
                return Ok(ApiGenericsResult<UpdateResponseMedicalService>.Success(_medicalService.UpdateMedicalService(id, updateRequestMedicalServiceModel)));
            }
            catch (Exception ex)
            {
                if(_medicalService.GetAllMedicalServices().ToList().First(x => x.Id == id) == null)
                {
                    return NotFound(ApiGenericsResult<UpdateDentistResponseModel>.Failure(new[] { $"{ex.Message}" }));
                }
                return BadRequest(ApiGenericsResult<UpdateDentistResponseModel>.Failure(new[] { $"{ex.Message}" }));
            }
        }

        [HttpDelete("delete")]
        public IActionResult DeleteMedicalService(Guid id)
        {
            try
            {
                return Ok(ApiGenericsResult<ResponseMedicalServices>.Success(_medicalService.DeleteMedicalService(id)));
            }
            catch (Exception ex)
            {
                if(_medicalService.GetAllMedicalServices().ToList().First(x => x.Id == id) == null)
                {
                    return NotFound(ApiGenericsResult<DentistResponseModel>.Failure(new[] { $"{ex.Message}" }));
                }
                return BadRequest(ApiGenericsResult<DentistResponseModel>.Failure(new[] { $"{ex.Message}" }));
            }
        }
    }
}