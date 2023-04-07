using Microsoft.AspNetCore.Mvc;
using WhiteDentalClinic.Application.Models.Dentist;
using WhiteDentalClinic.Application.Models;
using WhiteDentalClinic.Application.Models.MedicalServiceModel;
using WhiteDentalClinic.Application.Services.Interfaces;
using WhiteDentalClinic.Application.Models.AppointmentModel;
using WhiteDentalClinic.Application.Services;

namespace WhiteDentalClinic.Api.Controllers
{
    public class MedicalServicesController : ApiController
    {
        private readonly IMedicalServiceService _medicalService;
        public MedicalServicesController(IMedicalServiceService medicalService) 
        {
            _medicalService= medicalService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<ResponseMedicalServices>> GetAllMedicalServices()
        {
            try
            {
                return Ok(ApiGenericsResult<IEnumerable<ResponseMedicalServices>>.Success(_medicalService.GetAll()));
            }
            catch(Exception ex)
            {
                return BadRequest(ApiGenericsResult<ResponseMedicalServices>.Failure(new[] { $"{ex.Message}" }));
            }
        }
        [HttpGet("dentist{DentistId}")]
        public ActionResult<IEnumerable<ResponseMedicalServices>> GetAllMedicalServicesByDentistId(Guid dentistId)
        {
            try
            {
                return Ok(ApiGenericsResult<IEnumerable<ResponseMedicalServices>>.Success(_medicalService.GetAllByDentistId(dentistId)));
            }
            catch (Exception ex)
            {
                return BadRequest(ApiGenericsResult<ResponseMedicalServices>.Failure(new[] { $"{ex.Message}" }));
            }
        }

        [HttpPost]
        public IActionResult CreateAMedicalService(RequestCreateMedicalService medicalServiceModel)
        {
            try
            {
                return Ok(ApiGenericsResult<ResponseMedicalServices>.Success(_medicalService.Create(medicalServiceModel)));
            }
            catch (Exception ex)
            {
                return BadRequest(ApiGenericsResult<ResponseMedicalServices>.Failure(new[] { $"{ex.Message}" }));
            }
        }

        [HttpPut]
        public IActionResult UpdateMedicalService(Guid id, RequestUpdateMedicalService medicalServiceModel)
        {
            try
            {
                return Ok(ApiGenericsResult<ResponseUpdateMedicalService>.Success(_medicalService.Update(id, medicalServiceModel)));
            }
            catch (Exception ex)
            {
                if(_medicalService.GetAll().ToList().First(x => x.Id == id) == null)
                {
                    return NotFound(ApiGenericsResult<ResponseUpdateMedicalService>.Failure(new[] { $"{ex.Message}" }));
                }
                return BadRequest(ApiGenericsResult<ResponseUpdateMedicalService>.Failure(new[] { $"{ex.Message}" }));
            }
        }

        [HttpDelete]
        public IActionResult DeleteMedicalService(Guid id)
        {
            try
            {
                return Ok(ApiGenericsResult<ResponseMedicalServices>.Success(_medicalService.Delete(id)));
            }
            catch (Exception ex)
            {
                if(_medicalService.GetAll().ToList().First(x => x.Id == id) == null)
                {
                    return NotFound(ApiGenericsResult<ResponseMedicalServices>.Failure(new[] { $"{ex.Message}" }));
                }
                return BadRequest(ApiGenericsResult<ResponseMedicalServices>.Failure(new[] { $"{ex.Message}" }));
            }
        }

        [HttpGet("{id:guid}")]
        public IActionResult GetById(Guid id)
        {
            try
            {
                return Ok(ApiGenericsResult<ResponseMedicalServices>.Success(_medicalService.GetById(id)));
            }
            catch (Exception ex)
            {
                if (_medicalService.GetAll().ToList().First(x => x.Id == id) == null)
                {
                    return NotFound(ex.Message);
                }
                return BadRequest(ex.Message);
            }

        }

    }
}