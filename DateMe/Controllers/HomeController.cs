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
            ViewBag.Majors = _context.Majors        //we could also use var major, ViewBag is just an alternative
                .OrderBy(x => x.MajorName)      //ViewBag is a way to past info from the Controller down to the View
                .ToList();                  //here we're taking the majors from the database and display them

            return View("DatingApplication");
        }

        [HttpPost]  //receive information that was POSTed to a form //basically what comes out of the page
        public IActionResult DatingApplication(Application response) // we want to receive an instance of (Application)
        {
            _context.Applications.Add(response); //Add record coming from POST to the database, this sends it and doesn't save it
            _context.SaveChanges(); //commit changes and save them permanently
            return View("Confirmation", response); // choosing what to show when someone submit the form
        }

        public IActionResult Waitlist()
        {
            // Using Linq to querry
            var applications = _context.Applications
                .Where(x => x.CreeperStalker == false)
                .OrderBy(x => x.LastName)
                .ToList();
            return View(applications); //we can return the viewName or Model or both.
            //basically creating a waitlist view and send in people who responded No to creeper and add them to a list
        }

    }
}
