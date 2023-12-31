﻿using Microsoft.AspNetCore.Http;
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
            // Check for a duplicate appointment based on both Date and Time
            if (IsDuplicateAppointment(appointment.Date, appointment.Time))
            {
                ModelState.AddModelError("Date", "An appointment with the same date and time already exists.");
                return BadRequest(new { ErrorMessage = "An appointment with the same date and time already exists." });
            }

            _context.Add(appointment);
            await _context.SaveChangesAsync();
            return Ok(appointment);
        }

        private bool IsDuplicateAppointment(string date, string time)
        {
            // Check for a duplicate appointment with the same date and time
            return _context.Appointments.Any(a => a.Date == date && a.Time == time);
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

        [HttpDelete("{appointmentId}")]
        public async Task<IActionResult> Delete(int appointmentId)
        {
            var appointment = await _context.Appointments.FindAsync(appointmentId);
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
