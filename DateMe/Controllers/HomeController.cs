using DateMe.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace DateMe.Controllers
{
    public class HomeController : Controller
    {
        private DatingApplicationContext _context;

        //Constructor
        public HomeController(DatingApplicationContext temp) // this is using the context file to build an instance of the database for use in the program
        {
            _context = temp;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]   //going in to a form //basically going in to the page
        public IActionResult DatingApplication()
        {
            return View("DatingApplication");
        }

        [HttpPost]  //receive information that was POSTed to a form //basically what comes out of the page
        public IActionResult DatingApplication(Application response) // we want to receive an instance of (Application)
        {
            _context.Applications.Add(response); //Add record coming from POST to the database
            _context.SaveChanges(); //commit changes and save them permanently
            return View("Confirmation", response); // choosing what to show when someone submit the form
        }

    }
}
