using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RMCB.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;

namespace RMCB.Controllers
{
    public class HomeController : Controller
    {
        private MyContext _context;
        
        public HomeController(MyContext context)
        {
            _context = context;
        }
        
        public static object Breakdown(Bootcamp ThisBootcamp)
        {
            //For Breakdown - declaration
            float Curric = 0;
            float Diff = 0;
            float Instruct = 0;
            float Facil = 0;
            float Career = 0;
            List<float> Breakdown = new List<float>();
            //Rating Logic - declaration
            float Rating = 0;
            float total = 0;
            int RecCount = 0;
            int RecPerc = 0;
                foreach (var r in ThisBootcamp.Reviews)
                {
                    // Console.WriteLine(c.Reviews.Count);
                    if (ThisBootcamp.Reviews.Count == 0){
                        total = 1;
                    } 
                    else {
                        total += (float)(r.Curriculum + r.Instructors + r.Facility + r.JobSupport + r.Difficulty);
                        Curric += (float)r.Curriculum;
                        Diff += (float)r.Difficulty;
                        Instruct += (float)r.Instructors;
                        Facil += (float)r.Facility;
                        Career += (float)r.JobSupport;
                        if(r.Recommend == "YES"){
                            RecCount += 1;
                        }
                    }
                    
                }
                if(ThisBootcamp.Reviews.Count < 1){
                    Rating = total;
                } else{
                    // Console.WriteLine(total);
                    float rate = (total/(ThisBootcamp.Reviews.Count * 5));
                    Rating = rate;
                    RecPerc = (100 / ThisBootcamp.Reviews.Count) * RecCount;
                    
                }
            //Calculating Breakdown ratings 
            Curric = Curric/(float)ThisBootcamp.Reviews.Count;
            Diff = Diff/(float)ThisBootcamp.Reviews.Count;
            Instruct = Instruct/(float)ThisBootcamp.Reviews.Count;
            Facil = Facil/(float)ThisBootcamp.Reviews.Count;
            Career = Career/(float)ThisBootcamp.Reviews.Count;
            //Adding Breakdown ratings
            Breakdown.Add(Curric);
            Breakdown.Add(Diff);
            Breakdown.Add(Instruct);
            Breakdown.Add(Facil);
            Breakdown.Add(Career);
            Breakdown.Add(RecPerc);
            Breakdown.Add(Rating);
            return Breakdown;
        }
        
        
        
        
        //Global Session LoggedIn User Checkers -=-=-=-=-==--=-
        public User LoggedID()//Returns User model if valid - else null
        {
            int? LoggedID = HttpContext.Session.GetInt32("LoggedIn");//Setting LoggedID as userID
            User Logged = _context.Users.FirstOrDefault(u => u.UserID == LoggedID); //querying DB for user w/ matching ID
            return Logged; //Returning logged == logged user. 
        }
        
        public User LoggedInUser()
        {
            int? LoggedID = HttpContext.Session.GetInt32("LoggedIn");
            User logged = _context.Users.FirstOrDefault(u => u.UserID == LoggedID);
            return logged;
        }

        public int UserID()
        {
            int UserID = LoggedInUser().UserID;
            return UserID;
        }


        //MAIN HOME -=-=-=-=-=-=-=-=-=-
        public IActionResult Index()
        {
            return View();
        }
        
        [HttpGet("about")]
        public IActionResult About()
        {
            return View();
        }
        
        
        //LOGIN REGISTER =-=-=-=-=-=-=-=-
        
        [HttpGet("login")]
        public IActionResult Login()
        {
            return View();
        }
        
        
        [HttpGet("signup")]
        public IActionResult Register()
        {
            return View();
        }
        
        [HttpPost("/register/user")]
        public IActionResult NewUser(User newUser)
        {
            if (ModelState.IsValid)
            {
                var Exists = _context.Users.FirstOrDefault( u => u.Email == newUser.Email);
                if (Exists == null)
                {
                    PasswordHasher<User> Hashed = new PasswordHasher<User>();
                    newUser.Password = Hashed.HashPassword(newUser, newUser.Password);
                    _context.Add(newUser);
                    _context.SaveChanges();
                    HttpContext.Session.SetInt32("LoggedIn", newUser.UserID);
                    return RedirectToAction("Index");
                } else {
                    ModelState.AddModelError("Email", "Email is already in use! Please Login.");
                    return View("Register");
                }
            } else {
                return View("Register");
            }
        }
        
        
        [HttpPost("/login/user")]
        public IActionResult LoginUser(LUser Login)
        {
            if (ModelState.IsValid){
                
                var UserInDB = _context.Users.FirstOrDefault( u => u.Email == Login.LEmail);
                
                if (UserInDB == null)
                {
                    ModelState.AddModelError("LEmail", "Invalid Email or Password!");
                    return View("Login");
                }
                
                var Hashed = new PasswordHasher<LUser>();
                var result = Hashed.VerifyHashedPassword(Login, UserInDB.Password, Login.LPassword);
                
                if (result == 0)
                {
                    ModelState.AddModelError("LEmail", "Invalid Email or Password!");
                    return View("Login");
                } else {
                    HttpContext.Session.SetInt32("LoggedIn", UserInDB.UserID);
                    return RedirectToAction("Index");
                }
                
            } 
            else {
                return View("Login");
            }
            
        }
        
        
        
        
        //ADMIN PANEL ROUTES-=-=-=-=-=-=-=-
        [HttpGet("Admin")]
        public IActionResult Admin()
        {
            //HARDCODE LOGIC SO ONLY ADMIN ACC CAN ACCESS BY ID
            //Add all ness viewbags for forms 
            ViewBag.CourseCats = _context.CourseCats.ToList();
            ViewBag.Bootcamps = _context.Bootcamps.ToList();
            ViewBag.States = _context.States.ToList();
            return View();
        }
        
        //ADD BOOTCAMP
        [HttpPost("/add/bootcamp")]
        public IActionResult AddBootcamp(Bootcamp newCamp)
        {
            //add admin verification
            if (ModelState.IsValid)
            {
                _context.Bootcamps.Add(newCamp);
                _context.SaveChanges();
                return RedirectToAction("Admin");
            } else {
                return RedirectToAction("FatalError");
            }
        }
        
        //Add BC Course
        [HttpPost("/add/bootcamp/course")]
        public IActionResult AddCourse(Course newCourse)
        {
            //Add Admin Verification
            if (ModelState.IsValid)
            {
                _context.Courses.Add(newCourse);
                _context.SaveChanges();
                return RedirectToAction("Admin");
            } else {
                return RedirectToAction("FatalError");
            }
        }
        
        //Add BC Location
        [HttpPost("/add/bootcamp/location")]
        public IActionResult AddLocation(Location newLocation)
        {
            //add admin verif
            if (ModelState.IsValid)
            {
                _context.Locations.Add(newLocation);
                _context.SaveChanges();
                return RedirectToAction("Admin");
                
            } else {
                return RedirectToAction("FatalError");
            }
        }
        
        //Add Course Category
        [HttpPost("/add/course/category")]
        public IActionResult AddCategory(CourseCat newCategory)
        {
            //addd admin verif
            if (ModelState.IsValid)
            {
                _context.CourseCats.Add(newCategory);
                _context.SaveChanges();
                return RedirectToAction("Admin");
            } else {
                return RedirectToAction("FatalError");
            }
        }
        
        //Add State for locations
        [HttpPost("/add/state")]
        public IActionResult AddState(State newState)
        {
            //add admin checks
            if (ModelState.IsValid)
            {
                _context.States.Add(newState);
                _context.SaveChanges();
                return RedirectToAction("Admin");
            } else {
                return RedirectToAction("FatalError");
            }
        }
        
        
        //USER FRONTEND-=-=-=-=-=-=-=-=-
        [HttpGet("/rate")]
        public IActionResult Rate()
        {
            //Check to see if userID set, if not set to default anon acc.
            ViewBag.Bootcamps = _context.Bootcamps.ToList();
            return View();
        }
        
        
        //Rate page display
        
        [HttpGet("/rate/{BootcampID}")]
        public IActionResult RateCamp(int BootcampID)
        {
            ViewBag.ThisCamp = _context.Bootcamps.Include( b => b.Locations)
                .ThenInclude( l => l.State).Include(b => b.Courses)
                .FirstOrDefault(b => b.BootcampID == BootcampID);
            return View();
            
            
        }
        
        
        //Rate Submit Route
        [HttpPost("rate/submit")]
        public IActionResult SubmitRate(Review newRating)
        {
            if (ModelState.IsValid)
            {
                if (newRating.UserID < 1){
                    
                    _context.Reviews.Add(newRating);
                    _context.SaveChanges();
                    return Redirect("/bootcamps/" + newRating.BootcampID); 
                } else {
                    _context.Reviews.Add(newRating);
                    _context.SaveChanges();
                    return Redirect("/bootcamps/" + newRating.BootcampID); 
                }
                
            } else {
                int BootcampID = newRating.BootcampID;
                ViewBag.ThisCamp = _context.Bootcamps.Include( b => b.Locations)
                .ThenInclude( l => l.State).Include(b => b.Courses)
                .FirstOrDefault(b => b.BootcampID == BootcampID);
                ModelState.AddModelError("Cohort", "Error Submitting, Please make sure every field is answered & try again.");
                return View("RateCamp");
            }
        }
        
        
        
        
        //View All Bootcamps
        [HttpGet("/bootcamps")]
        public IActionResult AllBootcamps()
        {
            List<Bootcamp> camps = _context.Bootcamps.Include(b => b.Locations)
                .ThenInclude(l => l.State).Include(b => b.Reviews).ToList();
            ViewBag.AllBootcamps = camps;
            List<float> Ratings = new List<float>();
            
            foreach (var c in camps)
            {
                float total = 0;
                foreach (var r in c.Reviews)
                {
                    if (c.Reviews.Count == 0){
                        total = 1;
                    } 
                    else {
                        total += (float)(r.Curriculum + r.Instructors + r.Facility + r.JobSupport + r.Difficulty);
                    }
                    
                }
                if(c.Reviews.Count < 1){
                    Ratings.Add(total);
                } else{
                    float rate = (total/(c.Reviews.Count * 5));
                    Ratings.Add(rate);
                }
                
            }
            
            ViewBag.Ratings = Ratings;
            return View();
        }
        
        //View One BootcampRatings
        [HttpGet("/bootcamps/{BootcampID}")]
        public IActionResult ViewBootcamp(int BootcampID)
        {
            var ThisBootcamp = _context.Bootcamps.Include( b => b.Locations)
                .ThenInclude( l => l.State).Include(b => b.Courses).Include(b => b.Reviews)
                .FirstOrDefault(b => b.BootcampID == BootcampID);
            
            ViewBag.Breakdown = Breakdown(ThisBootcamp);
            ViewBag.ThisBootcamp = ThisBootcamp;
            return View();
        }
        
        
        

        public IActionResult Privacy()
        {
            return View();
        }
        
        [HttpGet("/FatalError")]
        public IActionResult FatalError()
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
