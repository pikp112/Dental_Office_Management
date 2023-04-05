using Microsoft.AspNetCore.Mvc;
using WhiteDentalClinic.Application.Models;
using WhiteDentalClinic.Application.Models.AppointmentModel;
using WhiteDentalClinic.Application.Services.Interfaces;

namespace WhiteDentalClinic.Api.Controllers
{
    public class AppointmentsController : ApiController
    {
        readonly IAppointmentService _appointmentService;
        public AppointmentsController(IAppointmentService appointmentService)
        {
            _appointmentService = appointmentService;
        }

        [HttpGet("customers/{customerId}")]
        public ActionResult<IEnumerable<ResponseAppointmentModel>> GetAllAppointmentsByCustomer(Guid customerId)
        {
            try
            {
                return Ok(ApiGenericsResult<IEnumerable<ResponseAppointmentModel>>.Success(_appointmentService.GetAllByCustomer(customerId)));
            }
            catch (Exception ex)
            {
                if(_appointmentService.GelAll().ToList().First(x => x.CustomerId == customerId) ==null)
                {
                    return NotFound(ApiGenericsResult<ResponseAppointmentModel>.Failure(new[] { $"{ex.Message}" }));
                }
                return BadRequest(ApiGenericsResult<ResponseAppointmentModel>.Failure(new[] { $"{ex.Message}" }));
            }
        }

        [HttpGet("dentists/{dentistId}")]
        public ActionResult<IEnumerable<ResponseAppointmentModel>> GetAllAppointmentsByDentist(Guid dentistId)
        {
            try
            {
                return Ok(ApiGenericsResult<IEnumerable<ResponseAppointmentModel>>.Success(_appointmentService.GetAllByDentist(dentistId)));
            }
            catch (Exception ex)
            {
                if (_appointmentService.GelAll().ToList().Select(x => x.DentistId == dentistId) ==null)
                {
                    return NotFound(ApiGenericsResult<ResponseAppointmentModel>.Failure(new[] { $"{ex.Message}" }));
                }
                return BadRequest(ApiGenericsResult<ResponseAppointmentModel>.Failure(new[] { $"{ex.Message}" }));
            }
        }


        [HttpGet("{id:guid}")]
        public IActionResult GetAppointmentById(Guid id)
        {
            try
            {
                return Ok(ApiGenericsResult<ResponseAppointmentModel>.Success(_appointmentService.GetById(id)));
            }
            catch (Exception ex)
            {
                if(_appointmentService.GelAll().ToList().First(x => x.Id == id) == null)
                {
                    return NotFound(ex.Message);
                }
                return BadRequest(ex.Message);
            }

        }

        [HttpPost]
        public IActionResult CreateAppointment(RequestCreateAppointmentModel appointmentModel) 
        {
            try
            {
                return Ok(ApiGenericsResult<ResponseAppointmentModel>.Success(_appointmentService.Create(appointmentModel)));
            }
            catch(Exception ex)
            {
                return BadRequest(ApiGenericsResult<ResponseAppointmentModel>.Failure(new[] {$"{ex.Message}"})); 
            }
        }

        [HttpDelete]
        public IActionResult DeleteAppointment(Guid appointmentId)
        {
            try
            {
                return Ok(ApiGenericsResult<ResponseAppointmentModel>.Success(_appointmentService.Delete(appointmentId)));
            }
            catch(Exception ex)
            {
                if(_appointmentService.GelAll().ToList().First(x => x.Id == appointmentId) == null)
                {
                    return NotFound(ApiGenericsResult<ResponseAppointmentModel>.Failure(new[] { $"{ex.Message}" }));
                }
                return BadRequest(ApiGenericsResult<ResponseAppointmentModel>.Failure(new[] { $"{ex.Message}"}));
            }
        }
    }
}
