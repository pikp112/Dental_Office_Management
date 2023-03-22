using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using WhiteDentalClinic.Application.Models;
using WhiteDentalClinic.Application.Models.AppointmentModel;
using WhiteDentalClinic.Application.Services.Interfaces;

namespace WhiteDentalClinic.Api.Controllers
{
    public class AppointmentController : ApiController
    {
        readonly IAppointmentService _appointmentService;
        public AppointmentController(IAppointmentService appointmentService)
        {
            _appointmentService = appointmentService;
        }

        [HttpGet("allapp/customer{customerRequestId}")]
        public ActionResult<IEnumerable<AppointmentResponseModel>> GetAllAppointmentsByCustomer(Guid customerRequestId)
        {
            try
            {
                return Ok(ApiGenericsResult<IEnumerable<AppointmentResponseModel>>.Success(_appointmentService.GetAllAppointmentsByCustomer(customerRequestId)));
            }
            catch (Exception ex)
            {
                if(_appointmentService.GetAllAppointments().ToList().First(x => x.CustomerId == customerRequestId) ==null)
                {
                    return NotFound(ApiGenericsResult<AppointmentResponseModel>.Failure(new[] { $"{ex.Message}" }));
                }
                return BadRequest(ApiGenericsResult<AppointmentResponseModel>.Failure(new[] { $"{ex.Message}" }));
            }
        }

        [HttpGet("allapp/dentist{dentistRequestId}")]
        public ActionResult<IEnumerable<AppointmentResponseModel>> GetAllAppointmentsByDentist(Guid dentistRequestId)
        {
            try
            {
                return Ok(ApiGenericsResult<IEnumerable<AppointmentResponseModel>>.Success(_appointmentService.GetAllAppointmentsByDentist(dentistRequestId)));
            }
            catch (Exception ex)
            {
                if (_appointmentService.GetAllAppointments().ToList().Select(x => x.DentistId == dentistRequestId) ==null)
                {
                    return NotFound(ApiGenericsResult<AppointmentResponseModel>.Failure(new[] { $"{ex.Message}" }));
                }
                return BadRequest(ApiGenericsResult<AppointmentResponseModel>.Failure(new[] { $"{ex.Message}" }));
            }
        }


        [HttpGet("{id:guid}")]
        public IActionResult GetAppointmentById(Guid id)
        {
            try
            {
                return Ok(ApiGenericsResult<AppointmentResponseModel>.Success(_appointmentService.GetAppointmentById(id)));
            }
            catch (Exception ex)
            {
                if(_appointmentService.GetAllAppointments().ToList().First(x => x.Id == id) == null)
                {
                    return NotFound(ex.Message);
                }
                return BadRequest(ex.Message);
            }

        }

        [HttpPost("create")]
        public IActionResult CreateAppointment(CreateAppointmentRequestModel requestAppointmentModel) 
        {
            try
            {
                return Ok(ApiGenericsResult<AppointmentResponseModel>.Success(_appointmentService.CreateAppointment(requestAppointmentModel)));
            }
            catch(Exception ex)
            {
                return BadRequest(ApiGenericsResult<AppointmentResponseModel>.Failure(new[] {$"{ex.Message}"})); 
            }
        }

        [HttpDelete("delete")]
        public IActionResult DeleteAppointment(Guid appointmentId)
        {
            try
            {
                return Ok(ApiGenericsResult<AppointmentResponseModel>.Success(_appointmentService.DeleteAppointment(appointmentId)));
            }
            catch(Exception ex)
            {
                if(_appointmentService.GetAllAppointments().ToList().First(x => x.Id == appointmentId) == null)
                {
                    return NotFound(ApiGenericsResult<AppointmentResponseModel>.Failure(new[] { $"{ex.Message}" }));
                }
                return BadRequest(ApiGenericsResult<AppointmentResponseModel>.Failure(new[] { $"{ex.Message}"}));
            }
        }
    }
}
