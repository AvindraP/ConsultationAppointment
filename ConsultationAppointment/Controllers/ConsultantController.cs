using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ConsultationAppointment.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ConsultationAppointment.Model;

namespace ConsultationAppointment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConsultantController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ConsultantController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Consultant>>> GetConsultant()
        {
            return Ok(await _context.Consultants.ToListAsync());
        }

        [HttpGet("{consultantId}")]
        public ActionResult<Consultant> GetConsultant(int consultantId)
        {
            var consultant = _context.Consultants.Find(consultantId);
            if (consultant == null)
            {
                return NotFound();
            }
            return consultant;
        }

        [HttpPost]
        public async Task<IActionResult> Create(Consultant consultant)
        {
            _context.Add(consultant);
            await _context.SaveChangesAsync();
            return Ok(consultant);
        }

        [HttpPut("{consultantId}")]
        public async Task<ActionResult> Update(int consultantId, Consultant consultant)
        {
            if (consultantId != consultant.ConsultantId)
                return BadRequest();

            _context.Entry(consultant).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpDelete("{consultantId}")]
        public async Task<IActionResult> Delete(int consultantId)
        {
            var consultant = await _context.Consultants.FindAsync(consultantId);
            if (consultant == null)
            {
                return NotFound();
            }
            _context.Consultants.Remove(consultant);
            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}
