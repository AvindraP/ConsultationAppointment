using ConsultationAppointmentClient.Models;
using Microsoft.AspNetCore.Identity;
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
        public IActionResult Index(string curre, string rolename)
        {

            string? role = TempData["Role"] as string;
            string? userrole = HttpContext.Session.GetString("Role");


            if (userrole=="Receptionist" || userrole == "Admin")
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
            string? role = TempData["Role"] as string;
            string? userrole = HttpContext.Session.GetString("Role");


            if (userrole == "Receptionist" || userrole == "Admin")
            {
                Appointment appointment = new Appointment();
                return View(appointment);
            }
            else
            {
                return RedirectToAction("Login", "Home");
            }
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
            string? role = TempData["Role"] as string;
            string? userrole = HttpContext.Session.GetString("Role");


            if (userrole == "Receptionist" || userrole == "Admin")
            {
                Appointment appointment = new Appointment();
                // fetch the appointment from the API and show the appointment details in the Details View
                appointment = apiGateway.GetAppointment(appointmentId);
                return View(appointment);
            }
            else
            {
                return RedirectToAction("Login", "Home");
            }
        }
        //edit method
        [HttpGet]
        public IActionResult Edit(int appointmentId)
        {
            string? role = TempData["Role"] as string;
            string? userrole = HttpContext.Session.GetString("Role");


            if (userrole == "Receptionist" || userrole == "Admin")
            {
                Appointment appointment;
                //fetch the appointment from the API and show the appointment details in the edit view
                appointment = apiGateway.GetAppointment(appointmentId);
                return View(appointment);
            }
            else
            {
                return RedirectToAction("Login", "Home");
            }

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
            string? role = TempData["Role"] as string;
            string? userrole = HttpContext.Session.GetString("Role");


            if (userrole == "Admin")
            {
                Appointment appointment;
                appointment = apiGateway.GetAppointment(appointmentId);
                return View(appointment);
            }
            else
            {
                return RedirectToAction("Login", "Home");

            }
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
