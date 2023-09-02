using ConsultationAppointmentClient.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.DotNet.Scaffolding.Shared.ProjectModel;

namespace ConsultationAppointmentClient.Controllers
{
    public class AppointmentController : Controller
    {
        private readonly APIGateway apiGateway;

        //Dependency injection
        public AppointmentController(APIGateway ApiGateway)
        {
            this.apiGateway = ApiGateway;
        }
        public IActionResult Index(string curre)
        {
            //var isLogin = HttpContext.Session.GetString("isLogin");

            string? email = HttpContext.Session.GetString("Email");

            if(email=="test@test.com")
            {
                List<Appointment> appointments;
                //API GET Will come
                appointments = apiGateway.ListAppointments();
                return View(appointments);
            }
            else
            {
               return RedirectToAction("Login","Home");
            }
        }

        //create
        [HttpGet]
        public IActionResult Create()
        {
            Appointment appointment = new Appointment();
            return View(appointment);
        }

        [HttpPost]
        public IActionResult Create(Appointment appointment) 
        {
            apiGateway.CreateAppointment(appointment);
            //do the API create and send the control to Index Action
            return RedirectToAction("Success","Home");
        }

        public IActionResult Details(int appointmentId)
        {
            Appointment appointment = new Appointment();
            // fetch the appointment from the API and show the appointment details in the Details View
            appointment = apiGateway.GetAppointment(appointmentId);
            return View(appointment);
        }

        //edit method
        [HttpGet]
        public IActionResult Edit(int appointmentId)
        {
            Appointment appointment;
            //fetch the appointment from the API and show the appointment details in the edit view
            appointment = apiGateway.GetAppointment(appointmentId);
            return View(appointment);
        }
        [HttpPost]
        public IActionResult Edit(Appointment appointment)
        {
            //do the API edit action and send the control to the Index Action
            apiGateway.UpdateAppointment(appointment);
            return RedirectToAction("index");
        }

        //delete method
        [HttpGet]
        public IActionResult Delete(int appointmentId)
        {
            Appointment appointment;
            appointment = apiGateway.GetAppointment(appointmentId);
            return View(appointment);
        }
        [HttpPost]
        public IActionResult Delete(Appointment appointment)
        {
            //do the API delete action and send the control to Index action
            apiGateway.DeleteAppointment(appointment.AppointmentId);
            return RedirectToAction("index");
        }
    }
}
