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
            //Application blah = new Application(); // this the same thing we're returning but just cutting it
            ViewBag.Majors = _context.Majors        //we could also use var major, ViewBag is just an alternative
                .OrderBy(x => x.MajorName)      //ViewBag is a way to past info from the Controller down to the View
                .ToList();                  //here we're taking the majors from the database and display them

            return View("DatingApplication", new Application()); 
            // we're passing in a new instance of Application and will come with an ApplicationID and will populate an application with any defaulted value(s)
        }

        [HttpPost]  //receive information that was POSTed to a form //basically what comes out of the page
        public IActionResult DatingApplication(Application response) // we want to receive an instance of (Application)
        {
            if (ModelState.IsValid)   // only going to be added if this becomes TRUE
            {
                _context.Applications.Add(response); //Add record coming from POST to the database, this sends it and doesn't save it
                _context.SaveChanges(); //commit changes and save them permanently

                return View("Confirmation", response); // choosing what to show when someone submit the form
            }
            else   // Going to redirect the user to fill out the required fields of the form
            {
                ViewBag.Majors = _context.Majors
                    .OrderBy(x => x.MajorName)
                    .ToList();
                return View(response);
            }

            /* We're doing data validation here and send them back to the their application
               if it's not valid */

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

        [HttpGet]   //because we're accessing the form
        public IActionResult Edit(int id)   /* the id here has to be the same name as in Program.cs "id?" 
                                             and same name as aps-rout-varName in Waitlist.cshtml */
        {
            var recordToEdit = _context.Applications
                .Single(x => x.ApplicationId == id);

            ViewBag.Majors = _context.Majors
                .OrderBy(x => x.MajorName)
                .ToList();

            return View("DatingApplication", recordToEdit);
        }

        [HttpPost]  //this is for our edits to be registered otherwise they won't.
        public IActionResult Edit(Application updatedInfo)
        {
            _context.Update(updatedInfo);
            _context.SaveChanges();
            return RedirectToAction("Waitlist");
            /* Above is RedirectToAction("Waitlist) because it'll re-run the Waitlist Action
               whereas return View ("Waitlist") will try to return the Waitlist View without
               running its Action and that will result in an error. */
        }

        [HttpGet]   // Going into delete
        public IActionResult Delete(int id)
        {
            var recordToDelete = _context.Applications
                .Single(x => x.ApplicationId == id);

            return View(recordToDelete);
            //it'll still return the Delete View even if we don't specify it in our return statement b/c the Action is Delete
        }

        [HttpPost]
        public IActionResult Delete(Application application)
        {
            _context.Applications.Remove(application);
            _context.SaveChanges();

            return RedirectToAction("Waitlist");
        }
    }
}
