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
