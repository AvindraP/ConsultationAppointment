using ConsultationAppointmentClient.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.DotNet.Scaffolding.Shared.ProjectModel;

namespace ConsultationAppointmentClient.Controllers
{
    public class ConsultantController : Controller
    {
        private readonly ConsultationAPI consultationGateway;


        public ConsultantController(ConsultationAPI ConsultationAPI)
        {
            this.consultationGateway = ConsultationAPI;
        }
        public IActionResult Index()
        {
            List<Consultant> consultants= new List<Consultant>();
            consultants = consultationGateway.ListConsultants();
            return View(consultants);
        }



        //Create consultant
        [HttpGet]
        public IActionResult Create()
        {
            Consultant consultant = new Consultant();
            return View(consultant);
        }

        [HttpPost]
        public IActionResult Create(Consultant consultant)
        {
            consultationGateway.CreateConsultant(consultant);
            return RedirectToAction("index");
        }

        //details
        public IActionResult Details(int consultantId)
        {
            Consultant consultant = new Consultant();
            consultant = consultationGateway.GetConsultant(consultantId);
            return View(consultant);
        }

        //Edit
        [HttpGet]
        public IActionResult Edit(int consultantId)
        {
            Consultant consultant = new Consultant();
            consultant = consultationGateway.GetConsultant(consultantId);
            return View(consultant);
        }

        [HttpPost]
        public IActionResult Edit(Consultant consultant)
        {
            consultationGateway.UpdateConsultant(consultant);
            return RedirectToAction("index");
        }

        //Delete
        [HttpGet]
        public IActionResult Delete(int consultantId)
        {
            Consultant consultant = new Consultant();
            consultant = consultationGateway.GetConsultant(consultantId);
            return View(consultant);
        }

        [HttpPost]
        public IActionResult Delete(Consultant consultant)
        {
            consultationGateway.DeleteConsultant(consultant.ConsultantId);
            return RedirectToAction("index");
        }
    }
}
