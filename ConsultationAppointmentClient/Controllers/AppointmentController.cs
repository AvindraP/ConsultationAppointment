using ConsultationAppointmentClient.Models;
using Microsoft.AspNetCore.Mvc;

namespace ConsultationAppointmentClient.Controllers
{
    public class AppointmentController : Controller
    {
        public IActionResult Index()
        {
            List<Appointment> appointments = new List<Appointment>();
            //API GET Will come
            return View(appointments);
        }
    }
}
