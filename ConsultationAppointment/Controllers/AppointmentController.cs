using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ConsultationAppointment.Model;
using Microsoft.EntityFrameworkCore;

namespace ConsultationAppointment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //inherited with controller class
    public class AppointmentController : ControllerBase
    {
        private readonly AppDbContext _context;

        //constructor
        public AppointmentController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Appointment>>> GetAppointment()
        {
            return Ok(await _context.Appointments.ToListAsync());
        }

        [HttpGet("{appointmentId}")]
        public ActionResult<Appointment> GetAppointment(int appointmentId)
        {
            var appointment = _context.Appointments.Find(appointmentId);
            if (appointment == null)
            {
                return NotFound();
            }
            return appointment;
        }

        [HttpPost]
        public async Task<ActionResult<Appointment>> Create(Appointment appointment)
        {
            _context.Add(appointment);
            await _context.SaveChangesAsync();
            return Ok(appointment);
        }

        [HttpPut("{appointmentID}")]
        public async Task<ActionResult> Update(int appointmentID, Appointment appointment)
        {
            if (appointmentID != appointment.AppointmentId)
                return BadRequest();

            _context.Entry(appointment).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpDelete("{appointmentID}")]
        public async Task<IActionResult> Delete(int appointmentID)
        {
            var appointment = await _context.Appointments.FindAsync(appointmentID);
            if(appointment == null)
            {
                return NotFound();
            }
            _context.Appointments.Remove(appointment);
            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}
