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

        //[HttpPost]
        //public async Task<ActionResult<Appointment>> Create(Appointment appointment)
        //{
        //    _context.Add(appointment);
        //    await _context.SaveChangesAsync();
        //    return Ok(appointment);
        //}

        [HttpPost]
        public async Task<IActionResult> Create(Appointment appointment)
        {
            var existingAppointment = _context.Appointments.FirstOrDefault(c => c.Date == appointment.Date && c.Time == appointment.Time);

            if (existingAppointment != null)
            {
                return Conflict("An Appointment already exists with the same date and time");
            }

            _context.Add(appointment);
            await _context.SaveChangesAsync();
            return Ok(appointment);
        }

        [HttpPut("{appointmentId}")]
        public async Task<ActionResult> Update(int appointmentId, Appointment appointment)
        {
            if (appointmentId != appointment.AppointmentId)
                return BadRequest();

            _context.Entry(appointment).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpDelete("{AppointmentId}")]
        public async Task<IActionResult> Delete(int AppointmentId)
        {
            var appointment = await _context.Appointments.FindAsync(AppointmentId);
            if(appointment == null)
            {
                return NotFound("Appointment Not found");
            }
            _context.Appointments.Remove(appointment);
            await _context.SaveChangesAsync();

            return Ok();
        }

        //[HttpGet("consultant")]
        //public IActionResult GetConsultantNames()
        //{
        //    var consultantNames = _context.Consultants.Select(c => c.ConsultantFirstName).ToList();
        //    return Ok(consultantNames);
        //}
    }
}
