using ConsultationAppointmentClient.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;


namespace ConsultationAppointmentClient.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }


        public ActionResult Login()
        {
            return View();
        }


        public ActionResult Logout()
        {
            HttpContext.Session.SetString("Email", "");
            return RedirectToAction("Login","Home");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(string email, string password)
        {
            if (ModelState.IsValid)
            {

                 if (email == "test@test.com" && password == "test")
                {
                   HttpContext.Session.SetString("Email", email);
                    //HttpContext.Session.SetString("idUser", email);
                    //Session["Email"] = email;
                    //Session["idUser"] = password;
                    return RedirectToAction("Index","Appointment");
                }
                else
                {
                    HttpContext.Session.SetString("Email", "");
                    ViewBag.error = "Login failed";
                    return RedirectToAction("Login");
                }
            }
            return View();
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Success()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}